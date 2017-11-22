/*
Author          : Sr Programmer Analyst Oleg Gorlov
Description:	: Web API with ASP.NET Core MVC controller to access SQL database table . 
                : Database context is the main class that coordinates Entity Framework functionality .NET Core
Copyright       : GMedia-IT-Consulting 
email           : oleg_gorlov@yahoo.com
Date            : 05/05/2017
Release         : 1.0.0
Comment         : Implementation MVC6 .NET Core 2

 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using SmartSystems.Models.Property;
using SmartSystems.DAL;
using SmartSystems.Models;

namespace SmartSystems.Controllers
{
    [Produces("application/json")]
	[Route("api/BrokerageBrokers")]
	public class BrokerageBrokersController : Controller
    {
        private readonly ILogger<BrokerageController> _logger;
        private readonly PropertyDbContext _context;

		public BrokerageBrokersController(PropertyDbContext context)
		{
			_context = context;
		}

        // GET: api/values
        [HttpGet]
        [Route("Brokerage")]
        public IEnumerable<pBrokerage> GetBrokerage() 
		{
            if (this.User.Identity.IsAuthenticated)
            {
                return _context.pBrokerage;
            }
            else
            {
                return null;
            }
		}

        // GET: api/Brokerage/5
        [HttpGet("{id}")]
        [Route("Brokerage/{id}")]
        public pBrokerage GetBrokerage(int id)
        {

            return _context.pBrokerage
                .Where(pBrokerage => pBrokerage.pBrokerageId == id).SingleOrDefault();
        }

        // GET: api/values

        [HttpGet]
        [Route("Brokers")]
        public IEnumerable<pBroker> GetBroker()
		{
			return _context.pBroker;

		}



        // GET: api/Brokers/5
        [HttpGet("{id}")]
        [Route("Brokers/{id}")]
        public IEnumerable<pBroker> GetBroker(int id) 
        {
            return _context.pBroker
              .Where(pBroker => pBroker.pBrokerageId == id)
              .ToList();
        }
    }
}
