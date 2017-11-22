/*
Author          : Sr Programmer Analyst Oleg Gorlov
Description:	: Unit Test to check Web API controllers. 
                : Copyright  GMedia-IT-Consulting, Smart Systems 
email           : oleg_gorlov@yahoo.com
Date            : 20/11/2017
Release         : 1.0.0
Comment         : 

 */
using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SmartSystems.Controllers;
using Microsoft.Extensions.Logging;
using SmartSystems.Models.Property;
using SmartSystems.DAL;
using SmartSystems.Models;
using Microsoft.AspNetCore.Mvc;
using SmartSystems.Models.Hospital;

namespace SmartSystemsTests.Web.Controllers
{
    [TestClass]
    public class SmartSystemsTests
    {
        private readonly ILogger<BrokerageController> _logger;
        public readonly PropertyDbContext _context;

        [TestInitialize]
        public void Initialize(PropertyDbContext context, ILogger<BrokerageController> _logger)
        {

        }

        /// <summary>
        ///  Check Web API GET: api/Brokerage/5 controller BrokerageBrokersController to get objects  Brokerage
        /// </summary>
        [TestMethod]
        private void GetBrokerage_ShouldReturn_Not_Empty_List_Brokerage()
        {
            using (var brokerage = new BrokerageBrokersController(_context))
            {
                var _brokerage = brokerage.GetBrokerage();
                Assert.IsNotNull(_brokerage);
            }
        }

        /// <summary>
        ///  Check Web API GET: api/Brokerage/5 controller BrokerageBrokersController to get One Record  Brokerage by Id 
        /// </summary>
        [TestMethod]
        private void GetBrokerage_ShouldReturn_One_Record_Brokerage()
        {

            using (var brokerage = new BrokerageBrokersController(_context))
            {
                // Arrange
                var pBrokerageId = 1;
                var sample = SampleBrokerage();

                // Act
                var result = brokerage.GetBrokerage(pBrokerageId);

                //Assert
                Assert.IsNotNull(result);
                Assert.AreEqual(sample.pBrokerageName[0], result.pBrokerageName[0]);
            }
        }


        /// <summary>
        ///  Check Web API GET: api/Brokerage/5 controller BrokerageBrokersController to get One Record  Brokerage by Id 
        /// </summary>
        [TestMethod]
        private void PutBrokerage_ShouldReturnStatusCode()
        {

            using (var brokerage = new BrokerageBrokersController(_context))
            {
                // Arrange
                var pBrokerageId = 1;
                var sample = SampleBrokerage();

                // Act
                var result = brokerage.GetBrokerage(pBrokerageId);

                //Assert
                Assert.IsNotNull(result);
                Assert.AreEqual(sample.pBrokerageName[0], result.pBrokerageName[0]);
            }

        }

        /// <summary>
        ///  Check Web API DELETE: controller BrokerController
        /// </summary>
        [TestMethod]
        private void DeleteBroker_ShouldReturnOK()
        {
            using (var broker = new BrokerController(_context))
            {
                // Arrange
                var pBrokerId = 1;

                // Act
                var result = broker.DeleteBroker(pBrokerId);

                //Assert
                Assert.IsNotNull(result);
            }
        }

        /// <summary>
        ///  Sample pBrokerage for Unit Test controller BrokerageBrokersController
        /// </summary>
        private pBrokerage SampleBrokerage()
        {
            return new pBrokerage()
            {
                pBrokerageId = 1,
                pBrokerageName = "Royal LePage Real Estate Services Ltd.",
                City = "Bradford",
                Street = "1500 Royal York Rd.",
                PostalCode = "M9P 3B6",
                Website = "http://www.royallepage.ca/",
                Phone = "(416) 245-9933"
            };
        }


    }
}

