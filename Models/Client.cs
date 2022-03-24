using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NewCateringWeb.Models
{
    public class Client
    {
        public int ID { get; set; }

        [Display(Name="Имя")]
        [Required(ErrorMessage = "Поле должно быть заполнено")]
        public string Name { get; set; }

        [Display(Name = "Номер телефона")]
        [Required(ErrorMessage = "Поле должно быть заполнено")]
        [StringLength(12, MinimumLength = 11, ErrorMessage ="Неправильно указан номер телефона")]
        public string Telephone { get; set; }

        [Display(Name = "Адрес")]
        public string Index { get; set; }
    }
}