using SchoolManagement_340.Helper.SignUpHelper;
using SchoolManagement_340.Models.Context;
using SchoolManagement_340.Models.CustomModel;
using SchoolManagement_340.Repository.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement_340.Repository.Services
{
    public class StateServices : IStateInterface
    {
        SchoolManagement_yk_340Entities db = new SchoolManagement_yk_340Entities();
        StateHelper sh = new StateHelper();

        public int DeleteState(int? id)
        {
            var success = db.City.Any(x => x.StateId == id);
            if(success == true)
            {
                return 0;
            }
            else
            {
                db.sp_delete_state(id);
                return 1;
            }
        }
        public List<State> GetStateByCountry(int? id)
        {
            return db.State.Where(x => x.CountryId == id).ToList();
        }

        public CustomState GetStateById(int? id)
        {
            State state = db.State.Where(x => x.StateId == id).FirstOrDefault();
            CustomState cs = sh.ConvertStateToCustomState(state);
            return cs;
        }
        public List<sp_getStateList_Result> GetStates()
        {
            return db.sp_getStateList().ToList();
        }
        public bool RegisterState(CustomState data, int? id)
        {
            if(data != null)
            {
                if(id == 0)
                {
                    if (db.State.Any(x => x.StateName.ToLower() == data.StateName.ToLower()) == false)
                    {
                        db.sp_add_edit_state(0, data.StateName, data.CountryId);
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    db.sp_add_edit_state(data.StateId, data.StateName, data.CountryId);
                    return true;
                }
            }
            else
            {
                return false;
            }
        }
    }
}
