using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace NewCateringWeb.Models
{
    public class MenuContext : DbContext
    {
        public MenuContext() :
           base("DefaultConnection")
        { }

        public DbSet<Menu> Menu { get; set; }
    }
}