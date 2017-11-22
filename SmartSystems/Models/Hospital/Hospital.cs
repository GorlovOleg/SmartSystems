using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmartSystems.Models.Hospital
{
    [Table("Hospital")]
    public class Hospital
    {

        public Hospital()
        {
            //this.Services = new List<Service>();
            //this.Subscribers = new List<Subscriber>();
        }

        //--- 1
        [Key]
        public int HospitalId { get; set; }

        //--- 2       
        [Required]
        [StringLength(100, MinimumLength = 10)]
        public string HospitalName { get; set; }

        //--- 3
        [Required]
        [Display(Name = "Street Address")]
        [StringLength(100, MinimumLength = 1, ErrorMessage = "Street cannot be longer than 100 characters.")]
        public string Street { get; set; }

        //--- 4
        [Required]
        [StringLength(50, MinimumLength = 1, ErrorMessage = "City cannot be longer than 50 characters.")]
        public string City { get; set; }

        //--- 5
        [StringLength(7, MinimumLength = 1, ErrorMessage = "PostalCode cannot be longer than 7 characters.")]
        public string PostalCode { get; set; }

        //--- 6
        //[Phone]
        //        [DisplayFormat(DataFormatString = "{0:###-###-####}", ApplyFormatInEditMode = true)]
        //        [StringLength(12, MinimumLength = 1, ErrorMessage = "Phone cannot be longer than 12 characters.")]
        [Display(Name = "Phone")]
        public string Phone { get; set; }

        //--- 7
        //[DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        //--- 8
        public string Website { get; set; }



        //--- 9
        //public virtual ICollection<Service> Services { get; set; }
        //public virtual List<Service> Services { get; set; }
        //public List<Service> Services { get; set; }

        //--- 10
        //public virtual ICollection<Subscriber> Subscribers { get; set; }
        //public virtual List<Subscriber> Subscribers { get; set; }
        //public List<Subscriber> Subscribers { get; set; }

        //--- 11
        //[Timestamp]
        //public byte[] RowVersion { get; set; }

        //--- 12
        //[Editable(false, AllowInitialValue = true)]
        public DateTime LastUpdated { get; set; }

    }
}