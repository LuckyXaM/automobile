using AutoRepository.Data.Infrastructure;
using AutoRepository.Data.Models;
using AutoRepository.Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AutoRepository.Data.Repositories.Logic
{
    /// <summary>
    /// Репозиторий автомобилей
    /// </summary>
    public class AutomobileRepository : IAutomobileRepository
    {
        #region Свойства

        private AutoRepositoryContext _autoRepositoryContext;

        /// <summary>
        /// Интерфейс для сохранения данных
        /// </summary>
        public IUnitOfWork UnitOfWork
        {
            get
            {
                return _autoRepositoryContext;
            }
        }

        #endregion Конструктор

        #region

        /// <summary>
        /// Конструктор по-умолчанию
        /// </summary>
        public AutomobileRepository(
            AutoRepositoryContext autoRepositoryContext
            )
        {
            _autoRepositoryContext = autoRepositoryContext;
        }

        #endregion

        #region Методы

        /// <summary>
        /// Добавляет бренд
        /// </summary>
        public void AddBrand(Brand brand)
        {
            _autoRepositoryContext.Brands.Add(brand);
        }

        /// <summary>
        /// Удаляет бренд
        /// </summary>
        public void RemoveBrand(Brand brand)
        {
            _autoRepositoryContext.Brands.Remove(brand);
        }

        /// <summary>
        /// Изменяет бренд
        /// </summary>
        public void UpdateBrand(Brand brand)
        {
            _autoRepositoryContext.Brands.Update(brand);
        }

        /// <summary>
        /// Возаращает бренд по Id
        /// </summary>
        /// <returns></returns>
        public async Task<Brand> GetBrandAsync(Guid brandId)
        {
            var result = await _autoRepositoryContext.Brands.AsNoTracking()
                .FirstOrDefaultAsync(b => b.BrandId == brandId);

            return result;
        }

        /// <summary>
        /// Возвращает бренд по названию
        /// </summary>
        /// <returns></returns>
        public async Task<Brand> GetBrandAsync(string title)
        {
            var result = await _autoRepositoryContext.Brands.AsNoTracking()
                .FirstOrDefaultAsync(b => b.Title == title);

            return result;
        }

        /// <summary>
        /// Возвращает список брендов
        /// </summary>
        /// <returns></returns>
        public async Task<List<Brand>> GetBrandsAsync()
        {
            var result = await _autoRepositoryContext.Brands.AsNoTracking()
                .ToListAsync();

            return result;
        }

        /// <summary>
        /// Добавляет автомобиль
        /// </summary>
        public void AddCar(Car car)
        {
            _autoRepositoryContext.Cars.Add(car);
        }

        /// <summary>
        /// Удаляет автомобиль
        /// </summary>
        public void RemoveCar(Car car)
        {
            _autoRepositoryContext.Cars.Remove(car);
        }

        /// <summary>
        /// Изменяет автомобиль
        /// </summary>
        public void UpdateCar(Car car)
        {
            _autoRepositoryContext.Cars.Update(car);
        }

        /// <summary>
        /// Возаращает автомобиль по Id
        /// </summary>
        /// <returns></returns>
        public async Task<Car> GetCarAsync(Guid carId)
        {
            var result = await _autoRepositoryContext.Cars.AsNoTracking()
                .Include(c => c.Brand)
                .FirstOrDefaultAsync(b => b.CarId == carId);

            return result;
        }

        /// <summary>
        /// Возвращает автомобиль по названию и бренду
        /// </summary>
        /// <returns></returns>
        public async Task<Car> GetCarAsync(string title, Guid brandId)
        {
            var result = await _autoRepositoryContext.Cars.AsNoTracking()
                .Include(c => c.Brand)
                .FirstOrDefaultAsync(b => b.Title == title && b.BrandId == brandId);

            return result;
        }

        /// <summary>
        /// Возвращает список автомобилей
        /// </summary>
        /// <returns></returns>
        public async Task<List<Car>> GetCarsAsync()
        {
            var result = await _autoRepositoryContext.Cars.AsNoTracking()
                .Include(c => c.Brand)
                .ToListAsync();

            return result;
        }

        #endregion
    }
}
