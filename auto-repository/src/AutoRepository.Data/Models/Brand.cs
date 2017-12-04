using System;
using System.ComponentModel.DataAnnotations;

namespace AutoRepository.Data.Models
{
    /// <summary>
    /// Бренд
    /// </summary>
    public class Brand
    {
        /// <summary>
        /// Id Бренда
        /// </summary>
        [Key]
        public Guid BrandId { get; set; }

        /// <summary>
        /// Название бренда
        /// </summary>
        [Required]
        public string Title { get; set; }
    }
}
