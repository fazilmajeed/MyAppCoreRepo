using System;
using System.Collections.Generic;
using System.Text;
using MyAppCore.Common;

namespace MyAppCore.MyAppCoreComponents.Interfaces
{
    public interface CoreBusiness<T> : ICrudBusiness<T> where T : class
    {

        List<ValidationResult> ValidateEntity(T TObj);


    }
}
