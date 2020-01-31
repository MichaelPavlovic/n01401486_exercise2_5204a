using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
//Install  entity framework 6 on Tools > Manage Nuget Packages > Microsoft Entity Framework (ver 6.4)
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;

namespace PetGrooming.Models
{
    public class Groomer
    {
        public int GroomerID { get; set; }
        public string GroomerFName { get; set; }
        public string GroomerLName { get; set; }
        public string GroomerPhone { get; set; }
        public DateTime GroomerDOB { get; set; }
        public int GroomerRate { get; set; }
    }
}