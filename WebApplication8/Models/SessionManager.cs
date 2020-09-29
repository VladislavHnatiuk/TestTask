using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication8.Models
{
    /// <summary>
    /// Класс для работы с сеансами.
    /// </summary>
    public class SessionManager
    {
        private AppDbContext dbContext;

        public SessionManager(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        /// <summary>
        /// Метод отдает из базы данных все сеансы.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Session> GetSessions()
        {
            var moviePoster = this.dbContext.Sessions
                                            .ToList();

            return moviePoster;
        }

        public Session GetSession(string filmName, DateTime filmTime)
        {
            // Получение сеанса по указаным параметрам.
            var session = this.dbContext.Sessions
                                        .Where(x => x.FilmName == filmName &&
                                                   x.SessionDateTime == filmTime)
                                        .FirstOrDefault();

            return session;
        }
    }
}
