using System;
using System.Collections.Generic;
using System.Text;
using MyAppCore.Common;
using MyAppCore.MyAppCoreComponents.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MyAppCore.MyAppCoreComponents.Core
{
    public class CoreBusiness<T> : GenericRepository<T>, Interfaces.CoreBusiness<T> where T : class
    {
        DbContext _dbcontext;
        public CoreBusiness(DbContext dbcontext) : base(dbcontext)
        {
            _dbcontext = dbcontext;
        }
        public virtual List<ValidationResult> ValidateEntity(T t)
        {
            return new List<ValidationResult>();
        }
    }
}
