using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NewCateringWeb.Models
{
    public class Menu
    {
        public int ID { get; set; }

        public String Name { get; set; }

        public String Img { get; set; }

        public float Price { get; set; }

        public String Composition { get; set; }

        public String ShortDesc { get; set; }

        public String LongDesc { get; set; }
    }
}