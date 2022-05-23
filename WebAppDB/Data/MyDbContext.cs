using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppDB.Models;

namespace WebAppDB.Data
{
    public class MyDbContext : DbContext
    {

        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
        {
        }
        public DbSet<Person> Pepoles { get; set; }
        //
       // public DbSet<PeopleService> Pepole { get; set; }
    }
}
