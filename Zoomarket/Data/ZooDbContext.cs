using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Zoomarket.Models;

namespace Zoomarket.Data
{
    public class ZooDbContext : DbContext
    {
        public ZooDbContext() : base()
        {
            Database.CreateIfNotExists();
        }

        public DbSet<Owner> Owners { get; set; }
        public DbSet<Pet> Pets { get; set; }
    }
}