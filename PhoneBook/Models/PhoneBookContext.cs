using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace PhoneBook.Models
{
    public class PhoneBookContext : DbContext
    {
        public DbSet<Contact> Contacts { get; set; }


        public PhoneBookContext() : base("PhoneBookDB")
        {

        }

    }
}