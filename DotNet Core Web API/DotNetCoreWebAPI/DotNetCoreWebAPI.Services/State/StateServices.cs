using DotNetCoreWebAPI.Data.DbRepository.Country;
using DotNetCoreWebAPI.Data.DbRepository.State;
using DotNetCoreWebAPI.Model.ViewModel.State;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetCoreWebAPI.Services.State
{
    public class StateServices : IStateServices
    {
        #region Fields

        private IStateRepository stateRepository;

        #endregion

        #region Constructor

        public StateServices(IStateRepository _stateRepository)
        {
            stateRepository = _stateRepository;
        }

        #endregion

        #region Method

        public async Task<List<StateData>> GetStateListAsync()
        {
            return await stateRepository.GetStateListAsync();
        }

        public async Task<int> AddEditState(StateData stateData)
        {
            return await stateRepository.AddEditState(stateData);
        }

        public async Task<int> DeleteState(int id)
        {
           return await stateRepository.DeleteState(id);
        }

        #endregion
    }
}
