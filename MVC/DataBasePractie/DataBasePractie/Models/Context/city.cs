//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DataBasePractie.Models.Context
{
    using System;
    using System.Collections.Generic;
    
    public partial class city
    {
        public int cityId { get; set; }
        public string cityName { get; set; }
        public Nullable<int> StateId { get; set; }
        public Nullable<int> CountryId { get; set; }
    
        public virtual country country { get; set; }
        public virtual state state { get; set; }
    }
}
