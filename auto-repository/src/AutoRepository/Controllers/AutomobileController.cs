using Microsoft.AspNetCore.Mvc;
using AutoRepository.Services.Services.Interfaces;
using System.Threading.Tasks;
using System;

namespace AutoRepository.Controllers
{
    /// <summary>
    /// Контроллер для работы с автомобилями
    /// </summary>
    [Route("api/")]
    [ApiExplorerSettings(GroupName = "automobile")]
    public class AutomobileController : Controller
    {
        #region Свойства

        private readonly IAutomobileHandler _automobileHandler;

        #endregion

        #region Конструкторы

        /// <summary>
        /// Конструктор по-умолчанию
        /// </summary>
        /// <param name="automobileHandler"></param>
        public AutomobileController(
            IAutomobileHandler automobileHandler
            )
        {
            _automobileHandler = automobileHandler;
        }

        #endregion

        #region Методы

        /// <summary>
        /// Добавляет бренд
        /// </summary>
        /// <param name="title"></param>
        /// <returns></returns>
        [HttpPost("createbrand/{title}")]
        public async Task CreateBrandAsync(string title)
        {
            await _automobileHandler.CreateBrandAsync(title);
        }

        /// <summary>
        /// Удаляет бренд
        /// </summary>
        /// <param name="brandId"></param>
        /// <returns></returns>
        [HttpPost("deletebrand/{brandId}")]
        public async Task DeleteBrandAsync(Guid brandId)
        {
            await _automobileHandler.DeleteBrandAsync(brandId);
        }

        /// <summary>
        /// Изменяет бренд
        /// </summary>
        /// <param name="brandId"></param>
        /// <param name="title"></param>
        /// <returns></returns>
        [HttpPost("updatebrand/{brandId}/{title}")]
        public async Task UpdateBrandAsync(Guid brandId, string title)
        {
            await _automobileHandler.UpdateBrandAsync(brandId, title);
        }

        /// <summary>
        /// Возвращает бренд по Id
        /// </summary>
        /// <param name="brandId"></param>
        /// <returns></returns>
        [HttpGet("getbrand/{brandId}")]
        public async Task GetBrandAsync(Guid brandId)
        {
            await _automobileHandler.GetBrandAsync(brandId);
        }

        /// <summary>
        /// Возвращает список брендов
        /// </summary>
        /// <returns></returns>
        [HttpGet("getbrands")]
        public async Task GetBrandsAsync()
        {
            await _automobileHandler.GetBrandsAsync();
        }

        /// <summary>
        /// Добавляет автомобиль
        /// </summary>
        /// <param name="title"></param>
        /// <returns></returns>
        [HttpPost("createcar/{title}")]
        public async Task CreateCarAsync(string title)
        {
            await _automobileHandler.CreateCarAsync(title);
        }

        /// <summary>
        /// Удаляет автомобиль
        /// </summary>
        /// <param name="carId"></param>
        /// <returns></returns>
        [HttpPost("deletecar/{carId}")]
        public async Task DeleteCarAsync(Guid carId)
        {
            await _automobileHandler.DeleteCarAsync(carId);
        }

        /// <summary>
        /// Изменяет автомобиль
        /// </summary>
        /// <param name="carId"></param>
        /// <param name="title"></param>
        /// <returns></returns>
        [HttpPost("updatecar/{carId}/{title}")]
        public async Task UpdateCarAsync(Guid carId, string title)
        {
            await _automobileHandler.UpdateCarAsync(carId, title);
        }

        /// <summary>
        /// Возаращает автомобиль по Id
        /// </summary>
        /// <param name="carId"></param>
        /// <returns></returns>
        [HttpGet("getcar/{carId}")]
        public async Task GetCarAsync(Guid carId)
        {
            await _automobileHandler.GetCarAsync(carId);
        }

        /// <summary>
        /// Возвращает список автомобилей
        /// </summary>
        /// <returns></returns>
        [HttpGet("getcars")]
        public async Task GetCarsAsync()
        {
            await _automobileHandler.GetCarsAsync();
        }

        #endregion
    }
}