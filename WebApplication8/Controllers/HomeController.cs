using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebApplication8.Models;

namespace WebApplication8.Controllers
{
    public class HomeController : Controller
    {
        private AppDbContext dbContext;
        private SessionManager sessionManager;
        private BookingManager bookingManager;

        public HomeController(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
            this.sessionManager = new SessionManager(this.dbContext);
            this.bookingManager = new BookingManager(this.dbContext);
        }

        public IActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Выдача всех сеансов пользователю.
        /// </summary>
        /// <returns></returns>
        public IActionResult MoviePoster()
        {
            // Получение всех доступных сеансов.
            var moviePoster = this.sessionManager.GetSessions();

            return View(moviePoster);
        }

        /// <summary>
        /// Выдача представления пользователю для бронирования.
        /// </summary>
        /// <returns></returns>
        public IActionResult SignUpSession()
        {
            return View();
        }

        [HttpPost]
        /// <summary>
        /// Бронирование сеанса пользователем.
        /// </summary>
        /// <param name="filmName"></param>
        /// <param name="filmTime"></param>
        /// <param name="customer"></param>
        /// <returns></returns>
        public IActionResult SignUpSession(SignUpSessionViewModel signUpModel)
        {
            // Получение сеанса по указаным параметрам
            var session = this.sessionManager.GetSession(signUpModel.FilmName, signUpModel.FilmTime);

            // Проверка на наличие такого сеанса.
            if (session == null)
                return Content("С таким названием или временем нет киносеансов");

            // Бронирование сеанса пользователем.
            this.bookingManager.BookingSession(session, signUpModel.Customer);

            return Content($"Вы записаны на сеанс {signUpModel.FilmName}. Дата: {signUpModel.FilmTime}");
        }
    }
}
