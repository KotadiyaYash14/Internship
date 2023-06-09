﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class yk327Entities : DbContext
    {
        public yk327Entities()
            : base("name=yk327Entities")
        {

        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<city> city { get; set; }
        public virtual DbSet<country> country { get; set; }
        public virtual DbSet<state> state { get; set; }
    
        public virtual int sp_add_edit_country(Nullable<int> id, string countryname)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("id", id) :
                new ObjectParameter("id", typeof(int));
    
            var countrynameParameter = countryname != null ?
                new ObjectParameter("countryname", countryname) :
                new ObjectParameter("countryname", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_add_edit_country", idParameter, countrynameParameter);
        }
    
        public virtual int sp_delete_country(Nullable<int> id)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("id", id) :
                new ObjectParameter("id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_delete_country", idParameter);
        }
    
        public virtual ObjectResult<sp_get_state_Result> sp_get_state()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_get_state_Result>("sp_get_state");
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
    
        public virtual int sp_delete_state(Nullable<int> id)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("id", id) :
                new ObjectParameter("id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_delete_state", idParameter);
        }
    
        public virtual ObjectResult<sp_get_city_Result> sp_get_city()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_get_city_Result>("sp_get_city");
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
    
        public virtual int sp_delete_city(Nullable<int> cityid)
        {
            var cityidParameter = cityid.HasValue ?
                new ObjectParameter("cityid", cityid) :
                new ObjectParameter("cityid", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_delete_city", cityidParameter);
        }
    }
}
