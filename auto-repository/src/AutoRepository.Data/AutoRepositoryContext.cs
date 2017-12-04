using AutoRepository.Data.Infrastructure;
using AutoRepository.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace AutoRepository.Data
{
    /// <summary>
    /// Контекст для работы с базой данных сервиса "AutoRepository"
    /// </summary>
    public class AutoRepositoryContext : DbContext, IUnitOfWork
    {
        #region Свойства (Таблицы)

        /// <summary>
        /// Бренды
        /// </summary>
        public DbSet<Brand> Brands { get; set; }

        /// <summary>
        /// Автомобили
        /// </summary>
        public DbSet<Car> Cars { get; set; }

        #endregion

        #region Конструктор

        /// <summary>
        /// Контекст для работы с базой данных сервиса "AutoRepository"
        /// </summary>
        public AutoRepositoryContext(DbContextOptions<AutoRepositoryContext> options) : base(options) { }

        #endregion

        #region Методы

        /// <summary>
        /// Обработка создания модели
        /// </summary>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        #endregion
    }
}
