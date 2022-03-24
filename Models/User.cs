﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NewCateringWeb.Models
{
    public class User
    {
        public int ID { get; set; }

        public string Login { get; set; }

        public string Password { get; set; }

        public bool LoggedStatus { get; set; }

        public int Role_ID { get; set; }

        public Role Role { get; set; }
        
    }

    public class Role
    {
        public int ID { get; set; }

        public string Name { get; set; }
    }
}