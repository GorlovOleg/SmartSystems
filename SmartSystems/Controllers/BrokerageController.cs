/*
Author          : Sr Programmer Analyst Oleg Gorlov
Description:	: Web API with ASP.NET Core MVC controller to access SQL database table . 
                : Database context is the main class that coordinates Entity Framework functionality .NET Core
Copyright       : GMedia-IT-Consulting 
email           : oleg_gorlov@yahoo.com
Date            : 05/05/2017
Release         : 1.0.0
Comment         : Implementation MVC6 .NET Core 2
                : User.Identity.IsAuthenticated to lock invoke controller
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
    [Route("api/Brokerage")]
    public class BrokerageController : Controller
    {
        private readonly ILogger<BrokerageController> _logger;
        private readonly PropertyDbContext _context;

        public BrokerageController(PropertyDbContext context)
        {
            _context = context;
        }

        // GET: api/Address
        [HttpGet]
        public IEnumerable<pBrokerage> GetBrokerage()
        {
            // See if the user is logged in
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
        public async Task<IActionResult> GetBrokerage([FromRoute] int id)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var brokerage = await _context.pBrokerage.SingleOrDefaultAsync(m => m.pBrokerageId == id);

            if (brokerage == null)
            {
                return NotFound();
            }

            return Ok(brokerage);
        }

        // PUT: api/Brokerage/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBrokerage([FromRoute] int id, [FromBody] pBrokerage item)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != item.pBrokerageId)
            {
                return BadRequest();
            }

            _context.Entry(item).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BrokerageExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();

        }

        // POST: api/Brokerage
        [HttpPost]
        public async Task<IActionResult> PostBrokerage([FromBody] pBrokerage item)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.pBrokerage.Add(item);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBrokerage", new { id = item.pBrokerageId }, item);

        }

        // DELETE: api/Brokerage/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBrokerage([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var item = await _context.pBroker.SingleOrDefaultAsync(m => m.pBrokerageId == id);
            if (item == null)
            {
                return NotFound();
            }

            _context.pBroker.Remove(item);
            await _context.SaveChangesAsync();

            return Ok(item);
        }

        private bool BrokerageExists(int id)
        {
            return _context.pBrokerage.Any(e => e.pBrokerageId == id);
        }
    }
}