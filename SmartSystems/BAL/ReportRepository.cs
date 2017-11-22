/*
Author          : Full-stack Developer Oleg Gorlov
Description:	: ReportRepository class implementation IReportRepository Business Access Layer
Copyright       : GMedia-IT-Coonsulting
email           : oleg_gorlov@yahoo.com
Date            : 20/11/2017
Release         : 1.0.0
Comment         : 
            
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SmartSystems.DAL;
using SmartSystems.Models.Property;
using AutoMapper;

namespace SmartSystems.BAL
{
    public class ReportRepository : IReportRepository
    {

        private readonly PropertyDbContext _context;

        public ReportRepository(PropertyDbContext context)
        {
            _context = context;
        }

        #region GetAllBrokersByBrokerage 
        /// <summary>
        /// Get All Brokers By BrokerageId
        /// </summary>
        /// <param name="pBrokerage_BrokerageId">Primary Key</param>
        /// <returns> IEnumerable pBroker </returns>
        IEnumerable<pBroker> IReportRepository.GetBrokersByBrokerageId(int pBrokerage_BrokerageId)
        {
            return _context.pBroker
                .Where(pBroker => pBroker.pBrokerageId == pBrokerage_BrokerageId)
                .ToList();
        }
        #endregion

        #region GetBrokerageById 
        /// <summary>
        /// Get object Brokerage By BrokerageId
        /// </summary>
        /// <param name="pBrokerage_BrokerageId">Primary Key</param>
        /// <returns> IEnumerable pBroker </returns>
        pBrokerage IReportRepository.GetBrokerageById(int pBrokerage_BrokerageId)
        {
            return _context.pBrokerage
                .Where(pBrokerageId => pBrokerageId.pBrokerageId == pBrokerage_BrokerageId)
                .FirstOrDefault();
        }
        #endregion

    }
}
