using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace AccidentRepost.Models
{
    public class EyeWitDbContext : DbContext
    {
        public EyeWitDbContext() : base("name=DefaultConnection")
        {

        }
        public DbSet<Event> Events { get; set; }
    }
}