using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StudentRegistration.Models
{
    [MetadataType(typeof(Metadata))]
    public partial class SchoolStudentInfo
    {
        internal class Metadata
        {
            [Required]
            public string FName { get; set; }

            [Required]
            public string LName { get; set; }
            
            [Required]
            public string PhoneNumber { get; set; }
            
            [Required]
            public string EmailId { get; set; }
            
            [Required]
            public DateTime BirthDate { get; set; }
            
            [Required]
            public string Gender { get; set; }
            
            [Required]
            public string Address { get; set; }
            
            [Required]
            public int Country { get; set; }
            
            [Required]
            public int State { get; set; }
            
            [Required]
            public int City { get; set; }
        }
    }
}