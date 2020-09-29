using System;
using System.ComponentModel.DataAnnotations;

namespace WebApplication8.Models
{
    public class SignUpSessionViewModel
    {
        [Display(Name = "Название фильма")]
        public string FilmName { get; set; }
        [Display(Name = "Дата фильма")]
        public DateTime FilmTime { get; set; }
        [Display(Name = "Имя покупателя")]
        [DataType(DataType.Text)]
        public string Customer { get; set; }
    }
}
