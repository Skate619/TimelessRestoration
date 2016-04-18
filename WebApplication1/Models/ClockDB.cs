using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class ClockDB
    {
        public int ID { get; set; }
        [Display(Name = "Dial Number")]
        [DataType(DataType.Date)]
        public string DialNumber { get; set; }
        [Display(Name = "Dial Maker")]
        [DataType(DataType.Date)]
        public string DialMaker { get; set; }
        [Display(Name = "Dial Maker Town")]
        [DataType(DataType.Date)]
        public string DialMakerTown { get; set; }
        [Display(Name = "Clock Maker")]
        [DataType(DataType.Date)]
        public string ClockMaker { get; set; }
        [Display(Name = "Clock Maker Town")]
        [DataType(DataType.Date)]
        public string ClockMakerTown { get; set; }
        [Display(Name = "Clock Date")]
        [DataType(DataType.Date)]
        public string ClockDate { get; set; }
        [Display(Name = "Dial Date")]
        [DataType(DataType.Date)]
        public string DialDate { get; set; }
        [Display(Name = "Dial Type")]
        [DataType(DataType.Date)]
        public string DialType { get; set; }
        [Display(Name = "Associated Dials")]
        [DataType(DataType.Date)]
        public string AssociatedDials { get; set; }
        public string Graphics { get; set; }
        public string Hemispheres { get; set; }
        [Display(Name = "Date Dial")]
        [DataType(DataType.Date)]
        public string DateDial { get; set; }
        [Display(Name = "Seconds Dial")]
        [DataType(DataType.Date)]
        public string SecondsDial { get; set; }
        public string Description { get; set; }
        [Display(Name = "False Plate")]
        [DataType(DataType.Date)]
        public string FalsePlate { get; set; }
        [Display(Name = "Moon Dial Face")]
        [DataType(DataType.Date)]
        public string MoonDialFace { get; set; }
        [Display(Name = "Moon Dial Scene 1")]
        [DataType(DataType.Date)]
        public string MoonDialScene1 { get; set; }
        [Display(Name = "Moon Dial Scene 2")]
        [DataType(DataType.Date)]
        public string MoonDialScene2 { get; set; }
    }

    public class ClockDBContext : DbContext
    {
        public DbSet<ClockDB> Clocks { get; set; }
    }
}