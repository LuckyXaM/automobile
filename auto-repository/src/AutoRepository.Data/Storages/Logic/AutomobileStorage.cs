using AutoRepository.Data.Models;
using AutoRepository.Data.Repositories.Interfaces;
using AutoRepository.Data.Storages.Interfaces;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AutoRepository.Data.Storages.Logic
{
    /// <summary>
    /// Storage для автомобилей
    /// </summary>
    public class AutomobileStorage : IAutomobileStorage
    {
        #region Константы

        /// <summary>
        /// Ключ для брендов
        /// </summary>
        private const string BRANDS_KEY = "Brands";

        /// <summary>
        /// Ключ для автомобилей
        /// </summary>
        private const string CARS_KEY = "Brands";

        #endregion

        #region Поля, свойства

        /// <summary>
        /// Репозиторий автомобилей
        /// </summary>
        private readonly IAutomobileRepository _automobileRepository;

        /// <summary>
        /// Кэш
        /// </summary>
        private readonly IDistributedCache _distributedCache;

        #endregion

        #region Конструктор

        /// <summary>
        /// Storage для автомобилей
        /// </summary>
        public AutomobileStorage(
            IAutomobileRepository automobileRepository,
            IDistributedCache distributedCache
            )
        {
            _automobileRepository = automobileRepository;
            _distributedCache = distributedCache;
        }

        #endregion

        #region Методы

        /// <summary>
        /// Добавляет бренд
        /// </summary>
        public async Task AddBrandAsync(Brand brand)
        {
            if ((await _automobileRepository.GetBrandAsync(brand.Title)) == null)
            {
                _automobileRepository.AddBrand(brand);
                await _automobileRepository.UnitOfWork.SaveChangesAsync();
                await _distributedCache.SetStringAsync(brand.BrandId.ToString(), JsonConvert.SerializeObject(brand));
                await _distributedCache.SetStringAsync(BRANDS_KEY, "");
            }
        }

        /// <summary>
        /// Удаляет бренд
        /// </summary>
        public async Task RemoveBrandAsync(Brand brand)
        {
            if ((await _automobileRepository.GetBrandAsync(brand.BrandId)) != null)
            {
                _automobileRepository.RemoveBrand(brand);
                await _automobileRepository.UnitOfWork.SaveChangesAsync();
                await _distributedCache.RemoveAsync(brand.BrandId.ToString());
                await _distributedCache.SetStringAsync(BRANDS_KEY, "");
            }
        }

        /// <summary>
        /// Обновляет бренд
        /// </summary>
        public async Task UpdateBrandAsync(Brand brand)
        {
            _automobileRepository.UpdateBrand(brand);
            await _automobileRepository.UnitOfWork.SaveChangesAsync();
            await _distributedCache.SetStringAsync(brand.BrandId.ToString(), JsonConvert.SerializeObject(brand));
            await _distributedCache.SetStringAsync(BRANDS_KEY, "");
        }

        /// <summary>
        /// Получает бренд
        /// </summary>
        public async Task<Brand> GetBrandAsync(Guid id)
        {
            var brand = await _distributedCache.GetStringAsync(id.ToString());
            var result = string.IsNullOrEmpty(brand)
                ? await _automobileRepository.GetBrandAsync(id)
                : JsonConvert.DeserializeObject<Brand>(brand);

            return result;
        }

        /// <summary>
        /// Получает бренды
        /// </summary>
        public async Task<List<Brand>> GetBrandsAsync()
        {
            var brands = await _distributedCache.GetStringAsync(BRANDS_KEY);
            var result = string.IsNullOrEmpty(brands)
                ? await _automobileRepository.GetBrandsAsync()
                : JsonConvert.DeserializeObject<List<Brand>>(brands);
            if (string.IsNullOrEmpty(brands))
            {
                await _distributedCache.SetStringAsync(BRANDS_KEY, JsonConvert.SerializeObject(result));
            }

            return result;
        }

        /// <summary>
        /// Добавляет автомобиль
        /// </summary>
        public async Task AddCarAsync(Car car)
        {
            var carUpdate = await _automobileRepository.GetCarAsync(car.Title, car.BrandId);
            var brandJson = await _distributedCache.GetStringAsync(car.BrandId.ToString());
            var brand = string.IsNullOrEmpty(brandJson)
                ? await _automobileRepository.GetBrandAsync(car.BrandId)
                : JsonConvert.DeserializeObject<Brand>(brandJson);
            if (carUpdate == null && brand != null)
            {
                _automobileRepository.AddCar(car);
                await _automobileRepository.UnitOfWork.SaveChangesAsync();
                car.Brand = brand;
                await _distributedCache.SetStringAsync(car.CarId.ToString(), JsonConvert.SerializeObject(car));
                await _distributedCache.SetStringAsync(CARS_KEY, "");
            }
        }

        /// <summary>
        /// Удаляет автомобиль
        /// </summary>
        public async Task RemoveCarAsync(Car car)
        {
            if ((await _automobileRepository.GetCarAsync(car.CarId)) != null)
            {
                _automobileRepository.RemoveCar(car);
                await _automobileRepository.UnitOfWork.SaveChangesAsync();
                await _distributedCache.RemoveAsync(car.CarId.ToString());
                await _distributedCache.SetStringAsync(CARS_KEY, "");
            }
        }

        /// <summary>
        /// Обновляет автомобиль
        /// </summary>
        public async Task UpdateCarAsync(Car car)
        {
            var carUpdate = await _automobileRepository.GetCarAsync(car.CarId);
            if (carUpdate != null)
            {
                car.BrandId = carUpdate.BrandId;
                _automobileRepository.UpdateCar(car);
                await _automobileRepository.UnitOfWork.SaveChangesAsync();
                car.Brand = carUpdate.Brand;
                await _distributedCache.SetStringAsync(car.CarId.ToString(), JsonConvert.SerializeObject(car));
                await _distributedCache.SetStringAsync(CARS_KEY, "");
            }
        }

        /// <summary>
        /// Возвращает автомобиль
        /// </summary>
        public async Task<Car> GetCarAsync(Guid id)
        {
            var car = await _distributedCache.GetStringAsync(id.ToString());
            var result = string.IsNullOrEmpty(car)
                ? await _automobileRepository.GetCarAsync(id)
                : JsonConvert.DeserializeObject<Car>(car);
            return result;
        }

        /// <summary>
        /// Возвращает список автомобилей
        /// </summary>
        public async Task<List<Car>> GetCarsAsync()
        {
            var cars = await _distributedCache.GetStringAsync(CARS_KEY);
            var result = string.IsNullOrEmpty(cars)
                ? await _automobileRepository.GetCarsAsync()
                : JsonConvert.DeserializeObject<List<Car>>(cars);

            if (string.IsNullOrEmpty(cars))
            {
                await _distributedCache.SetStringAsync(CARS_KEY, JsonConvert.SerializeObject(result));
            }

            return result;
        }
        #endregion
    }
}
