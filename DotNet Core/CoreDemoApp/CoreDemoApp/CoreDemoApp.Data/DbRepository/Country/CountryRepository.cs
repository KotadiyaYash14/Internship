using CoreDemoApp.Common.Helpers;
using CoreDemoApp.Model.Config;
using CoreDemoApp.Model.ViewModel.Country;
using Dapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreDemoApp.Data.DbRepository.Country
{
    public class CountryRepository : BaseRepository, ICountryRepository
    {
        #region Fields

        private readonly IConfiguration _configuration;

        #endregion

        #region Constructor

        public CountryRepository(IConfiguration configuration, IOptions<DataConfig> dataconfig) : base(dataconfig, configuration)
        {
            _configuration = configuration;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Get All Country By Stored Procedure
        /// </summary>
        public async Task<List<CountryData>> GetAllCountry()
        {
            try
            {
                var Country = await QueryAsync<CountryData>(StoredProcedures.GetAllCountry, commandType: CommandType.StoredProcedure);
                return Country.ToList();
            }
            catch (Exception Exce)
            {
                throw Exce;
            }
        }

        /// <summary>
        /// Add Edit Country Method Using Stored Procedure 
        /// </summary>
        public async Task<int> AddEditCountry(CountryData country)
        {
            try
            {
                if (country.CountryId == 0)
                {
                    var param = new DynamicParameters();
                    param.Add("@countryid", null);
                    param.Add("@countryname", country.CountryName);
                    return await ExecuteAsync<int>(StoredProcedures.AddEditCountry, param, commandType: CommandType.StoredProcedure);
                }
                else
                {
                    var param = new DynamicParameters();
                    param.Add("@countryid", country.CountryId);
                    param.Add("@countryname", country.CountryName);
                    var Country = await ExecuteAsync<int>(StoredProcedures.AddEditCountry, param, commandType: CommandType.StoredProcedure);
                    return Country;
                }
            }
            catch (Exception Exce)
            {
                throw Exce;
            }
        }

        /// <summary>
        /// Get Country By Id Method Using Strored Procedure
        /// </summary>
        public async Task<CountryData> GetCountryById(int id)
        {
            try
            {
                var param = new DynamicParameters();
                param.Add("@countryid", id);
                return await QueryFirstOrDefaultAsync<CountryData>(StoredProcedures.GetCountryById, param, commandType: CommandType.StoredProcedure);
            }
            catch (Exception Exce)
            {
                throw Exce;
            }
        }

        /// <summary>
        /// Delete Country Method Using Stored Procedure
        /// </summary>
        public async Task<int> DeleteCountry(int id)
        {
            try
            {
                var param = new DynamicParameters();
                param.Add("@countryid", id);
                return await ExecuteAsync<int>(StoredProcedures.DeleteCountry, param, commandType: CommandType.StoredProcedure);
            }
            catch (Exception Exce)
            {
                throw Exce;
            }
        }

        #endregion
    }
}
