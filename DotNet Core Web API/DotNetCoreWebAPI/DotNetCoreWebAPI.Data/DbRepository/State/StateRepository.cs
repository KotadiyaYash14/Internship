using Dapper;
using DotNetCoreWebAPI.Common.Helpers;
using DotNetCoreWebAPI.Data.DbRepository.Country;
using DotNetCoreWebAPI.Model.DataConfig;
using DotNetCoreWebAPI.Model.ViewModel.State;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetCoreWebAPI.Data.DbRepository.State
{
    public class StateRepository : BaseRepository, IStateRepository
    {
        #region Fields

        private readonly IConfiguration _configuration;

        #endregion

        #region Constructor

        public StateRepository(IConfiguration configuration, IOptions<DataConfig> dataconfig) : base(dataconfig, configuration)
        {
            _configuration = configuration;
        }

        #endregion

        #region Method

        public async Task<List<StateData>> GetStateListAsync()
        {
            var state = await QueryAsync<StateData>(StoredProcedure.StateList, commandType: CommandType.StoredProcedure);
            return state.ToList();
        }

        public async Task<int> AddEditState(StateData stateData)
        {
            var param = new DynamicParameters();
            param.Add("@stateid", stateData.StateId);
            param.Add("@statename", stateData.StateName);
            param.Add("@countryid", stateData.CountryId);
            var state = await QueryFirstOrDefaultAsync<int>(StoredProcedure.AddEditState, param, commandType: CommandType.StoredProcedure);
            return state;
        }

        public async Task<int> DeleteState(int id)
        {
            var param = new DynamicParameters();
            param.Add("@stateid", id);
            return await QueryFirstOrDefaultAsync<int>(StoredProcedure.DeleteState,param,commandType: CommandType.StoredProcedure);
        }

        #endregion
    }
}
