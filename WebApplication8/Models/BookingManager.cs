using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication8.Models
{
    /// <summary>
    /// Класс для работы с бронями сеансов.
    /// </summary>
    public class BookingManager
    {
        private AppDbContext dbContext;

        public BookingManager(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        /// <summary>
        /// Метод бронирует сеанс для покупателя.
        /// </summary>
        /// <param name="session"></param>
        /// <param name="customer"></param>
        public void BookingSession(Session session, string customer)
        {
            // Добавление брони в бд.
            this.dbContext.Bookings.Add(
                new Booking()
                {
                    Session = session,
                    Customer = customer
                });

            // Сохранение изменений в бд.
            this.dbContext.SaveChanges();
        }
    }
}
