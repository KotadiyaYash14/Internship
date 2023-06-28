using CoreDemoApp.Model.ViewModel.Country;
using CoreDemoApp.Model.ViewModel.State;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreDemoApp.Data.DbRepository.State
{
    public interface IStateRepository
    {
        Task<List<StateData>> GetAllState();

        Task<int> DeleteState(int id);

        Task<StateData> GetStateById(int id);

        Task<int> AddEditState(StateData state);
    }
}
