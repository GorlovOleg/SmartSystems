/*
Author          : Sr Programmer Analyst Oleg Gorlov
Description:	: DAL to access SQL database tables. 
                : Database context is the main class that coordinates Entity Framework functionality .NET Core
Copyright       : GMedia-IT-Consulting 
email           : oleg_gorlov@yahoo.com
Date            : 05/05/2017
Release         : 1.0.0
Comment         : Implementation MVC6 .NET Core March 2017 Update - 1.1.1 Released 3/7/2017

 */
using System;
using System.Linq;
using SmartSystems.Models.Property;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using SmartSystems.DAL;
using SmartSystems.Models.Hospital;
using Microsoft.Extensions.Logging;

namespace SmartSystems.DAL
{
    public partial class PropertyDbContext : DbContext
    {
        private readonly ILogger<PropertyDbContext> _logger;
        private readonly PropertyDbContext _context;

        public PropertyDbContext(DbContextOptions<PropertyDbContext> options)
            : base(options)
        { }

        public DbSet<pBroker> pBroker { get; set; }
        public DbSet<pBrokerage> pBrokerage { get; set; }

        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Hospital> Hospitals { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            //builder.ForSqlServer().UseIdentity();

            #region pBroker
            //--- pBroker
            builder.Entity<pBroker>()
                .HasKey(c => c.pBrokerId);

            builder.Entity<pBroker>()
            .Property<int>(c => c.pBrokerId);
            #endregion

            #region pBrokerage
            //--- pBrokerage
            builder.Entity<pBrokerage>()
                .HasKey(c => c.pBrokerageId);

            builder.Entity<pBrokerage>()
            .Property<int>(c => c.pBrokerageId);
            #endregion

            #region Hospital
            //--- Hospital
            builder.Entity<Hospital>()
                .HasKey(c => c.HospitalId);

            builder.Entity<Hospital>()
            .Property<int>(c => c.HospitalId);

            builder.Entity<Hospital>().Property<DateTime>("LastUpdated");
            #endregion

            #region Doctor
            //builder.Entity<Hospital>()
            //    .Reference(c => c.DoctorId_FK)
            //    .InverseReference()
            //    .ForeignKey<Doctor>(d => d.DoctorId);

            //--- Doctor
            builder.Entity<Doctor>()
                .HasKey(c => c.DoctorId);

            builder.Entity<Doctor>()
            .Property<int>(c => c.DoctorId);

            builder.Entity<Doctor>().Property<DateTime>("LastUpdated");
            #endregion
        }

    }
}
