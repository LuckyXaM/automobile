using System;
using System.ComponentModel.DataAnnotations;

namespace AutoRepository.Data.Models
{
    /// <summary>
    /// Автомобили
    /// </summary>
    public class Car
    {
        /// <summary>
        /// Id Автомобиля
        /// </summary>
        [Key]
        public Guid CarId { get; set; }

        /// <summary>
        /// Название автомобиля
        /// </summary>
        [Required]
        public string Title { get; set; }

        /// <summary>
        /// Бренд автомобиля
        /// </summary>
        [Required]
        public Brand Brand { get; set; }
    }
}
