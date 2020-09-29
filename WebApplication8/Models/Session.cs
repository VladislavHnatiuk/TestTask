using System;

namespace WebApplication8.Models
{
    /// <summary>
    /// Класс описывает кино-сеанс
    /// </summary>
    public class Session
    {
        /// <summary>
        /// Идентификатор сеанса.
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Название фильма.
        /// </summary>
        public string FilmName { get; set; }
        /// <summary>
        /// Дата и время сеанса.
        /// </summary>
        public DateTime SessionDateTime { get; set; }
    }
}
