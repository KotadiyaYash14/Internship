//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SchoolManagement_340.Models.Context
{
    using System;
    using System.Collections.Generic;
    
    public partial class ImageTable
    {
        public int IamgeId { get; set; }
        public string ImageTitle { get; set; }
        public string Image { get; set; }
        public Nullable<int> UserId { get; set; }
    
        public virtual User User { get; set; }
    }
}
