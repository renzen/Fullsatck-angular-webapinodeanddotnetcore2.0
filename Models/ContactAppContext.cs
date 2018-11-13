using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using contact_app.Models;

namespace contact_app.Models
{
    public class ContactAppContext : DbContext
    {
          public ContactAppContext(DbContextOptions<ContactAppContext> options)
            : base(options)
        {
        }

        //public DbSet<Contact> Contact { get; set; }
        public DbSet<Users> Users { get; set; }
        public DbSet<UserDetails> Userdetails { get; set; }
        public DbSet<Address> Address { get; set; }
        public DbSet<GeoLoc> GeoLoc { get; set; }

    }
}