using CC.MyServices.Utils.Log.Contracts;
using CC.MyServicesPortal.Domain;
using CC.MyServicesPortal.Repository.Contract;
using System;
using System.Collections.Generic;
using System.Text;

namespace CC.MyServicesPortal.Repository
{
    public class CompanyRepository : Repository<Companies>, ICompanyRepository
    {
        public CompanyRepository(ICustomeLogger logger) : base(logger)
        {
        }

        public bool CreateXXZ() //custom
        {
            throw new NotImplementedException();
        }
    }
}
 