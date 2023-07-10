using DotNetCoreWebAPI.Common.GlobalEnum;
using DotNetCoreWebAPI.Common.Helpers;
using DotNetCoreWebAPI.Data.DbRepository.Country;
using DotNetCoreWebAPI.Model.ViewModel.State;
using DotNetCoreWebAPI.Services.Country;
using DotNetCoreWebAPI.Services.State;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DotNetCoreWebAPI.Controllers
{
    [Route("api/State")]
    [ApiController]
    [Authorize]
    public class StateController : Controller
    {
        #region Fields

        private IStateServices stateServices;

        #endregion

        #region Constructor

        public StateController(IStateServices _stateServices)
        {
            stateServices = _stateServices;
        }

        #endregion

        #region Method


        [HttpGet("StateList")]
        public async Task<ApiResponse<StateData>> GetStateList()
        {
            ApiResponse<StateData> response = new ApiResponse<StateData>()
            {
                Data = new List<StateData>()
            };
            var state = await stateServices.GetStateListAsync();

            if (state != null)
            {
                response.Data = state;
            }
            response.Success = true;
            response.Message = BaseApiMessage.StateFetched;
            return response;
        }

        [HttpPost("AddEditState")]
        public async Task<BaseApiResponse> AddEditState(StateData stateData)
        {
            BaseApiResponse response = new BaseApiResponse();
            var result = await stateServices.AddEditState(stateData);

            if (result == (int)StateEnum.AddState)
            {
                response.Message = BaseApiMessage.AddState;
                response.Success = true;
            }
            else if (result == (int)StateEnum.EditState)
            {
                response.Message = BaseApiMessage.EditState;
                response.Success = true;
            }
            else if (result == (int)StateEnum.AlreadyExists)
            {
                response.Message = BaseApiMessage.StateAlreadyExists;
                response.Success = true;
            }
            else
            {
                response.Message = BaseApiMessage.SomethingWentWrong;
                response.Success = true;
            }
            return response;
        }

        [HttpDelete("DeleteState")]
        public async Task<BaseApiResponse> DeleteState(int id)
        {
            BaseApiResponse response = new BaseApiResponse();
            var result = await stateServices.DeleteState(id);

            if (result == (int)DeleteStateEnum.DeleteState)
            {
                response.Success = true;
                response.Message = BaseApiMessage.DeleteState;
            }
            else if (result == (int)DeleteStateEnum.SomethingWentWrong)
            {
                response.Success = true;
                response.Message = BaseApiMessage.SomethingWentWrong;
            }
            else if (result == (int)DeleteStateEnum.DoesNotExists)
            {
                response.Success = true;
                response.Message = BaseApiMessage.StateDoesNotExists;
            }
            else
            {
                response.Success = true;
                response.Message = BaseApiMessage.StateInUse;
            }
            return response;
        }
        #endregion
    }
}
