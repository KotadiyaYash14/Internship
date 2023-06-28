using CoreDemoApp.Data.DbRepository.State;
using CoreDemoApp.Model.ViewModel.State;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreDemoApp.Services.State
{
    public class StateServices : IStateServices
    {
        #region Fields

        public IStateRepository stateRepository;

        #endregion

        #region Constructor

        public StateServices (IStateRepository _stateRepository)
        {
            stateRepository = _stateRepository;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Get All State Method
        /// </summary>
        public async Task<List<StateData>> GetAllState()
        {
            return await stateRepository.GetAllState();
        }

        /// <summary>
        /// Delete State Method
        /// </summary>
        public async Task<int> DeleteState(int id)
        {
            return await stateRepository.DeleteState(id);
        }

        /// <summary>
        /// Add Edit State Method
        /// </summary>
        public async Task<int> AddEditState(StateData state)
        {
           return await stateRepository.AddEditState(state);
        }

        /// <summary>
        /// Get State By Id Method
        /// </summary>
        public async Task<StateData> GetStateById(int id)
        {
            return await stateRepository.GetStateById(id);
        }

        #endregion
    }
}
