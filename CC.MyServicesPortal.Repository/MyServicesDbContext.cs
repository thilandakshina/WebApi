using CC.MyServicesPortal.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CC.MyServicesPortal.Repository
{
    public class MyServicesDbContext : DbContext
    {
        public MyServicesDbContext()
        {
        }

        public MyServicesDbContext(DbContextOptions<MyServicesDbContext> options) 
            : base(options)
        {

        }
        DbSet<UserAccounts> UserAccounts { get; set; }
        DbSet<Companies> Companies { get; set; }
    }
}
