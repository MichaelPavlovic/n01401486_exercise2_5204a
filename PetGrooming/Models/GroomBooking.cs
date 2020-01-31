using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
//Install  entity framework 6 on Tools > Manage Nuget Packages > Microsoft Entity Framework (ver 6.4)
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PetGrooming.Models
{
    public class GroomBooking
    { 
        */
        [Key]
        public int GroomBookingID { get; set; }
        public DateTime GroomBookingTime { get; set; }
        public double GroomBookingCost { get; set; }

        public int GroomerID { get; set; }
        [ForeignKey("GroomerID")]
        public virtual Groomer Groomer { get; set; }

        public int PetID { get; set; }
        [ForeignKey("PetID")]
        public virtual Pet Pet { get; set; }

        public int OwnerID { get; set; }
        [ForeignKey("OwnerID")]
        public virtual Owner Owner { get; set; }

        public ICollection<GroomService> GroomServices { get; set; }
    }
}