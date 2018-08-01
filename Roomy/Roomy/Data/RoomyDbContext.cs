using Roomy.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Roomy.Data
{
    public class RoomyDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public DbSet<Room> Rooms { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<RoomFile> RoomFiles { get; set; }

        public RoomyDbContext() : base("Roomy")
        {

        }        
    }
}