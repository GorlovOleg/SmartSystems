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
using Microsoft.Extensions.Logging;
using SmartSystems.Models.Property;

namespace SmartSystems.Seed
{
    public static class PropertyExtensions
    {
        private static readonly ILogger<PropertyDbContext> _logger;
        private static readonly PropertyDbContext _context;

        public static void SeedProperty(this IApplicationBuilder app)
        {

            //--- Dependency injection (DI) inside
            #region pBrokerage
            _context.pBrokerage.AddRange
            (
                new pBrokerage { pBrokerageName = "Royal LePage Real Estate Services Ltd.", Street = "1500 Royal York Rd.", City = "Toronto", PostalCode = "M9P 3B6", Phone = "(416) 245-9933", Website = "http://www.royallepage.ca/", LastUpdated = DateTime.Now },
                new pBrokerage { pBrokerageName = "Sutton Group Security Real Estate Inc.", Street = "1881 Steels Ave. W", City = "Toronto", PostalCode = "M3H 5Y4", Phone = "(416) 300-3459", Website = "http://www.suttongroupsecurityrealestate.com/", LastUpdated = DateTime.Now },
                new pBrokerage { pBrokerageName = "RE/MAX Realtron Inc.", Street = "183 Willowdale Ave.", City = "Toronto", PostalCode = "M2N 4Y9", Phone = "(416) 222-8600", Website = "http://www.realtronhomes.com/", LastUpdated = DateTime.Now },
                new pBrokerage { pBrokerageName = "HomeLife/Realty One Ltd.", Street = "501 Parliament St.", City = "Toronto", PostalCode = "M4X 1P3", Phone = "(416) 922-5533", Website = "http://www.homeliferealtyone.com/", LastUpdated = DateTime.Now },
                new pBrokerage { pBrokerageName = "Century 21 Real Estate LLC.", Street = "49 Holland St. W", City = "Toronto", PostalCode = "L3Z 2B6", Phone = "(905) 775-5677", Website = "http://www.century21.ca/", LastUpdated = DateTime.Now },
                new pBrokerage { pBrokerageName = "Metro King Realty Inc.", Street = "113 Holland St. W", City = "Bradford West Gwillimbury", PostalCode = "L3Z 2B7", Phone = "(905) 895-2882", Website = "http://www.metrokingrealty.com/", LastUpdated = DateTime.Now },
                new pBrokerage { pBrokerageName = "Commonsense Network Brokerage", Street = "430 McNeilly Rd.", City = "Hamilton", PostalCode = "L8E 5E3", Phone = "(855) 999-9740", Website = "http://comfree.com/", LastUpdated = DateTime.Now },
                new pBrokerage { pBrokerageName = "Bosley Real Estate Ltd.", Street = "290 Merton St.", City = "Toronto", PostalCode = "M4S 1A9", Phone = "(416) 322-8000", Website = "http://www.torontorealtyblog.com/", LastUpdated = DateTime.Now },
                new pBrokerage { pBrokerageName = "Colliers International Inc.", Street = "245 Yorkland Bld.", City = "Toronto", PostalCode = "M2J 4W9", Phone = "(416) 492-0100", Website = "http://www.collierscanada.com/", LastUpdated = DateTime.Now },
                new pBrokerage { pBrokerageName = "Orange Square Realty Inc.", Street = "101 Duncan Mill Rd.", City = "Toronto", PostalCode = "M3B 1Z3", Phone = "(416) 840-6888", Website = "http://www.orangesquarerealty.com/", LastUpdated = DateTime.Now },
                new pBrokerage { pBrokerageName = "Search Realty Corp.", Street = "50 Village Centre Pl.", City = "Missisaga", PostalCode = "L4Z 1V9", Phone = "(877) 979-4979", Website = "http://www.searchrealty.ca/", LastUpdated = DateTime.Now }

                );
            _context.SaveChanges();
            #endregion

            #region pBroker
            _context.pBroker.AddRange
            (
                new pBroker { FirstName = "Rita", LastName = "Delicata", Phone = "(416)245-9933", Email = "Rita_Delicata@hotmail.com", ImageUrl = "/Content/Images/Broker/Rita_Delicata.jpg", pBrokerageId = 1, LastUpdated = DateTime.Now },
                new pBroker { FirstName = "Vladimir", LastName = "Krasnopolskey", Phone = "(416)300-3459", Email = "vlad2012@hotmail.com", ImageUrl = "/Content/Images/Broker/Vladimir_Krasnopolskey.jpg", pBrokerageId = 2, LastUpdated = DateTime.Now },
                new pBroker { FirstName = "Vivian", LastName = "Shah", Phone = "(905)892-6643", Email = "vivianshah@hotmail.com", ImageUrl = "/Content/Images/Broker/Vivian_Shah.jpg", pBrokerageId = 3, LastUpdated = DateTime.Now },
                new pBroker { FirstName = "Luigi", LastName = "Riccelli", Phone = "(416)798-7777", Email = "Luigi_Riccelli@hotmail.com", ImageUrl = "/Content/Images/Broker/Luigi_Riccelli.jpg", pBrokerageId = 4, LastUpdated = DateTime.Now },
                new pBroker { FirstName = "Debra", LastName = "Huetl", Phone = "(905)251-6166", Email = "Debra_Huetl@hotmail.com", ImageUrl = "/Content/Images/Broker/Debra_Huetl.jpg", pBrokerageId = 5, LastUpdated = DateTime.Now },
                new pBroker { FirstName = "Iftikhar", LastName = "Ahmad", Phone = "(416)671-3861", Email = "Iftikhar_Ahmad@hotmail.com", ImageUrl = "/Content/Images/Broker/Iftikhar_Ahmad.jpg", pBrokerageId = 6, LastUpdated = DateTime.Now },
                new pBroker { FirstName = "Lukas", LastName = "Lhotsky", Phone = "(855)999-9740", Email = "offertopurchase.on@comfree.com", ImageUrl = "/Content/Images/Broker/Lukas_Lhotsky.jpg", pBrokerageId = 7, LastUpdated = DateTime.Now },
                new pBroker { FirstName = "Jonathan", LastName = "Van", Phone = "(905)513-8878", Email = "Jonathan_Van@colliers.com", ImageUrl = "/Content/Images/Broker/Jonathan_Van.jpg", pBrokerageId = 1, LastUpdated = DateTime.Now },
                new pBroker { FirstName = "Eva", LastName = "Liu", Phone = "(416)840-6888", Email = "eva@orangesquarerealty.com", ImageUrl = "/Content/Images/Broker/Eva_Liu.jpg", pBrokerageId = 10, LastUpdated = DateTime.Now },
                new pBroker { FirstName = "Sterling", LastName = "Wong", Phone = "(877)979-4979", Email = "info(at)searchrealty.ca", ImageUrl = "/Content/Images/Broker/Sterling_Wong.jpg", pBrokerageId = 11, LastUpdated = DateTime.Now }

            );
            _context.SaveChanges();
            #endregion

        }
    }
}
