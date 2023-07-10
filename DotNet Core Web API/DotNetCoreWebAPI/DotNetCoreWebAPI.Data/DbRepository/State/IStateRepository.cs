using DotNetCoreWebAPI.Data.DbRepository.Country;
using DotNetCoreWebAPI.Model.ViewModel.State;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetCoreWebAPI.Data.DbRepository.State
{
    public interface IStateRepository
    {
        Task<List<StateData>> GetStateListAsync();

        Task<int> AddEditState(StateData stateData);

        Task<int> DeleteState(int id);
    }
}
