using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace NewCateringWeb.Models
{
    public class Purchase
    {
        public int ID { get; set; }

        [Display(Name = "Покупатель")]
        [Required(ErrorMessage = "Поле должно быть заполнено")]
        [ForeignKey("Client")]
        public int Client_ID { get; set; }
        
        public Client Client { get; set; }

        [Required(ErrorMessage = "Поле должно быть заполнено")]
        public DateTime Date_Purch { get; set; }

        [Required(ErrorMessage = "Поле должно быть заполнено")]
        public bool Deliver { get; set; }

        [Required(ErrorMessage = "Поле должно быть заполнено")]
        public string Status_Purch { get; set; }

        [Required(ErrorMessage = "Поле должно быть заполнено")]
        public int TotalPrice { get; set; }

        public string Comment { get; set; }


    }
    
}