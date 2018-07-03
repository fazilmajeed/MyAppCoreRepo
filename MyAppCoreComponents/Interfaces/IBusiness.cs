using System;
using System.Collections.Generic;
using System.Text;

namespace MyAppCore.MyAppCoreComponents.Interfaces
{
    public interface IBusiness<T> : CoreBusiness<T> where T : class
    {
        string GetInfo();
    }
}
