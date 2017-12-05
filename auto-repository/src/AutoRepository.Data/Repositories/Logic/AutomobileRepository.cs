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
        public void CreateBrand(Brand brand)
        {
            _autoRepositoryContext.Brands.Add(brand);
            _autoRepositoryContext.SaveChanges();
        }

        /// <summary>
        /// Удаляет бренд
        /// </summary>
        public void DeleteBrand(Brand brand)
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
        /// <param name="brandId"></param>
        /// <returns></returns>
        public async Task<Brand> GetBrandAsync(Guid brandId)
        {
            var result = await _autoRepositoryContext.Brands.FirstOrDefaultAsync(b => b.BrandId == brandId);

            return result;
        }

        /// <summary>
        /// Возвращает список брендов
        /// </summary>
        /// <returns></returns>
        public async Task<List<Brand>> GetBrandsAsync()
        {
            var result = await _autoRepositoryContext.Brands.ToListAsync();

            return result;
        }
        
        /// <summary>
        /// Добавляет автомобиль
        /// </summary>
        public void CreateCar(Car car)
        {
            //var brand = new Brand {
            //    Title = title
            //};
            _autoRepositoryContext.Cars.Add(car);
        }

        /// <summary>
        /// Удаляет автомобиль
        /// </summary>
        public void DeleteCar(Car car)
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
        /// <param name="carId"></param>
        /// <returns></returns>
        public async Task<Car> GetCarAsync(Guid carId)
        {
            var result = await _autoRepositoryContext.Cars.FirstOrDefaultAsync(b => b.CarId == carId);

            return result;
        }

        /// <summary>
        /// Возвращает список автомобилей
        /// </summary>
        /// <returns></returns>
        public async Task<List<Car>> GetCarsAsync()
        {
            var result = await _autoRepositoryContext.Cars.ToListAsync();

            return result;
        }

        #endregion
    }
}
