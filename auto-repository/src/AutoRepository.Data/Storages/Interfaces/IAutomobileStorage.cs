using AutoRepository.Data.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AutoRepository.Data.Storages.Interfaces
{
    /// <summary>
    /// Storage для автомобилей
    /// </summary>
    public interface IAutomobileStorage
    {
        /// <summary>
        /// Добавляет бренд
        /// </summary>
        Task AddBrandAsync(Brand brand);

        /// <summary>
        /// Удаляет бренд
        /// </summary>\
        Task RemoveBrandAsync(Brand brand);

        /// <summary>
        /// Обновляет бренд
        /// </summary>
        Task UpdateBrandAsync(Brand brand);

        /// <summary>
        /// Получает бренд
        /// </summary>
        Task<Brand> GetBrandAsync(Guid id);

        /// <summary>
        /// Получает бренды
        /// </summary>
        Task<List<Brand>> GetBrandsAsync();

        /// <summary>
        /// Добавляет автомобиль
        /// </summary>
        Task AddCarAsync(Car car);

        /// <summary>
        /// Удаляет автомобиль
        /// </summary>
        Task RemoveCarAsync(Car car);

        /// <summary>
        /// Обновляет автомобиль
        /// </summary>
        Task UpdateCarAsync(Car car);

        /// <summary>
        /// Возвращает автомобиль
        /// </summary>
        Task<Car> GetCarAsync(Guid id);

        /// <summary>
        /// Возвращает список автомобилей
        /// </summary>
        Task<List<Car>> GetCarsAsync();
    }
}