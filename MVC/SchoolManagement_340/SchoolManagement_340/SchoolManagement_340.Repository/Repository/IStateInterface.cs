using SchoolManagement_340.Models.Context;
using SchoolManagement_340.Models.CustomModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement_340.Repository.Repository
{
    public interface IStateInterface
    {
        bool RegisterState(CustomState data, int? id);
        List<sp_getStateList_Result> GetStates();
        int DeleteState(int? id);
        CustomState GetStateById(int? id);
        List<State> GetStateByCountry(int? id);
    }
}
