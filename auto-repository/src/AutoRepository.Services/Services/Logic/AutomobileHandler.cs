using AutoRepository.Data.Infrastructure;
using AutoRepository.Data.Models;
using AutoRepository.Data.Repositories.Interfaces;
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

        private readonly IAutomobileRepository _automobileRepository;
        private readonly IUnitOfWork _unitOfWork;

        #endregion

        #region Конструкторы

        /// <summary>
        /// Конструктор по-умолчанию
        /// </summary>
        public AutomobileHandler(
            IAutomobileRepository automobileRepository,
            IUnitOfWork unitOfWork
            )
        {
            _automobileRepository = automobileRepository;
            _unitOfWork = unitOfWork;
        }

        #endregion

        #region Методы

        /// <summary>
        /// Добавляет бренд
        /// </summary>
        public async Task CreateBrandAsync(string title)
        {
            var brand = new Brand
            {
                Title = title
            };

            _automobileRepository.CreateBrand(brand);
            await _unitOfWork.SaveChangesAsync();
        }

        /// <summary>
        /// Удаляет бренд
        /// </summary>
        public async Task DeleteBrandAsync(Guid brandId)
        {
            var brand = new Brand
            {
                BrandId = brandId
            };

            _automobileRepository.DeleteBrand(brand);
            await _unitOfWork.SaveChangesAsync();
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

            _automobileRepository.UpdateBrand(brand);
            await _unitOfWork.SaveChangesAsync();
        }

        /// <summary>
        /// Возаращает бренд по Id
        /// </summary>
        /// <param name="brandId"></param>
        /// <returns></returns>
        public async Task<Brand> GetBrandAsync(Guid brandId)
        {
            var result = await _automobileRepository.GetBrandAsync(brandId);

            return result;
        }

        /// <summary>
        /// Возвращает список брендов
        /// </summary>
        /// <returns></returns>
        public async Task<List<Brand>> GetBrandsAsync()
        {
            var result = await _automobileRepository.GetBrandsAsync();

            return result;
        }

        /// <summary>
        /// Добавляет автомобиль
        /// </summary>
        public async Task CreateCarAsync(string title)
        {
            var car = new Car
            {
                Title = title
            };

            _automobileRepository.CreateCar(car);
            await _unitOfWork.SaveChangesAsync();
        }

        /// <summary>
        /// Удаляет автомобиль
        /// </summary>
        public async Task DeleteCarAsync(Guid carId)
        {
            var car = new Car
            {
                CarId = carId
            };

            _automobileRepository.DeleteCar(car);
            await _unitOfWork.SaveChangesAsync();
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

            _automobileRepository.UpdateCar(car);
            await _unitOfWork.SaveChangesAsync();
        }

        /// <summary>
        /// Возаращает автомобиль по Id
        /// </summary>
        /// <param name="carId"></param>
        /// <returns></returns>
        public async Task<Car> GetCarAsync(Guid carId)
        {
            var result = await _automobileRepository.GetCarAsync(carId);

            return result;
        }

        /// <summary>
        /// Возвращает список автомобилей
        /// </summary>
        /// <returns></returns>
        public async Task<List<Car>> GetCarsAsync()
        {
            var result = await _automobileRepository.GetCarsAsync();

            return result;
        }

        #endregion
    }
}
