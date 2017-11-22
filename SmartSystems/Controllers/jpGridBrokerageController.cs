/*
Author          : Sr Programmer Analyst Oleg Gorlov
Description:	: Web API and ASP.NET Core 2 implementation to CRUD jpGrid. 
Copyright       : GMedia-IT-Consulting 
email           : oleg_gorlov@yahoo.com
Date            : 05/05/2017
Release         : 1.0.0
Comment         : Implementation MVC6 .NET Core March 2017 Update - 1.1.1 Released 3/7/2017
                : Script SQL to create storage procedures in file DatabaseSetUp.Sql
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
using static System.Linq.Enumerable;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace SmartSystems.Controllers
{
    public class jpGridBrokerageController : Controller
    {
        private string controller = "jpGridBrokerage";
        private readonly PropertyDbContext _context;
        private ILogger<jpGridBrokerageController> Logger { get; set; }

        // GET: Index
        public ActionResult Index()
        {
            string method = "Index";

            ViewBag.Title = "Controller: " + controller;
            ViewBag.Method = "Method: " + method;

            List<pBrokerage> _pBrokerages = _context.pBrokerage.ToList();

            return View(_pBrokerages);
        }

        //--- 2.2 GetReport ---------------------------------------------
        public JsonResult GetReport(string sidx, string sord, int page, int rows, bool _search, string brokerageName, string street, string city)  //Gets the Report Lists.
        {
            string method = "GetReport";

            ViewBag.Title = "Controller: " + controller;
            ViewBag.Method = "Method: " + method;

            int pageIndex = Convert.ToInt32(page) - 1;
            int pageSize = rows;

            //--- LINQ Method syntax 
            //--- LINQ http://www.tutorialsteacher.com/linq/linq-method-syntax
            //var ReportResults3 = _context.Subscribers.Where(s => s.FirstName == "Tom").ToList<GMedia_IT_ConsultingCanada.Models.Subscriber>();

            var ReportResults = _context.pBrokerage.Select(
                _rows => new
                {
                    _rows.pBrokerageId,
                    _rows.pBrokerageName,
                    _rows.Street,
                    _rows.City,
                    _rows.PostalCode,
                    _rows.Phone,
                    _rows.Website
                });

            if (!string.IsNullOrEmpty(brokerageName))
            {
                ReportResults = ReportResults.Where(p => p.pBrokerageName.Contains(brokerageName));
            }
            if (!string.IsNullOrEmpty(street))
            {
                ReportResults = ReportResults.Where(p => p.Street.Contains(street));
            }
            if (!string.IsNullOrEmpty(city))
            {
                ReportResults = ReportResults.Where(p => p.City.Contains(city));
            }


            int totalRecords = ReportResults.Count();
            //int totalRecords2 = ReportResults2.Count();

            var totalPages = (int)Math.Ceiling((float)totalRecords / (float)rows);


            if (sord.ToUpper() == "DESC")
            {
                ReportResults = ReportResults.OrderByDescending(s => s.pBrokerageName);
                ReportResults = ReportResults.Skip(pageIndex * pageSize).Take(pageSize);
            }

            //if (sord.ToUpper() == "DESC")
            //{
            //    ReportResults = ReportResults.OrderBy(s => s.FirstName);
            //    ReportResults = ReportResults.Skip(pageIndex * pageSize).Take(pageSize);
            //}

            var jsonData = new
            {
                total = totalPages,
                page,
                records = totalRecords,
                rows = ReportResults
            };
            return Json(jsonData);
        }


        //--- 3.1 Create ---------------------------------------------
        public ActionResult Create()
        {
            return View();
        }

        //--- 3.2 Create ---------------------------------------------
        // TODO:insert a new row to the grid logic here
        [HttpPost]
        public string Create([Bind("pBrokerageName", "Street", "City", "PostalCode", "Phone", "Website")] pBrokerage _pBrokerage)
        {
            string msg;
            try
            {
                if (ModelState.IsValid)
                {
                    msg = "Brokerage Saved Successfully";
                    _context.pBrokerage.Add(_pBrokerage);
                    _context.SaveChanges();
                    msg = "Saved Successfully2";
                }
                else
                {
                    msg = "Validation data not successfull";
                }
            }
            catch (Exception ex)
            {
                msg = "Error occured:" + ex.Message;
            }
            return msg;
        }

        //--- 4.1 Delete ---------------------------------------------
        [HttpGet]
        [ActionName("Delete")]
        public async Task<ActionResult> ConfirmDelete(int id, bool? retry)
        {
            pBrokerage _pBrokerage = await FindSubscriberAsync(id);
            if (_pBrokerage == null)
            {
                Logger.LogInformation("Delete: Item not found {0}", id);
                return NotFound();
            }
            ViewBag.Retry = retry ?? false;
            return View(_pBrokerage);
        }

        //---  4.2 Delete ---------------------------------------------
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                pBrokerage _pBrokerage = await FindSubscriberAsync(id);
                _context.pBrokerage.Remove(_pBrokerage);
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                return RedirectToAction("Delete", new { id = id, retry = true });
            }
            return RedirectToAction("Index");
        }


        //--- 5.1 Edit ---------------------------------------------
        [HttpGet]
        public async Task<ActionResult> Edit(int id)
        {
            pBrokerage _pBrokerage = await FindSubscriberAsync(id);
            if (_pBrokerage == null)
            {
                return NotFound();
            }
            return View(_pBrokerage);
        }

        //--- 5.2 Edit ---------------------------------------------
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, [Bind("pBrokerageName", "Street", "City", "PostalCode", "Phone", "Website")] pBrokerage _pBrokerage)
        {
            try
            {
                _pBrokerage.pBrokerageId = id;
                _context.pBrokerage.Attach(_pBrokerage);
                _context.Entry(_pBrokerage).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                ModelState.AddModelError(string.Empty, "Unable to save changes.");
            }
            return View(_pBrokerage);
        }

        //--- 6.1 FindSubscriberAsync ---------------------------------------------
        private Task<pBrokerage> FindSubscriberAsync(int id)
        {
            return _context.pBrokerage.SingleOrDefaultAsync(_pBrokerage => _pBrokerage.pBrokerageId == id);
        }

        //--- GetSubscribersListItems ---------------------------------------------
        private IEnumerable<SelectListItem> GetSubscribersListItems(int selected = -1)
        {
            var tmp = _context.pBrokerage.ToList();  // Workaround for https://github.com/aspnet/EntityFramework/issues/2246

            // Create authors list for <select> dropdown
            return tmp
                .OrderBy(_pBrokerage => _pBrokerage.pBrokerageName)
                .Select(_pBrokerage => new SelectListItem
                {
                    Text = String.Format("{0}, {1}", _pBrokerage.pBrokerageName, _pBrokerage.Street),
                    Value = _pBrokerage.pBrokerageId.ToString(),
                    Selected = _pBrokerage.pBrokerageId == selected
                });
        }
    }
}