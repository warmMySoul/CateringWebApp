using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace NewCateringWeb.Models.Conetexts
{
    public class ClientContext : DbContext
    {
        public ClientContext() :
            base("DefaultConnection")
        { }

        public DbSet<Client> Clients { get; set; }
    }
}