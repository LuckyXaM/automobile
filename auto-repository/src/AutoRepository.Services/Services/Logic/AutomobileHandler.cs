using AutoRepository.Data.Models;
using AutoRepository.Data.Repositories.Interfaces;
using AutoRepository.Data.Storages.Interfaces;
using AutoRepository.Services.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AutoRepository.Services.Services.Logic
{
    /// <summary>
    /// Обработчик для автомобилей
    /// </summary>
    public class AutomobileHandler : IAutomobileHandler
    {
        #region Свойства

        private readonly IAutomobileStorage _automobileStorage;

        #endregion

        #region Конструкторы

        /// <summary>
        /// Конструктор по-умолчанию
        /// </summary>
        public AutomobileHandler(
            IAutomobileStorage automobileStorage
            )
        {
            _automobileStorage = automobileStorage;
        }

        #endregion

        #region Методы

        /// <summary>
        /// Добавляет бренд
        /// </summary>
        public async Task AddBrandAsync(string title)
        {
            var result = new Brand
            {
                BrandId = Guid.NewGuid(),
                Title = title
            };

            await _automobileStorage.AddBrandAsync(result);
        }

        /// <summary>
        /// Удаляет бренд
        /// </summary>
        public async Task RemoveBrandAsync(Guid brandId)
        {
            var brand = new Brand
            {
                BrandId = brandId
            };

            await _automobileStorage.RemoveBrandAsync(brand);
        }

        /// <summary>
        /// Изменяет бренд
        /// </summary>
        public async Task UpdateBrandAsync(Guid brandId, string title)
        {
            var brand = new Brand
            {
                BrandId = brandId,
                Title = title
            };

            await _automobileStorage.UpdateBrandAsync(brand);
        }

        /// <summary>
        /// Возаращает бренд по Id
        /// </summary>
        /// <returns></returns>
        public async Task<Brand> GetBrandAsync(Guid brandId)
        {
            var result = await _automobileStorage.GetBrandAsync(brandId);

            return result;
        }

        /// <summary>
        /// Возвращает список брендов
        /// </summary>
        /// <returns></returns>
        public async Task<List<Brand>> GetBrandsAsync()
        {
            var result = await _automobileStorage.GetBrandsAsync();

            return result;
        }

        /// <summary>
        /// Добавляет автомобиль
        /// </summary>
        public async Task AddCarAsync(string title, Guid brandId)
        {
            var car = new Car
            {
                Title = title,
                BrandId = brandId
            };

            await _automobileStorage.AddCarAsync(car);
        }

        /// <summary>
        /// Удаляет автомобиль
        /// </summary>
        public async Task RemoveCarAsync(Guid carId)
        {
            var car = new Car
            {
                CarId = carId
            };
            
            await _automobileStorage.RemoveCarAsync(car);
        }

        /// <summary>
        /// Изменяет автомобиль
        /// </summary>
        public async Task UpdateCarAsync(Guid carId, string title)
        {
            var car = new Car
            {
                CarId = carId,
                Title = title
            };

            await _automobileStorage.UpdateCarAsync(car);
        }

        /// <summary>
        /// Возаращает автомобиль по Id
        /// </summary>
        /// <returns></returns>
        public async Task<Car> GetCarAsync(Guid carId)
        {
            var result = await _automobileStorage.GetCarAsync(carId);

            return result;
        }

        /// <summary>
        /// Возвращает список автомобилей
        /// </summary>
        /// <returns></returns>
        public async Task<List<Car>> GetCarsAsync()
        {
            var result = await _automobileStorage.GetCarsAsync();

            return result;
        }

        #endregion
    }
}
