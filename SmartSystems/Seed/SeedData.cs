/*
Author          : Sr Programmer Analyst Oleg Gorlov
Description:	: First population Database if not exist.
Copyright       : GMedia-IT-Consulting 
email           : oleg_gorlov@yahoo.com
Date            : 05/05/2017
Release         : 1.0.0
Comment         : Implementation MVC6 .NET Core March 2017 Update - 1.1.1 Released 3/7/2017
                : Script SQL to create storage procedures in file DatabaseSetUp.Sql
 */
using System;
using SmartSystems.Models.Hospital;
using SmartSystems.DAL;
using Microsoft.AspNetCore.Builder;

namespace SmartSystems.Seed
{
    public static class DataExtensions
    {
        private static  PropertyDbContext _context;

        public static void SeedData(this IApplicationBuilder app)
        {

            //--- Dependency injection (DI) inside
   
                #region Hospital
                _context.Hospitals.AddRange
                (

                    //new Hospital { HospitalId = 1, HospitalName = "Baycrest Health Sciences", Street = "3560 Bathurst Street", City = "Toronto", PostalCode = "M6A 2E1", Phone = "416-785-2500", Email = "Carson_Alexander@hotmail.com", Website = "http://www.baycrest.org/", LastUpdated = DateTime.Now },
                    //new Hospital { HospitalId = 2, HospitalName = "Centre for Addiction and Mental Health", Street = "1001 Queen Street W", City = "Toronto", PostalCode = "M6J 1H4", Phone = "416-595-6111", Email = "Meredith_Alonso@hotmail.com", Website = "http://www.camh.ca/", LastUpdated = DateTime.Now },
                    //new Hospital { HospitalId = 3, HospitalName = "Mount Sinai Hospital", Street = "600 University Avenue", City = "Toronto", PostalCode = "M5G 1X5", Phone = "416-596-4200", Email = "Arturo_Anandy@hotmail.com", Website = "http://www.mountsinai.on.ca/", LastUpdated = DateTime.Now },
                    //new Hospital { HospitalId = 4, HospitalName = "North York General Hospital", Street = "4001 Leslie Street E", City = "Toronto", PostalCode = "M2K 1E1", Phone = "416-756-6507", Email = "Gytisy_Barzdukas@hotmail.com", Website = "http://www.nygh.on.ca/", LastUpdated = DateTime.Now },
                    //new Hospital { HospitalId = 5, HospitalName = "Markham Stouffville", Street = "381 Church Street", City = "Markham", PostalCode = "L3P 7P3", Phone = "905-472-7000", Email = "Yany_Li@hotmail.com", Website = "http://www.msh.on.ca/", LastUpdated = DateTime.Now },
                    //new Hospital { HospitalId = 6, HospitalName = "Rouge Valley Centenary", Street = "2867 Ellesmere Rd, Scarborough", City = "Scarborough", PostalCode = "M1E 4B9", Phone = "416-284-8131", Email = "Peggy_Justice@hotmail.com", Website = "http://www.rougevalley.ca/", LastUpdated = DateTime.Now },
                    //new Hospital { HospitalId = 7, HospitalName = "Bridgepoint Health", Street = "14 St Matthews Rd", City = "Toronto", PostalCode = "M4M 2B5", Phone = "416-461-8251", Email = "Laura_Norman@hotmail.com", Website = "http://www.bridgepointhealth.ca/", LastUpdated = DateTime.Now },
                    //new Hospital { HospitalId = 8, HospitalName = "Trillium Health Partners", Street = "2200 Eglinton Ave W", City = "Mississauga", PostalCode = "L5M 2N1", Phone = "905-813-2200", Email = "Nike_Saman@hotmail.com", Website = "http://trilliumhealthpartners.ca/", LastUpdated = DateTime.Now },
                    //new Hospital { HospitalId = 9, HospitalName = "Humber River Hospital", Street = "2111 Finch Ave W", City = "North York", PostalCode = "M3N 1N1", Phone = "416-744-2500", Email = "Tom_Cruise@hotmail.com", Website = "http://www.hrh.ca/", LastUpdated = DateTime.Now },
                    //new Hospital { HospitalId = 10, HospitalName = "Shouldice Hospital", Street = "7750 Bayview Avenue", City = "Thornhill", PostalCode = "M3N 1N1", Phone = "289-807-0024", Email = "Nikole_Kidman@hotmail.com", Website = "http://www.shouldice.com/", LastUpdated = DateTime.Now }

                    new Hospital {HospitalName = "Baycrest Health Sciences",                Street = "3560 Bathurst Street", City = "Toronto", PostalCode = "M6A 2E1", Phone = "416-785-2500", Email = "Carson_Alexander@hotmail.com", Website = "http://www.baycrest.org/", LastUpdated = DateTime.Now },
                    new Hospital {HospitalName = "Centre for Addiction and Mental Health",  Street = "1001 Queen Street W", City = "Toronto", PostalCode = "M6J 1H4", Phone = "416-595-6111", Email = "Meredith_Alonso@hotmail.com", Website = "http://www.camh.ca/", LastUpdated = DateTime.Now },
                    new Hospital {HospitalName = "Mount Sinai Hospital",                    Street = "600 University Avenue", City = "Toronto", PostalCode = "M5G 1X5", Phone = "416-596-4200", Email = "Arturo_Anandy@hotmail.com", Website = "http://www.mountsinai.on.ca/", LastUpdated = DateTime.Now },
                    new Hospital {HospitalName = "North York General Hospital",             Street = "4001 Leslie Street E", City = "Toronto", PostalCode = "M2K 1E1", Phone = "416-756-6507", Email = "Gytisy_Barzdukas@hotmail.com", Website = "http://www.nygh.on.ca/", LastUpdated = DateTime.Now },
                    new Hospital {HospitalName = "Markham Stouffville",                     Street = "381 Church Street", City = "Markham", PostalCode = "L3P 7P3", Phone = "905-472-7000", Email = "Yany_Li@hotmail.com", Website = "http://www.msh.on.ca/", LastUpdated = DateTime.Now },
                    new Hospital {HospitalName = "Rouge Valley Centenary",                  Street = "2867 Ellesmere Rd, Scarborough", City = "Scarborough", PostalCode = "M1E 4B9", Phone = "416-284-8131", Email = "Peggy_Justice@hotmail.com", Website = "http://www.rougevalley.ca/", LastUpdated = DateTime.Now },
                    new Hospital {HospitalName = "Bridgepoint Health",                      Street = "14 St Matthews Rd", City = "Toronto", PostalCode = "M4M 2B5", Phone = "416-461-8251", Email = "Laura_Norman@hotmail.com", Website = "http://www.bridgepointhealth.ca/", LastUpdated = DateTime.Now },
                    new Hospital {HospitalName = "Trillium Health Partners",                Street = "2200 Eglinton Ave W", City = "Mississauga", PostalCode = "L5M 2N1", Phone = "905-813-2200", Email = "Nike_Saman@hotmail.com", Website = "http://trilliumhealthpartners.ca/", LastUpdated = DateTime.Now },
                    new Hospital {HospitalName = "Humber River Hospital",                   Street = "2111 Finch Ave W", City = "North York", PostalCode = "M3N 1N1", Phone = "416-744-2500", Email = "Tom_Cruise@hotmail.com", Website = "http://www.hrh.ca/", LastUpdated = DateTime.Now },
                    new Hospital {HospitalName = "Shouldice Hospital",                      Street = "7750 Bayview Avenue", City = "Thornhill", PostalCode = "M3N 1N1", Phone = "289-807-0024", Email = "Nikole_Kidman@hotmail.com", Website = "http://www.shouldice.com/", LastUpdated = DateTime.Now }
                );
                _context.SaveChanges();
                #endregion

                #region Doctor
                _context.Doctors.AddRange
                (
                    //new Doctor { DoctorId = 1, FirstName = "Carson", LastName = "Alexander", Phone = "416-785-2500", Email = "Carson_Alexander@hotmail.com", ImageUrl = "/Content/Images/Photos/Dr1.jpg", HospitalId_FK = 1, Subscribers = null, Services = null, LastUpdated = DateTime.Now },
                    //new Doctor { DoctorId = 2, FirstName = "Meredith", LastName = "Alonso", Phone = "416-494-2120", Email = "Meredith_Alonso@hotmail.com", ImageUrl = "/Content/Images/Photos/Dr2.jpg", HospitalId_FK = 2, Subscribers = null, Services = null, LastUpdated = DateTime.Now },
                    //new Doctor { DoctorId = 3, FirstName = "Arturo", LastName = "Anandy", Phone = "905-586-8203", Email = "Arturo_Anandy@hotmail.com", ImageUrl = "/Content/Images/Photos/Dr3.jpg", HospitalId_FK = 3, Subscribers = null, Services = null, LastUpdated = DateTime.Now },
                    //new Doctor { DoctorId = 4, FirstName = "Gytisy", LastName = "Barzdukas", Phone = "416-655-2532", Email = "Gytisy_Barzdukas@hotmail.com", ImageUrl = "/Content/Images/Photos/Dr4.jpg", HospitalId_FK = 4, Subscribers = null, Services = null, LastUpdated = DateTime.Now },
                    //new Doctor { DoctorId = 5, FirstName = "Yany", LastName = "Li", Phone = "905-438-2911", Email = "Yany_Li@hotmail.com", ImageUrl = "/Content/Images/Photos/Dr5.jpg", HospitalId_FK = 5, Subscribers = null, Services = null, LastUpdated = DateTime.Now },
                    //new Doctor { DoctorId = 6, FirstName = "Peggy", LastName = "Justice", Phone = "416-472-7000", Email = "Peggy_Justice@hotmail.com", ImageUrl = "/Content/Images/Photos/Dr6.jpg", HospitalId_FK = 6, Subscribers = null, Services = null, LastUpdated = DateTime.Now },
                    //new Doctor { DoctorId = 7, FirstName = "Laura", LastName = "Norman", Phone = "905-756-6000", Email = "Laura_Norman@hotmail.com", ImageUrl = "/Content/Images/Photos/Dr7.jpg", HospitalId_FK = 7, Subscribers = null, Services = null, LastUpdated = DateTime.Now },
                    //new Doctor { DoctorId = 8, FirstName = "Nike", LastName = "Saman", Phone = "416-756-0066", Email = "Nike_Saman@hotmail.com", ImageUrl = "/Content/Images/Photos/Dr8.jpg", HospitalId_FK = 8, Subscribers = null, Services = null, LastUpdated = DateTime.Now },
                    //new Doctor { DoctorId = 9, FirstName = "Tom", LastName = "Cruise", Phone = "905-756-6000", Email = "Tom_Cruise@hotmail.com", ImageUrl = "/Content/Images/Photos/Dr9.jpg", HospitalId_FK = 9, Subscribers = null, Services = null, LastUpdated = DateTime.Now },
                    //new Doctor { DoctorId = 10, FirstName = "Nikole", LastName = "Kidman", Phone = "416-756-0066", Email = "Nikole_Kidman@hotmail.com", ImageUrl = "/Content/Images/Photos/Dr10.jpg", HospitalId_FK = 10, Subscribers = null, Services = null, LastUpdated = DateTime.Now }
                    new Doctor {FirstName = "Carson", LastName = "Alexander", Phone = "416-785-2500", Email = "Carson_Alexander@hotmail.com", ImageUrl = "/Content/Images/Photos/Dr1.jpg", HospitalId = 1, LastUpdated = DateTime.Now },
                    new Doctor {FirstName = "Meredith", LastName = "Alonso", Phone = "416-494-2120", Email = "Meredith_Alonso@hotmail.com", ImageUrl = "/Content/Images/Photos/Dr2.jpg", HospitalId = 2, LastUpdated = DateTime.Now },
                    new Doctor {FirstName = "Arturo", LastName = "Anandy", Phone = "905-586-8203", Email = "Arturo_Anandy@hotmail.com", ImageUrl = "/Content/Images/Photos/Dr3.jpg", HospitalId = 3, LastUpdated = DateTime.Now },
                    new Doctor {FirstName = "Gytisy", LastName = "Barzdukas", Phone = "416-655-2532", Email = "Gytisy_Barzdukas@hotmail.com", ImageUrl = "/Content/Images/Photos/Dr4.jpg", HospitalId = 4, LastUpdated = DateTime.Now },
                    new Doctor {FirstName = "Yany", LastName = "Li", Phone = "905-438-2911", Email = "Yany_Li@hotmail.com", ImageUrl = "/Content/Images/Photos/Dr5.jpg", HospitalId = 5, LastUpdated = DateTime.Now },
                    new Doctor {FirstName = "Peggy", LastName = "Justice", Phone = "416-472-7000", Email = "Peggy_Justice@hotmail.com", ImageUrl = "/Content/Images/Photos/Dr6.jpg", HospitalId = 6, LastUpdated = DateTime.Now },
                    new Doctor {FirstName = "Laura", LastName = "Norman", Phone = "905-756-6000", Email = "Laura_Norman@hotmail.com", ImageUrl = "/Content/Images/Photos/Dr7.jpg", HospitalId = 7, LastUpdated = DateTime.Now },
                    new Doctor {FirstName = "Nike", LastName = "Saman", Phone = "416-756-0066", Email = "Nike_Saman@hotmail.com", ImageUrl = "/Content/Images/Photos/Dr8.jpg", HospitalId = 8, LastUpdated = DateTime.Now },
                    new Doctor {FirstName = "Tom", LastName = "Cruise", Phone = "905-756-6000", Email = "Tom_Cruise@hotmail.com", ImageUrl = "/Content/Images/Photos/Dr9.jpg", HospitalId = 9, LastUpdated = DateTime.Now },
                    new Doctor {FirstName = "Nikole", LastName = "Kidman", Phone = "416-756-0066", Email = "Nikole_Kidman@hotmail.com", ImageUrl = "/Content/Images/Photos/Dr10.jpg", HospitalId = 10, LastUpdated = DateTime.Now }

                );
                _context.SaveChanges();
                #endregion

        }
    }
}