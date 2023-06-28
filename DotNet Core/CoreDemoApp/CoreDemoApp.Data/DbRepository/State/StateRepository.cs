using CoreDemoApp.Common.Helpers;
using CoreDemoApp.Model.Config;
using CoreDemoApp.Model.ViewModel.Country;
using CoreDemoApp.Model.ViewModel.State;
using Dapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreDemoApp.Data.DbRepository.State
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

        #region Methods

        /// <summary>
        /// Get All State By Stored Procedure
        /// </summary>
        public async Task<List<StateData>> GetAllState()
        {
            try
            {
                var State = await QueryAsync<StateData>(StoredProcedures.GetAllState, commandType: CommandType.StoredProcedure);
                return State.ToList();
            }
            catch (Exception Exce)
            {
                throw Exce;
            }
        }

        /// <summary>
        /// Delete State Method Using Stored Procedure
        /// </summary>
        public async Task<int> DeleteState(int id)
        {
            try
            {
                var param = new DynamicParameters();
                param.Add("@stateid", id);
                return await ExecuteAsync<int>(StoredProcedures.DeleteState, param, commandType: CommandType.StoredProcedure);
            }
            catch (Exception Exce)
            {
                throw Exce;
            }
        }

        /// <summary>
        /// Add Edit State Method Using Stored Procedure 
        /// </summary>
        public async Task<int> AddEditState(StateData state)
        {
            try
            {
                if (state.StateId == 0)
                {
                    var param = new DynamicParameters();
                    param.Add("@stateid", null);
                    param.Add("@statename", state.StateName);
                    param.Add("@countryid", state.CountryId);
                    return await ExecuteAsync<int>(StoredProcedures.AddEditState, param, commandType: CommandType.StoredProcedure);
                }
                else
                {
                    var param = new DynamicParameters();
                    param.Add("@stateid", state.StateId);
                    param.Add("@statename", state.StateName);
                    param.Add("@countryid", state.CountryId);
                    var State = await ExecuteAsync<int>(StoredProcedures.AddEditState, param, commandType: CommandType.StoredProcedure);
                    return State;
                }
            }
            catch (Exception Exce)
            {
                throw Exce;
            }
        }

        /// <summary>
        /// Get State By Id Method Using Strored Procedure
        /// </summary>
        public async Task<StateData> GetStateById(int id)
        {
            try
            {
                var param = new DynamicParameters();
                param.Add("@stateid", id);
                return await QueryFirstOrDefaultAsync<StateData>(StoredProcedures.GetStateById, param, commandType: CommandType.StoredProcedure);
            }
            catch (Exception Exce)
            {
                throw Exce;
            }
        }
    }

    #endregion
}
