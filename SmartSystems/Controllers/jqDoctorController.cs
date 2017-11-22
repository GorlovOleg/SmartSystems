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
using SmartSystems.Models.Hospital;

namespace SmartSystems.Controllers
{
    public class jqDoctorController : Controller
    {
        private string controller = "jqDoctor";
        private readonly PropertyDbContext _context;
        private ILogger<jqDoctorController> Logger { get; set; }


        // GET: Index
        public ActionResult Index()
        {
            string method = "Index";

            ViewBag.Title = "Controller: " + controller;
            ViewBag.Method = "Method: " + method;

            List<Doctor> doctors = _context.Doctors.ToList();

            return View(doctors);

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

            var ReportResults = _context.Doctors.Select(
                _rows => new
                {
                    _rows.DoctorId,
                    _rows.FirstName,
                    _rows.LastName,
                    _rows.Phone,
                    _rows.Email,
                    _rows.ImageUrl,
                    _rows.Hospital
                });

            if (!string.IsNullOrEmpty(firstName))
            {
                ReportResults = ReportResults.Where(p => p.FirstName.Contains(firstName));
            }
            if (!string.IsNullOrEmpty(lastName))
            {
                ReportResults = ReportResults.Where(p => p.LastName.Contains(lastName));
            }

            int totalRecords = ReportResults.Count();
            //int totalRecords2 = ReportResults2.Count();

            var totalPages = (int)Math.Ceiling((float)totalRecords / (float)rows);

            ReportResults = ReportResults.OrderByDescending(s => s.FirstName);
            ReportResults = ReportResults.Skip(pageIndex * pageSize).Take(pageSize);

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
        public string Create([Bind("FirstName", "LastName", "Phone", "Email", "ImageUrl", "Hospital")] Doctor doctor)
        {
            string msg;
            try
            {
                if (ModelState.IsValid)
                {
                    msg = " jqDoctor Saved Successfully1";
                    _context.Doctors.Add(doctor);
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
            Doctor doctor = await FindSubscriberAsync(id);
            if (doctor == null)
            {
                Logger.LogInformation("Delete: Item not found {0}", id);
                return NotFound();
            }
            ViewBag.Retry = retry ?? false;
            return View(doctor);
        }

        //---  4.2 Delete ---------------------------------------------
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                Doctor doctor = await FindSubscriberAsync(id);
                _context.Doctors.Remove(doctor);
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
            Doctor doctor = await FindSubscriberAsync(id);
            if (doctor == null)
            {
                return NotFound();
            }
            return View(doctor);
        }

        //--- 5.2 Edit ---------------------------------------------
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, [Bind("FirstName", "LastName")] Doctor doctor)
        {
            try
            {
                doctor.DoctorId = id;
                _context.Doctors.Attach(doctor);
                _context.Entry(doctor).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                ModelState.AddModelError(string.Empty, "Unable to save changes.");
            }
            return View(doctor);
        }

        //--- 6.1 FindSubscriberAsync ---------------------------------------------
        private Task<Doctor> FindSubscriberAsync(int id)
        {
            return _context.Doctors.SingleOrDefaultAsync(doctor => doctor.DoctorId == id);
        }

        //--- GetSubscribersListItems ---------------------------------------------
        private IEnumerable<SelectListItem> GetSubscribersListItems(int selected = -1)
        {
            var tmp = _context.Doctors.ToList();  // Workaround for https://github.com/aspnet/EntityFramework/issues/2246

            // Create authors list for <select> dropdown
            return tmp
                .OrderBy(doctor => doctor.FirstName)
                .Select(doctor => new SelectListItem
                {
                    Text = String.Format("{0}, {1}", doctor.FirstName, doctor.LastName),
                    Value = doctor.DoctorId.ToString(),
                    Selected = doctor.DoctorId == selected
                });
        }

    }
}