/*
Author          : Sr Programmer Analyst Oleg Gorlov
Description:	: Class ViewModel for fetching resources from Database in run time. 
Copyright       : GMedia-IT-Consulting.com, SmartSystems.ca 
email           : oleg_gorlov@yahoo.com
Date            : 21/11/2017
Release         : 1.0.0
Comment         : Implementation C# 6 and .NET Core 2.0
 */
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartSystems.Models.Property;

namespace SmartSystems.ViewModels 
{
  public class BrokerageBrokerViewModel
    {
        /// <summary>
        /// 1 pBrokerage.cs       
        /// pBrokerageId
        /// </summary>
        [Key]
        public int pBrokerageId { get; set; }

        /// <summary>
        /// 2 pBrokerage.cs       
        /// pBrokerageName
        /// </summary>             
        [Required]
        [StringLength(100, MinimumLength = 10)]
        public string pBrokerageName { get; set; }

        /// <summary>
        /// 12 pBrokerage.cs
        /// 5 PropertyContext.cs
        /// One-To-Many
        /// May have a pBroker or not
        /// pBrokerage to pBrokers by pBrokerageId_FK
        /// </summary>

        //---  oct, 08 public virtual ICollection<pBroker> pBrokers { get; set; }
        public virtual ICollection<pBroker> pBrokers { get; set; }

    }
}
