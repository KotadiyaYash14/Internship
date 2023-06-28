using CoreDemoApp.Model.ViewModel.State;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreDemoApp.Services.State
{
    public interface IStateServices
    {
        Task<List<StateData>> GetAllState();

        Task<int> DeleteState(int id);

        Task<StateData> GetStateById(int id);

        Task<int> AddEditState(StateData state);
    }
}
