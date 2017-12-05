using AutoRepository.Data.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AutoRepository.Services.Services.Interfaces
{
    /// <summary>
    /// Обработчик для автомобилей
    /// </summary>
    public interface IAutomobileHandler
    {
        /// <summary>
        /// Добавляет бренд
        /// </summary>
        Task CreateBrandAsync(string title);

        /// <summary>
        /// Удаляет бренд
        /// </summary>
        Task DeleteBrandAsync(Guid brandId);

        /// <summary>
        /// Изменяет бренд
        /// </summary>
        Task UpdateBrandAsync(Guid brandId, string title);

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
        Task CreateCarAsync(string title, Guid brandId);

        /// <summary>
        /// Удаляет автомобиль
        /// </summary>
        Task DeleteCarAsync(Guid carId);

        /// <summary>
        /// Изменяет автомобиль
        /// </summary>
        Task UpdateCarAsync(Guid carId, string title);

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
