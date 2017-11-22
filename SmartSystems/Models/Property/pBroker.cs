using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmartSystems.Models.Property  
{
    [Table("pBroker")]
    public class pBroker
    {
        public pBroker()
        {
            //this.pListiners = new List<pListiner>();
            //this.Services = new List<Service>();
            LastUpdated = DateTime.UtcNow;
        }

        [Key]
        //--- 1
        public int pBrokerId { get; set; }
         
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
        //[DisplayFormat(DataFormatString = "{0:###-###-####}", ApplyFormatInEditMode = true)]
        //[StringLength(14, MinimumLength = 1, ErrorMessage = "Phone cannot be longer than 14 characters.")]
        [Display(Name = "Phone")]
        public string Phone { get; set; }

        //--- 5       
        [Required(ErrorMessage = "The email address is required")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        //--- 6
        [Display(Name = "Photo")]
        public string ImageUrl { get; set; }

        /// <summary>
        /// 7 pBroker.cs
        /// Many-To-One
        /// pBrokers-To-pBrokerage
        /// </summary>
        //[ForeignKey("pBrokerage")]

        //---  oct, 08 public int? pBrokerageId_FK { get; set; }
        //---  oct, 08 public virtual pBrokerage pBrokerage { get; set; }

        public int? pBrokerageId { get; set; } 
        public virtual pBrokerage pBrokerage { get; set; }

        /// <summary>
        /// 8  pBroker.cs        
        /// 1  PropertyContext.cs
        /// One-To-Many
        /// May have a pListiners or not
        /// pBroker to pListiners by pBrokerId_FK
        /// </summary>
        //public virtual ICollection<pListiner> pListiners { get; set; }

        /// <summary>
        /// 9 pBroker.cs        
        /// 2 PropertyContext.cs
        /// One-To-Many
        /// May have a pServices or not
        /// pBroker to pServices by pBrokerId_FK
        /// </summary>

        //---  oct, 08  public virtual ICollection<pService> pServices { get; set; }
        //public virtual ICollection<pService> pServices { get; set; }

        /// <summary>
        /// 10 pBroker.cs 
        /// Timestamp
        /// </summary>
        //[Timestamp]
        //public byte[] RowVersion { get; set; }

        /// <summary>
        /// 11 pBroker.cs 
        /// LastUpdated
        /// </summary>
        [Editable(false, AllowInitialValue = true)]
        public DateTime LastUpdated { get; set; }

    }
}