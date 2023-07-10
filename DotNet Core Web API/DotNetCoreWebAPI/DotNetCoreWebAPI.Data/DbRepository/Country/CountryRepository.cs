using Dapper;
using DotNetCoreWebAPI.Common.Helpers;
using DotNetCoreWebAPI.Model.DataConfig;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetCoreWebAPI.Data.DbRepository.Country
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

        #region Method

        public async Task<List<CountryData>> GetCountryListAsync()
        {
            var country = await QueryAsync<CountryData>(StoredProcedure.CountryList, commandType: CommandType.StoredProcedure);
            return country.ToList();
        }

        public async Task<int> AddEditCountry(CountryData countryData)
        {
            var param = new DynamicParameters();
            param.Add("@countryid", countryData.CountryId);
            param.Add("@countryname", countryData.CountryName);
            var success = await QueryFirstOrDefaultAsync<int>(StoredProcedure.AddEditCountry, param, commandType: CommandType.StoredProcedure);
            return success;
        }

        public async Task<int> DeleteCountry(int id)
        {
            var param = new DynamicParameters();
            param.Add("@countryid", id);
            return await QueryFirstOrDefaultAsync<int>(StoredProcedure.DeleteCountry, param, commandType: CommandType.StoredProcedure);
        }

        #endregion
    }
}
