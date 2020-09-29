using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication8.Models
{
    /// <summary>
    /// Класс описывает бронирование клиентом сеанса.
    /// </summary>
    public class Booking
    {
        /// <summary>
        /// Идентификатор брони.
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Имя покупателя.
        /// </summary>
        public string Customer { get; set; }

        /// <summary>
        /// Забронированный сеанс.
        /// </summary>
        [ForeignKey("Session_Id")]
        public Session Session { get; set; }
    }
}
