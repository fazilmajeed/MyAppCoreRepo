using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MyAppCore.MyAppCoreComponents.Interfaces;
using MyAppCore.MyAppCoreDb.Models;
using MyAppCoreBussiness;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyAppCoreCustomBusiness
{
   public class XeroxCountryBusiness : CountryBusiness, IBusiness<Country>
    {
        //DbContext _dbcontext;
        //private IConfiguration _configuration;
        public XeroxCountryBusiness(IConfiguration configuration) : base(configuration)
        {

            //_configuration = configuration;
        }

        public override string GetInfo()
        {
            return "This is from xerox business";
        }
    }
}
