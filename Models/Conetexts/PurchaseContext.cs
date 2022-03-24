using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace NewCateringWeb.Models.Conetexts
{
    public class PurchaseContext : DbContext
    {
        public PurchaseContext() :
           base("DefaultConnection")
        { }

        public DbSet<Purchase> Purchases { get; set; }
        public DbSet<Client> Clients { get; set; }
    }
}