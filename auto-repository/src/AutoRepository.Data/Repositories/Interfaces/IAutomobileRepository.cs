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
        void CreateBrand(Brand brand);

        /// <summary>
        /// Удаляет бренд
        /// </summary>
        void DeleteBrand(Brand brand);

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
        /// Возвращает список брендов
        /// </summary>
        /// <returns></returns>
        Task<List<Brand>> GetBrandsAsync();

        /// <summary>
        /// Добавляет автомобиль
        /// </summary>
        void CreateCar(Car car);

        /// <summary>
        /// Удаляет автомобиль
        /// </summary>
        void DeleteCar(Car car);

        /// <summary>
        /// Изменяет автомобиль
        /// </summary>
        void UpdateCar(Car car);

        /// <summary>
        /// Возаращает автомобиль по Id
        /// </summary>
        /// <param name="carId"></param>
        /// <returns></returns>
        Task<Car> GetCarAsync(Guid carId);

        /// <summary>
        /// Возвращает список автомобилей
        /// </summary>
        /// <returns></returns>
        Task<List<Car>> GetCarsAsync();
    }
}
