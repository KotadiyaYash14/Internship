﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class SchoolManagement_yk_340Entities : DbContext
    {
        public SchoolManagement_yk_340Entities()
            : base("name=SchoolManagement_yk_340Entities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<City> City { get; set; }
        public virtual DbSet<Country> Country { get; set; }
        public virtual DbSet<State> State { get; set; }
        public virtual DbSet<StudentData> StudentData { get; set; }
    
        public virtual int sp_add_edit_country(Nullable<int> countryId, string countryName)
        {
            var countryIdParameter = countryId.HasValue ?
                new ObjectParameter("countryId", countryId) :
                new ObjectParameter("countryId", typeof(int));
    
            var countryNameParameter = countryName != null ?
                new ObjectParameter("countryName", countryName) :
                new ObjectParameter("countryName", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_add_edit_country", countryIdParameter, countryNameParameter);
        }
    
        public virtual int sp_delete_country(Nullable<int> countryid)
        {
            var countryidParameter = countryid.HasValue ?
                new ObjectParameter("countryid", countryid) :
                new ObjectParameter("countryid", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_delete_country", countryidParameter);
        }
    
        public virtual int sp_add_edit_state(Nullable<int> stateid, string statename, Nullable<int> countryid)
        {
            var stateidParameter = stateid.HasValue ?
                new ObjectParameter("stateid", stateid) :
                new ObjectParameter("stateid", typeof(int));
    
            var statenameParameter = statename != null ?
                new ObjectParameter("statename", statename) :
                new ObjectParameter("statename", typeof(string));
    
            var countryidParameter = countryid.HasValue ?
                new ObjectParameter("countryid", countryid) :
                new ObjectParameter("countryid", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_add_edit_state", stateidParameter, statenameParameter, countryidParameter);
        }
    
        public virtual ObjectResult<sp_getStateList_Result> sp_getStateList()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_getStateList_Result>("sp_getStateList");
        }
    
        public virtual int sp_delete_state(Nullable<int> stateid)
        {
            var stateidParameter = stateid.HasValue ?
                new ObjectParameter("stateid", stateid) :
                new ObjectParameter("stateid", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_delete_state", stateidParameter);
        }
    
        public virtual int sp_add_edit_city(Nullable<int> cityid, string cityname, Nullable<int> stateid, Nullable<int> countryid)
        {
            var cityidParameter = cityid.HasValue ?
                new ObjectParameter("cityid", cityid) :
                new ObjectParameter("cityid", typeof(int));
    
            var citynameParameter = cityname != null ?
                new ObjectParameter("cityname", cityname) :
                new ObjectParameter("cityname", typeof(string));
    
            var stateidParameter = stateid.HasValue ?
                new ObjectParameter("stateid", stateid) :
                new ObjectParameter("stateid", typeof(int));
    
            var countryidParameter = countryid.HasValue ?
                new ObjectParameter("countryid", countryid) :
                new ObjectParameter("countryid", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_add_edit_city", cityidParameter, citynameParameter, stateidParameter, countryidParameter);
        }
    
        public virtual ObjectResult<sp_getStateCountryList_Result> sp_getStateCountryList()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_getStateCountryList_Result>("sp_getStateCountryList");
        }
    
        public virtual int sp_delete_city(Nullable<int> cityid)
        {
            var cityidParameter = cityid.HasValue ?
                new ObjectParameter("cityid", cityid) :
                new ObjectParameter("cityid", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_delete_city", cityidParameter);
        }
    
        public virtual int sp_add_edit_student(Nullable<int> studentid, string studentname, string studentemail, string stdentphone, Nullable<System.DateTime> studentdob, string studentgender, string studentaddress, Nullable<int> studentcountry, Nullable<int> studentstate, Nullable<int> studentcity)
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
    
            var stdentphoneParameter = stdentphone != null ?
                new ObjectParameter("stdentphone", stdentphone) :
                new ObjectParameter("stdentphone", typeof(string));
    
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
    
            var studentstateParameter = studentstate.HasValue ?
                new ObjectParameter("studentstate", studentstate) :
                new ObjectParameter("studentstate", typeof(int));
    
            var studentcityParameter = studentcity.HasValue ?
                new ObjectParameter("studentcity", studentcity) :
                new ObjectParameter("studentcity", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_add_edit_student", studentidParameter, studentnameParameter, studentemailParameter, stdentphoneParameter, studentdobParameter, studentgenderParameter, studentaddressParameter, studentcountryParameter, studentstateParameter, studentcityParameter);
        }
    
        public virtual int sp_delete_student(Nullable<int> studentid)
        {
            var studentidParameter = studentid.HasValue ?
                new ObjectParameter("studentid", studentid) :
                new ObjectParameter("studentid", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_delete_student", studentidParameter);
        }
    }
}