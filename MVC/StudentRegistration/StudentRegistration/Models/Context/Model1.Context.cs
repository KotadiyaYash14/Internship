﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace StudentRegistration.Models.Context
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class yk327Entities1 : DbContext
    {
        public yk327Entities1()
            : base("name=yk327Entities1")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<myuser> myusers { get; set; }
        public virtual DbSet<role> roles { get; set; }
        public virtual DbSet<student> student { get; set; }
        public virtual DbSet<city> city { get; set; }
        public virtual DbSet<country> country { get; set; }
        public virtual DbSet<state> state { get; set; }
    
        public virtual int sp_delete_student(Nullable<int> studentid)
        {
            var studentidParameter = studentid.HasValue ?
                new ObjectParameter("studentid", studentid) :
                new ObjectParameter("studentid", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_delete_student", studentidParameter);
        }
    
        public virtual int sp_add_edit_student(Nullable<int> studentid, string studentname, string studentemail, string studentphone, Nullable<System.DateTime> studentdob, string studentgender, string studentaddress, Nullable<int> studentcountry, Nullable<int> stuentstate, Nullable<int> studentcity, string studentpincode)
        {
            var studentidParameter = studentid.HasValue ?
                new ObjectParameter("studentid", studentid) :
                new ObjectParameter("studentid", typeof(int));
    
            var studentnameParameter = studentname != null ?
                new ObjectParameter("studentname", studentname) :
                new ObjectParameter("studentname", typeof(string));
    
            var studentemailParameter = studentemail != null ?
                new ObjectParameter("studentemail", studentemail) :
                new ObjectParameter("studentemail", typeof(string));
    
            var studentphoneParameter = studentphone != null ?
                new ObjectParameter("studentphone", studentphone) :
                new ObjectParameter("studentphone", typeof(string));
    
            var studentdobParameter = studentdob.HasValue ?
                new ObjectParameter("studentdob", studentdob) :
                new ObjectParameter("studentdob", typeof(System.DateTime));
    
            var studentgenderParameter = studentgender != null ?
                new ObjectParameter("studentgender", studentgender) :
                new ObjectParameter("studentgender", typeof(string));
    
            var studentaddressParameter = studentaddress != null ?
                new ObjectParameter("studentaddress", studentaddress) :
                new ObjectParameter("studentaddress", typeof(string));
    
            var studentcountryParameter = studentcountry.HasValue ?
                new ObjectParameter("studentcountry", studentcountry) :
                new ObjectParameter("studentcountry", typeof(int));
    
            var stuentstateParameter = stuentstate.HasValue ?
                new ObjectParameter("stuentstate", stuentstate) :
                new ObjectParameter("stuentstate", typeof(int));
    
            var studentcityParameter = studentcity.HasValue ?
                new ObjectParameter("studentcity", studentcity) :
                new ObjectParameter("studentcity", typeof(int));
    
            var studentpincodeParameter = studentpincode != null ?
                new ObjectParameter("studentpincode", studentpincode) :
                new ObjectParameter("studentpincode", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_add_edit_student", studentidParameter, studentnameParameter, studentemailParameter, studentphoneParameter, studentdobParameter, studentgenderParameter, studentaddressParameter, studentcountryParameter, stuentstateParameter, studentcityParameter, studentpincodeParameter);
        }
    }
}
