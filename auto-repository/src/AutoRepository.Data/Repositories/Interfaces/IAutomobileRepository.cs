using AutoRepository.Data.Infrastructure;
using AutoRepository.Data.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AutoRepository.Data.Repositories.Interfaces
{
    /// <summary>
    /// Репозиторий автомобилей
    /// </summary>
    public interface IAutomobileRepository
    {
        /// <summary>
        /// Добавляет бренд
        /// </summary>
        void AddBrand(Brand brand);

        /// <summary>
        /// Удаляет бренд
        /// </summary>
        void RemoveBrand(Brand brand);

        /// <summary>
        /// Изменяет бренд
        /// </summary>
        void UpdateBrand(Brand brand);

        /// <summary>
        /// Возаращает бренд по Id
        /// </summary>
        /// <param name="brandId"></param>
        /// <returns></returns>
        Task<Brand> GetBrandAsync(Guid brandId);

        /// <summary>
        /// Возвращает бренд по названию
        /// </summary>
        /// <returns></returns>
        Task<Brand> GetBrandAsync(string title);

        /// <summary>
        /// Возвращает список брендов
        /// </summary>
        /// <returns></returns>
        Task<List<Brand>> GetBrandsAsync();

        /// <summary>
        /// Добавляет автомобиль
        /// </summary>
        void AddCar(Car car);

        /// <summary>
        /// Удаляет автомобиль
        /// </summary>
        void RemoveCar(Car car);

        /// <summary>
        /// Изменяет автомобиль
        /// </summary>
        void UpdateCar(Car car);

        /// <summary>
        /// Возаращает автомобиль по Id
        /// </summary>
        /// <returns></returns>
        Task<Car> GetCarAsync(Guid carId);

        /// <summary>
        /// Возвращает автомобиль по названию и бренду
        /// </summary>
        /// <returns></returns>
        Task<Car> GetCarAsync(string title, Guid brandId);

        /// <summary>
        /// Возвращает список автомобилей
        /// </summary>
        /// <returns></returns>
        Task<List<Car>> GetCarsAsync();

        /// <summary>
        /// Интерфейс для сохранения данных
        /// </summary>
        IUnitOfWork UnitOfWork { get; }
    }
}
