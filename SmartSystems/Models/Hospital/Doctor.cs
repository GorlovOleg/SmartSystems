using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmartSystems.Models.Hospital
{
    [Table("Doctor")]
    public class Doctor
    {
        public Doctor()
        {
            //this.Subscribers = new List<Subscriber>();
            //this.Services = new List<Service>();
        }

        //--- 1
        [Key]
        public int DoctorId { get; set; }

        //--- 2
        [StringLength(50, ErrorMessage = "First name cannot be longer than 50 characters.")]
        [Column("FirstName")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        //--- 3
        [StringLength(50, ErrorMessage = "Last name cannot be longer than 50 characters.")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        //--- 4
        [Phone]
        //        [DisplayFormat(DataFormatString = "{0:###-###-####}", ApplyFormatInEditMode = true)]
        //        [StringLength(12, MinimumLength = 1, ErrorMessage = "Phone cannot be longer than 12 characters.")]
        [Display(Name = "Phone")]
        public string Phone { get; set; }

        //--- 5
        [Required(ErrorMessage = "The email address is required")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        //--- 6
        //[Column(TypeName="Image")]      
        public string ImageUrl { get; set; }

        //--- 7
        [ForeignKey("Hospital")]
        //public virtual int HospitalID_FK { get; set; }
        ///*Must have a Hospital*/
        //public virtual Hospital Hospital { get; set; }
        public int? HospitalId  { get; set; }

        public Hospital Hospital { get; set; }

        //--- 8
        //--- + 4
        //public virtual List<Subscriber> Subscribers { get; set; }
        //public virtual ICollection<Subscriber> Subscribers { get; set; }
        //public List<Subscriber> Subscribers { get; set; }

        //--- 9
        //--- + 1
        //public virtual List<Service> Services { get; set; }
        //public virtual ICollection<Service> Services { get; set; }
        //public List<Service> Services { get; set; }

        //--- 10
        //[Timestamp]
        //public byte[] RowVersion { get; set; }

        //--- 11
        //[Editable(false, AllowInitialValue = true)]
        public DateTime LastUpdated { get; set; }
    }
}