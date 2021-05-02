using CC.MyServicesPortal.Domain;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace CC.MyServicesPortal.Repository.Contract
{
    public interface ICompanyRepository : IRepository<Companies>
    {
        bool CreateXXZ();//custom
    }
}
