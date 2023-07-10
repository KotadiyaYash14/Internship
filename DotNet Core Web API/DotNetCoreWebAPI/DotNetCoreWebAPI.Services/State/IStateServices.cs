using DotNetCoreWebAPI.Model.ViewModel.State;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetCoreWebAPI.Services.State
{
    public interface IStateServices
    {
        Task<List<StateData>> GetStateListAsync();

        Task<int> AddEditState(StateData stateData);

        Task<int> DeleteState(int id);
    }
}
