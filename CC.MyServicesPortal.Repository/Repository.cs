using CC.MyServices.Utils.Log.Contracts;
using CC.MyServicesPortal.Repository.Contract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace CC.MyServicesPortal.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private ICustomeLogger _logger;
        private readonly MyServicesDbContext _context;

        public Repository(ICustomeLogger logger)
        {
            _context = new MyServicesDbContext();
            _logger = logger;
        }
        public List<T> GetAll()
        {
            return _context.Set<T>().ToList();
        }

    }
}
