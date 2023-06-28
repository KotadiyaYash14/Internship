using CoreDemoApp.Common.Helpers;
using CoreDemoApp.Model.Config;
using CoreDemoApp.Model.ViewModel.City;
using CoreDemoApp.Model.ViewModel.State;
using Dapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreDemoApp.Data.DbRepository.City
{
    public class CityRepository : BaseRepository, ICityRepository
    {
        #region Fields

        private readonly IConfiguration _configuration;

        #endregion

        #region Constructor

        public CityRepository(IConfiguration configuration, IOptions<DataConfig> dataconfig) : base(dataconfig, configuration)
        {
            _configuration = configuration;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Get All City By Stored Procedure
        /// </summary>
        public async Task<List<CityData>> GetAllCity()
        {
            try
            {
                var City = await QueryAsync<CityData>(StoredProcedures.GetAllCity, commandType: CommandType.StoredProcedure);
                return City.ToList();
            }
            catch (Exception Exce)
            {
                throw Exce;
            }
        }

        /// <summary>
        /// Delete City Method Using Stored Procedure
        /// </summary>
        public async Task<int> DeleteCity(int id)
        {
            try
            {
                var param = new DynamicParameters();
                param.Add("@cityid", id);
                return await ExecuteAsync<int>(StoredProcedures.DeleteCity, param, commandType: CommandType.StoredProcedure);
            }
            catch (Exception Exce)
            {
                throw Exce;
            }
        }

        /// <summary>
        /// Add Edit City Method Using Stored Procedure 
        /// </summary>
        public async Task<int> AddEditCity(CityData city)
        {
            try
            {
                if (city.CityId == 0)
                {
                    var param = new DynamicParameters();
                    param.Add("@cityid", null);
                    param.Add("@cityname", city.CityName);
                    param.Add("@stateid", city.StateId);
                    param.Add("@countryid", city.CountryId);
                    return await ExecuteAsync<int>(StoredProcedures.AddEditCity, param, commandType: CommandType.StoredProcedure);
                }
                else
                {
                    var param = new DynamicParameters();
                    param.Add("@cityid", city.CityId);
                    param.Add("@cityname", city.CityName);
                    param.Add("@stateid", city.StateId);
                    param.Add("@countryid", city.CountryId);
                    var City = await ExecuteAsync<int>(StoredProcedures.AddEditCity, param, commandType: CommandType.StoredProcedure);
                    return City;
                }
            }
            catch (Exception Exce)
            {
                throw Exce;
            }
        }

        /// <summary>
        /// Get City By Id Method Using Strored Procedure
        /// </summary>
        public async Task<CityData> GetCityById(int id)
        {
            try
            {
                var param = new DynamicParameters();
                param.Add("@cityid", id);
                return await QueryFirstOrDefaultAsync<CityData>(StoredProcedures.GetCityById, param, commandType: CommandType.StoredProcedure);
            }
            catch (Exception Exce)
            {
                throw Exce;
            }
        }

      /// <summary>
      /// Get States By Country Id Method Using Stored Procedure
      /// </summary>
        public async Task<List<StateData>> GetStateByCountryId(int id)
        {
            try
            {
                var param = new DynamicParameters();
                param.Add("@countryid", id);
                var data = await QueryAsync<StateData>(StoredProcedures.GetStateByCountryId, param, commandType: CommandType.StoredProcedure);
                return data.ToList();
            }
            catch (Exception Exce)
            {
                throw Exce;
            }
        }

        #endregion
    }
}
