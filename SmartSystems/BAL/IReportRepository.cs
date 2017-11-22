/*
Author          : Sr Programmer Analyst Oleg Gorlov
Description:	: The interface contains abstract methods, default methods 
Copyright       : GMedia-IT-Consulting.com, SmartSystems.ca 
email           : oleg_gorlov@yahoo.com
Date            : 21/11/2017
Release         : 1.0.0
Comment         : Implementation C# 6 and .NET Core 2.0
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SmartSystems.Models.Property;

namespace SmartSystems.BAL
{
    public interface IReportRepository
    {

        //IEnumerable<pBroker> GetAllBrokers();
        
        IEnumerable<pBroker> GetBrokersByBrokerageId(int pBrokerage_BrokerageId);
        //IEnumerable<pBrokerage> GetBrokerageById(int pBrokerage_BrokerageId);
        pBrokerage GetBrokerageById(int pBrokerage_BrokerageId); 

        //IEnumerable<pBrokerage> GetAllBrokerages();

        //bool SaveAll();
        //void AddEntity(object model);
    }
}
