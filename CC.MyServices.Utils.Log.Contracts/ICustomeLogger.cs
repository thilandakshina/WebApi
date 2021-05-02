using System;
using System.Collections.Generic;
using System.Text;

namespace CC.MyServices.Utils.Log.Contracts
{
    public interface ICustomeLogger
    {
        bool LogError(string err);
    }
}
