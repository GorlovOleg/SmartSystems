/*
Author          : Sr Programmer Analyst Oleg Gorlov
Description:	: Web API with ASP.NET Core MVC controller to access SQL database table . 
                : Database context is the main class that coordinates Entity Framework functionality .NET Core
Copyright       : GMedia-IT-Consulting 
email           : oleg_gorlov@yahoo.com
Date            : 05/05/2017
Release         : 1.0.0
Comment         : Implementation MVC6 .NET Core March 2017 Update - 1.1.1 Released 3/7/2017

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



namespace SmartSystems.Controllers
{
    [Produces("application/json")]
    [Route("api/Broker")]
    public class BrokerController : Controller 
    {
        private readonly ILogger<BrokerController> _logger;

        private readonly PropertyDbContext _context;

            public BrokerController(PropertyDbContext context) 
            {
                _context = context;
            }

            // GET: api/Broker
            [HttpGet]
            public IEnumerable<pBroker> GetBroker() 
            {

        //    SELECT[s].[sCompanyId], [s].[EffectiveDate], [s].[LastUpdated], [s].[sCompanyName], [s].[sDBA], [s].[sTAX_Number]
        //FROM[sCompany] AS[s]


                return _context.pBroker;
            }

            // GET: api/Broker/5
            [HttpGet("{id}")]
            public async Task<IActionResult> GetBroker([FromRoute] int id) 
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var item = await _context.pBroker.SingleOrDefaultAsync(m => m.pBrokerId == id);

                if (item == null)
                {
                    return NotFound();
                }

                return Ok(item);
            }

            // PUT: api/Broker/5
            [HttpPut("{id}")]
            public async Task<IActionResult> PutBroker([FromRoute] int id, [FromBody] pBroker item)
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                if (id != item.pBrokerId)
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
                    if (!BrokerExists(id))
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

        // POST: api/Broker
        [HttpPost]
            public async Task<IActionResult> PostBroker([FromBody] pBroker item)
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                _context.pBroker.Add(item);
                await _context.SaveChangesAsync();

                return CreatedAtAction("GetBroker", new { id = item.pBrokerId }, item);
            }

        // DELETE: api/Broker/5
        [HttpDelete("{id}")]
            public async Task<IActionResult> DeleteBroker([FromRoute] int id)
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var item = await _context.pBroker.SingleOrDefaultAsync(m => m.pBrokerId == id);
                if (item == null)
                {
                    return NotFound();
                }

                _context.pBroker.Remove(item);
                await _context.SaveChangesAsync();

                return Ok(item);
            }

            private bool BrokerExists(int id) 
            {
                return _context.pBroker.Any(e => e.pBrokerId == id);
            }
        }
    }