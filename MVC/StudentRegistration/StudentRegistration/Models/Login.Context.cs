﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace StudentRegistration.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class CP356ChiragPatelEntities : DbContext
    {
        public CP356ChiragPatelEntities()
            : base("name=CP356ChiragPatelEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<SchoolUserLogin> SchoolUserLogin { get; set; }
        public virtual DbSet<City> City { get; set; }
        public virtual DbSet<Country> Country { get; set; }
        public virtual DbSet<State> State { get; set; }
        public virtual DbSet<SchoolStudentInfo> SchoolStudentInfo { get; set; }
        public virtual DbSet<v_Show_School_Country> v_Show_School_Country { get; set; }
        public virtual DbSet<v_Show_School_State> v_Show_School_State { get; set; }
        public virtual DbSet<v_Show_School_City> v_Show_School_City { get; set; }
    
        public virtual ObjectResult<sp_View_School_Student_Info_Result1> sp_View_School_Student_Info()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_View_School_Student_Info_Result1>("sp_View_School_Student_Info");
        }
    
        public virtual int sp_Add_Edit_School_Student_Info(Nullable<long> id, string fName, string lName, string phoneNumber, string emailId, Nullable<System.DateTime> birthDate, string gender, string address, Nullable<int> country, Nullable<int> state, Nullable<int> city)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("Id", id) :
                new ObjectParameter("Id", typeof(long));
    
            var fNameParameter = fName != null ?
                new ObjectParameter("FName", fName) :
                new ObjectParameter("FName", typeof(string));
    
            var lNameParameter = lName != null ?
                new ObjectParameter("LName", lName) :
                new ObjectParameter("LName", typeof(string));
    
            var phoneNumberParameter = phoneNumber != null ?
                new ObjectParameter("PhoneNumber", phoneNumber) :
                new ObjectParameter("PhoneNumber", typeof(string));
    
            var emailIdParameter = emailId != null ?
                new ObjectParameter("EmailId", emailId) :
                new ObjectParameter("EmailId", typeof(string));
    
            var birthDateParameter = birthDate.HasValue ?
                new ObjectParameter("BirthDate", birthDate) :
                new ObjectParameter("BirthDate", typeof(System.DateTime));
    
            var genderParameter = gender != null ?
                new ObjectParameter("Gender", gender) :
                new ObjectParameter("Gender", typeof(string));
    
            var addressParameter = address != null ?
                new ObjectParameter("Address", address) :
                new ObjectParameter("Address", typeof(string));
    
            var countryParameter = country.HasValue ?
                new ObjectParameter("Country", country) :
                new ObjectParameter("Country", typeof(int));
    
            var stateParameter = state.HasValue ?
                new ObjectParameter("State", state) :
                new ObjectParameter("State", typeof(int));
    
            var cityParameter = city.HasValue ?
                new ObjectParameter("City", city) :
                new ObjectParameter("City", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_Add_Edit_School_Student_Info", idParameter, fNameParameter, lNameParameter, phoneNumberParameter, emailIdParameter, birthDateParameter, genderParameter, addressParameter, countryParameter, stateParameter, cityParameter);
        }
    
        public virtual int sp_Delete_School_Student_Info(Nullable<long> iD)
        {
            var iDParameter = iD.HasValue ?
                new ObjectParameter("ID", iD) :
                new ObjectParameter("ID", typeof(long));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_Delete_School_Student_Info", iDParameter);
        }
    
        public virtual int sp_Add_Edit_School_Country(Nullable<int> id, string countryName)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("Id", id) :
                new ObjectParameter("Id", typeof(int));
    
            var countryNameParameter = countryName != null ?
                new ObjectParameter("CountryName", countryName) :
                new ObjectParameter("CountryName", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_Add_Edit_School_Country", idParameter, countryNameParameter);
        }
    
        public virtual int sp_Delete_School_Country(Nullable<int> id)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("Id", id) :
                new ObjectParameter("Id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_Delete_School_Country", idParameter);
        }
    
        public virtual int sp_Add_Edit_School_State(Nullable<int> id, string stateName, Nullable<int> countryId)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("Id", id) :
                new ObjectParameter("Id", typeof(int));
    
            var stateNameParameter = stateName != null ?
                new ObjectParameter("StateName", stateName) :
                new ObjectParameter("StateName", typeof(string));
    
            var countryIdParameter = countryId.HasValue ?
                new ObjectParameter("CountryId", countryId) :
                new ObjectParameter("CountryId", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_Add_Edit_School_State", idParameter, stateNameParameter, countryIdParameter);
        }
    
        public virtual int sp_Delete_School_State(Nullable<int> id)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("Id", id) :
                new ObjectParameter("Id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_Delete_School_State", idParameter);
        }
    
        public virtual int sp_Add_Edit_School_City(Nullable<int> id, string cityName, Nullable<int> stateId)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("Id", id) :
                new ObjectParameter("Id", typeof(int));
    
            var cityNameParameter = cityName != null ?
                new ObjectParameter("CityName", cityName) :
                new ObjectParameter("CityName", typeof(string));
    
            var stateIdParameter = stateId.HasValue ?
                new ObjectParameter("StateId", stateId) :
                new ObjectParameter("StateId", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_Add_Edit_School_City", idParameter, cityNameParameter, stateIdParameter);
        }
    
        public virtual int sp_Delete_School_City(Nullable<int> iD)
        {
            var iDParameter = iD.HasValue ?
                new ObjectParameter("ID", iD) :
                new ObjectParameter("ID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_Delete_School_City", iDParameter);
        }
    }
}
