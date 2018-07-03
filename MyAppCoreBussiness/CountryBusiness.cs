using MyAppCore.MyAppCoreComponents.Interfaces;
using MyAppCore.MyAppCoreDb.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using MyAppCore.MyAppCoreComponents.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MyAppCore.MyAppCoreDb.DbContexts;

namespace MyAppCoreBussiness
{
    public class CountryBusiness : MyAppCore.MyAppCoreComponents.Core.CoreBusiness<Country>, IBusiness<Country>
    {
        DbContext _dbcontext;
        private IConfiguration _configuration;
        public CountryBusiness(IConfiguration configuration) : base(new MyAppCoreContext(configuration))
        {
            
            _configuration = configuration;
        }

        public virtual string GetInfo()
        {
            return "This is from client business";
        }
    }
}
