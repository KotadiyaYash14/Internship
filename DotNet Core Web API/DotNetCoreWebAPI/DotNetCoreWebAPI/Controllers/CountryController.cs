using DotNetCoreWebAPI.Common.GlobalEnum;
using DotNetCoreWebAPI.Common.Helpers;
using DotNetCoreWebAPI.Data.DbRepository.Country;
using DotNetCoreWebAPI.Services.Country;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DotNetCoreWebAPI.Controllers
{
    [Route("api/Country")]
    [ApiController]
    [Authorize]
    public class CountryController : Controller
    {
        #region Fields

        private ICountryServices countryServices;

        #endregion

        #region Constructor

        public CountryController(ICountryServices _countryServices)
        {
            countryServices = _countryServices;
        }

        #endregion

        #region Method

        [HttpGet("CountryList")]
        public async Task<ApiResponse<CountryData>> GetCountryList()
        {
            ApiResponse<CountryData> response = new ApiResponse<CountryData>()
            {
                Data = new List<CountryData>()
            };
            var country = await countryServices.GetCountryListAsync();

            if (country != null)
            {
                response.Data = country;
            }
            response.Success = true;
            response.Message = BaseApiMessage.CountryFetched;
            return response;
        }

        [HttpPost("AddEditCountry")]
        public async Task<BaseApiResponse> AddEditCountry(CountryData countryData)
        {
            BaseApiResponse response = new BaseApiResponse();
            var result = await countryServices.AddEditCountry(countryData);

            if (result == (int)CountryEnum.AddCountry)
            {
                response.Message = BaseApiMessage.AddCountry;
                response.Success = true;
            }
            else if (result == (int)CountryEnum.EditCountry)
            {
                response.Message = BaseApiMessage.EditCountry;
                response.Success = true;
            }
            else if(result == (int)CountryEnum.AlreadyExists)
            {
                response.Message = BaseApiMessage.CountryAlreadyExists;
                response.Success = true;
            }
            else{
                response.Message = BaseApiMessage.SomethingWentWrong;
                response.Success = true;
            }
            return response;
        }

        [HttpDelete("DeleteCountry")]
        public async Task<BaseApiResponse> DeleteCountry(int id)
        {
            BaseApiResponse response = new BaseApiResponse();
            var result = await countryServices.DeleteCountry(id);

            if (result == (int)DeleteCountryEnum.DeleteCountry)
            {
                response.Success = true;
                response.Message = BaseApiMessage.DeleteCountry;
            }
            else if(result == (int)DeleteCountryEnum.SomethingWentWrong) 
            {
                response.Success = true;
                response.Message = BaseApiMessage.SomethingWentWrong;
            }
            else if (result == (int)DeleteCountryEnum.DoesNotExists)
            {
                response.Success = true;
                response.Message = BaseApiMessage.CountryDoesNotExists;
            }
            else
            {
                response.Success = true;
                response.Message = BaseApiMessage.CountryInUse;
            }
                return response;
        }

        #endregion
    }
}
