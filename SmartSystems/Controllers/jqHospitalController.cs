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
using SmartSystems.Models.Hospital;
using SmartSystems.DAL;
using SmartSystems.Models;
using static System.Linq.Enumerable;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace SmartSystems.Controllers
{
    public class jqHospitalController : Controller
    {
        public string controller = "jqHospital";
        private readonly PropertyDbContext _context;
        public ILogger<jqHospitalController> Logger { get; set; }

        // GET: Index
        public ActionResult Index()
        {
            var hospital = _context.Hospitals.ToList<Hospital>().First();

            if (string.IsNullOrEmpty(hospital.Street))
            {
                ModelState.AddModelError("Street", "Field is not empty");
            }
            else if (hospital.Street.Length > 50)
            {
                ModelState.AddModelError("Street", "Field cannot be longer than 50 characters.");
            }

            return View(hospital);
        }

        public JsonResult GetReport(string sidx, string sord, int page, int rows, bool _search, string hospitalName, string street)  //Gets the Report Lists.
        {
            int pageIndex = Convert.ToInt32(page) - 1;
            int pageSize = rows;

            var ReportResults = _context.Hospitals.Select(
                _rows => new
                {
                    _rows.HospitalId,
                    _rows.HospitalName,
                    _rows.Street,
                    _rows.City,
                    _rows.PostalCode,
                    _rows.Phone,
                    _rows.Email,
                    _rows.Website
                });

            if (!string.IsNullOrEmpty(hospitalName))
            {
                ReportResults = ReportResults.Where(p => p.Street.Contains(hospitalName));
            }
            if (!string.IsNullOrEmpty(street))
            {
                ReportResults = ReportResults.Where(p => p.City.Contains(street));
            }

            int totalRecords = ReportResults.Count();
            var totalPages = (int)Math.Ceiling(totalRecords / (float)rows);

            //if (sord.ToUpper() == "DESC")
            //{
            //    ReportResults = ReportResults.OrderByDescending(s => s.AddressName);
            //    ReportResults = ReportResults.Skip(pageIndex * pageSize).Take(pageSize);
            //}
            //else
            //{
            //    ReportResults = ReportResults.OrderBy(s => s.AddressName);
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
        public string Create([Bind("HospitalName", "Street", "City", "PostalCode", "Phone", "Email", "Website")] Hospital hospital)
        {
            string msg;
            try
            {
                if (ModelState.IsValid)
                {
                    msg = " Address Saved Successfully1";
                    _context.Hospitals.Add(hospital);
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
            Hospital hospital = await FindHospitalAsync(id);
            if (hospital == null)
            {
                Logger.LogInformation("Delete: Item not found {0}", id);
                return NotFound();
            }
            ViewBag.Retry = retry ?? false;
            return View(hospital);
        }

        //---  4.2 Delete ---------------------------------------------
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                Hospital hospital = await FindHospitalAsync(id);
                _context.Hospitals.Remove(hospital);
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
            Hospital hospital = await FindHospitalAsync(id);
            if (hospital == null)
            {
                return NotFound();
            }
            return View(hospital);
        }

        //--- 5.2 Edit ---------------------------------------------
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, [Bind("HospitalName", "Street", "City", "PostalCode", "Phone", "Email", "Website")] Hospital hospital)
        {
            try
            {
                hospital.HospitalId = id;
                _context.Hospitals.Attach(hospital);
                _context.Entry(hospital).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                ModelState.AddModelError(string.Empty, "Unable to save changes.");
            }
            return View(hospital);
        }

        //--- 6.1 FindSubscriberAsync ---------------------------------------------
        private Task<Hospital> FindHospitalAsync(int id)
        {
            return _context.Hospitals.SingleOrDefaultAsync(hospital => hospital.HospitalId == id);
        }

        //--- GetSubscribersListItems ---------------------------------------------
        private IEnumerable<SelectListItem> GetHospitalsListItems(int selected = -1)
        {
            var tmp = _context.Hospitals.ToList();  // Workaround for https://github.com/aspnet/EntityFramework/issues/2246

            // Create authors list for <select> dropdown
            return tmp
                .OrderBy(hospital => hospital.Street)
                .Select(hospital => new SelectListItem
                {
                    Text = String.Format("{0}, {1}", hospital.Street, hospital.City),
                    Value = hospital.HospitalId.ToString(),
                    Selected = hospital.HospitalId == selected
                });
        }

    }
}
