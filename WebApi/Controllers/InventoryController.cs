using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CC.MyServicesPortal.Repository;
using CC.MyServicesPortal.Repository.Contract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApi.Models;
using WebAPI.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi.Controllers
{   [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class InventoryController : ControllerBase
    {
        private readonly ICompanyRepository _companyRepository;
        public InventoryController(ICompanyRepository companyRepository)
        {
            _companyRepository = companyRepository;
        }

        //[Authorize(Roles = "Administrator, User")]
        [HttpGet]
        public IEnumerable<string> Get()
        {
            var xxx = _companyRepository.GetAll();

            return new string[] { "value1", "value2" };
        }

        // POST: api/Inventory
        [Authorize(Roles = "Administrator")]
        [HttpPost]
        public void Post([FromBody] User value)
        {
        }
    }
}