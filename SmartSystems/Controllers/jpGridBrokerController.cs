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
    public class jpGridBrokerController : Controller 
    {
        private string controller = "jpGridBroker";
        private ILogger<jpGridBrokerController> Logger { get; set; }
        private readonly PropertyDbContext _context;

        // GET: Index
        public ActionResult Index()
        {
            string method = "Index";

            ViewBag.Title = "Controller: " + controller;
            ViewBag.Method = "Method: " + method;

                List<pBroker> _pBrokers = _context.pBroker.ToList();

                return View(_pBrokers);

        }

        //--- 2.2 GetReport ---------------------------------------------
        public JsonResult GetReport(string sidx, string sord, int page, int rows, bool _search, string firstName, string lastName)  //Gets the Report Lists.
        {
            string method = "GetReport";

            ViewBag.Title = "Controller: " + controller;
            ViewBag.Method = "Method: " + method;

            int pageIndex = Convert.ToInt32(page) - 1;
            int pageSize = rows;

            //--- LINQ Method syntax 
            //--- LINQ http://www.tutorialsteacher.com/linq/linq-method-syntax
            //var ReportResults3 = _context.Subscribers.Where(s => s.FirstName == "Tom").ToList<GMedia_IT_ConsultingCanada.Models.Subscriber>();

            //var ReportResults = _context.pBrokers.Select(
            //    _rows => new
            //    {
            //        _rows.pBrokerId, 
            //        _rows.FirstName,
            //        _rows.LastName,
            //        _rows.Phone,
            //        _rows.Email,
            //        _rows.ImageUrl,
            //        _rows.pBrokerage 
            //    });

            var ReportResults2 = from _pBrokerage in _context.pBrokerage
                                 join _pBroker in _context.pBroker on _pBrokerage.pBrokerageId equals _pBroker.pBrokerageId
                                 select new
                                 {
                                     _pBroker.pBrokerId, 
                                     _pBroker.FirstName,
                                     _pBroker.LastName,
                                     _pBroker.Phone,
                                     _pBroker.Email, 
                                     _pBroker.ImageUrl,
                                     _pBroker.pBrokerage.pBrokerageName
                                 };
            var ReportResults = ReportResults2.AsEnumerable();



            //---var ReportResults2 = _context.Subscribers.Include(s => s.Hospital).Include(s => s.SubAddress).Include(s => s.SubCredit);
            //var ReportResults2 = _context.Subscribers;

            //            var Table3 = _context.Subscribers.Include(s => s.Hospital).Include(s => s.SubAddress).Include(s => s.SubCredit).Dump("Subscribers");


            if (!string.IsNullOrEmpty(firstName))
            {
                ReportResults = ReportResults.Where(p => p.FirstName.Contains(firstName));
            }
            if (!string.IsNullOrEmpty(lastName))
            {
                ReportResults = ReportResults.Where(p => p.LastName.Contains(lastName));
            }

            //if (!string.IsNullOrEmpty(gender))
            //{
            //    ReportResults = ReportResults.Where(p => p.Gender.Contains(gender));
            //}
            /*
                        //if ((!DateTime..IsNullOrEmpty(birthOfDate))
                        //{
                        //    ReportResults = ReportResults.Where(p => p.DateOfBirth >= birthOfDate);
                        //}

            */
            int totalRecords = ReportResults.Count();
            //int totalRecords2 = ReportResults2.Count();

            var totalPages = (int)Math.Ceiling((float)totalRecords / (float)rows);

            //if (sord.ToUpper() == "DESC")
            //{
                ReportResults = ReportResults.OrderByDescending(s => s.FirstName);
                ReportResults = ReportResults.Skip(pageIndex * pageSize).Take(pageSize);
            //}

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
        public string Create([Bind("FirstName", "LastName", "Phone", "Email", "ImageUrl", "pBrokerage")] pBroker _pBroker )
        {
            string msg;
            try
            {
                if (ModelState.IsValid)
                {
                    msg = "pBroker Saved Successfully";
                    _context.pBroker.Add(_pBroker);
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
            pBroker _pBroker = await FindSubscriberAsync(id);
            if (_pBroker == null)
            {
                Logger.LogInformation("Delete: Item not found {0}", id);
                return NotFound();
            }
            ViewBag.Retry = retry ?? false;
            return View(_pBroker);
        }

        //---  4.2 Delete ---------------------------------------------
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                pBroker _pBroker = await FindSubscriberAsync(id);
                _context.pBroker.Remove(_pBroker);
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
            pBroker _pBroker = await FindSubscriberAsync(id);
            if (_pBroker == null)
            {
                return NotFound();
            }
            return View(_pBroker);
        }

        //--- 5.2 Edit ---------------------------------------------
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, [Bind("FirstName", "LastName")] pBroker _pBroker)
        {
            try
            {
                _pBroker.pBrokerId = id;
                _context.pBroker.Attach(_pBroker);
                _context.Entry(_pBroker).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                ModelState.AddModelError(string.Empty, "Unable to save changes.");
            }
            return View(_pBroker);
        }

        //--- 6.1 FindSubscriberAsync ---------------------------------------------
        private Task<pBroker> FindSubscriberAsync(int id)
        {
            return _context.pBroker.SingleOrDefaultAsync(_pBroker => _pBroker.pBrokerId == id);
        }

        //--- GetSubscribersListItems ---------------------------------------------
        private IEnumerable<SelectListItem> GetSubscribersListItems(int selected = -1)
        {
            var tmp = _context.pBroker.ToList();  // Workaround for https://github.com/aspnet/EntityFramework/issues/2246

            // Create authors list for <select> dropdown
            return tmp
                .OrderBy(_pBroker => _pBroker.FirstName)
                .Select(_pBroker => new SelectListItem
                {
                    Text = String.Format("{0}, {1}", _pBroker.FirstName, _pBroker.LastName),
                    Value = _pBroker.pBrokerId.ToString(),
                    Selected = _pBroker.pBrokerId == selected
                });
        }
    }
}