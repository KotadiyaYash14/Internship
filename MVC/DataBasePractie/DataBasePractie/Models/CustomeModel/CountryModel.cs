﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DataBasePractie.Models.CustomeModel
{
    public class CountryModel
    {
        public int CountryId { get; set; }
        [Required]
        public string CountryName { get; set; }
    }
}