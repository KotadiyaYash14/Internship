using SchoolManagement_340.Models.Context;
using SchoolManagement_340.Models.CustomModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement_340.Helper.SignUpHelper
{
    public class StateHelper
    {
        public State ConvertCustomStateToState(CustomState data)
        {
            State state = new State()
            {  
              StateId = data.StateId,
              StateName = data.StateName,
              CountryId = data.CountryId
            };
            return state;
        }
        public CustomState ConvertStateToCustomState(State data)
        {
            CustomState cs = new CustomState()
            {
                StateId = data.StateId,
                StateName =data.StateName,
                CountryId = (int)data.CountryId
            };
            return cs;
        }
    }
}
