using System;
using System.Collections.Generic;
using System.Text;
using MyAppCore.MyAppCoreDb.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace MyAppCore.MyAppCoreDb.DbContexts
{
   public class MyAppCoreContext: DbContext
    {
        //public MyAppCoreContext(DbContextOptions<MyAppCoreContext> options)
        //           : base(options)
        //{
        //}

        private IConfiguration _configuration;
        public MyAppCoreContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_configuration.GetConnectionString("MyAppCoreContext"));
        }

        public DbSet<MyAppCore.MyAppCoreDb.Models.Country> Country { get; set; }
    }
}
