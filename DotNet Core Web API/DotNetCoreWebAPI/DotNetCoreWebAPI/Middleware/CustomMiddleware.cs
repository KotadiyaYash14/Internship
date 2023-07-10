using DotNetCoreWebAPI.Common.CommonMethods;
using DotNetCoreWebAPI.Common.Helpers;
using DotNetCoreWebAPI.Logger;
using DotNetCoreWebAPI.Model.AppSettings;
using DotNetCoreWebAPI.Model.RequestResponse;
using DotNetCoreWebAPI.Model.Token;
using DotNetCoreWebAPI.Services.JWTAuthentication;
using DotNetCoreWebAPI.Services.UserPanel;
using Microsoft.Extensions.Options;
using Microsoft.Net.Http.Headers;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace DotNetCoreWebAPI.Middleware
{
    public class CustomMiddleware
    {
        #region Fields

        private readonly ILoggerManager _logger;
        private readonly RequestDelegate _next;
        private readonly Microsoft.AspNetCore.Hosting.IHostingEnvironment _hostingEnvironment;
        private readonly IJWTAuthenticationServices _jwtAuthenticationService;
        private IConfiguration _config;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly AppSetting _appSettings;

        #endregion

        #region Constructor

        public CustomMiddleware(RequestDelegate next, IHttpContextAccessor httpContextAccessor, IOptions<AppSetting> appSettings,
            Microsoft.AspNetCore.Hosting.IHostingEnvironment hostingEnvironment, IJWTAuthenticationServices jwtAuthenticationService,
            IConfiguration config,
            ILoggerManager logger)
        {
            _next = next;
            _hostingEnvironment = hostingEnvironment;
            _jwtAuthenticationService = jwtAuthenticationService;
            _config = config;
            _httpContextAccessor = httpContextAccessor;
            _appSettings = appSettings.Value;
            _logger = logger;
        }

        #endregion

        #region Methods

        public async Task Invoke(HttpContext context, UserPanelServices _userpanelServices)
        {
            try
            {
                var HttpContextBody = context.Request.Body;
                string requestBody = string.Empty;

                context.Request.EnableBuffering();

                using (var reader = new StreamReader(
                    context.Request.Body,
                    encoding: Encoding.UTF8,
                    detectEncodingFromByteOrderMarks: false,
                    bufferSize: -1,
                    leaveOpen: true))
                {
                    var body = await reader.ReadToEndAsync();

                    context.Request.Headers.Add("requestModel", body);
                    context.Request.Body.Position = 0;
                }
                // Delete files from folder for logs of request and response older than 7 days.
                DeleteOldReqResLogFiles();

                // Check JWT Token validity expiry
                string jwtToken = context.Request.Headers[HeaderNames.Authorization].ToString().Replace("Bearer ", "");
                if (!string.IsNullOrEmpty(jwtToken))
                {
                    UserTokenModel userTokenModel = _jwtAuthenticationService.GetUserTokenData(jwtToken);
                    var result = await _userpanelServices.ValidateUserTokenData(userTokenModel.UserId, jwtToken, userTokenModel.TokenValidTo);
                    if (result == 1)
                    {
                        if (userTokenModel != null)
                        {
                            if (userTokenModel.TokenValidTo < DateTime.UtcNow.AddMinutes(1))
                            {
                                context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                                return;
                            }
                        }
                    }
                    else
                    {
                        context.Response.StatusCode = StatusCodes.Status403Forbidden;
                        return;
                    }
                }
                AddReqResLogsToLoggerFile(context);
                //throw new Exception("Navigating to catch block intentionally");
                await _next(context);
            }
            catch (Exception ex)
            {
                // Add error logs in folder
                AddExceptionLogsToFiles(ex, context);
                await HandleExceptionAsync(context, ex);
                AddExceptionLogsToLoggerFile(context, ex);
            }
        }

        public void DeleteOldReqResLogFiles()
        {
            var directoryPath = Path.Combine(_hostingEnvironment.WebRootPath, "ReqResLogs");
            if (!Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
            }
            string[] files = Directory.GetFiles(directoryPath);

            foreach (string file in files)
            {
                FileInfo fi = new FileInfo(file);
                if (fi.LastAccessTime < DateTime.Now.AddDays(-7))
                {
                    fi.Delete();
                }
            }
        }

        private Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            return context.Response.WriteAsync(new BaseApiResponse()
            {
                Success = false,
                Message = exception.Message
            }.ToString());

        }

        public void AddExceptionLogsToFiles(Exception ex, HttpContext context)
        {
            //string DirectoryPath = "/Logs/";
            //var BasePath = Path.Combine(_hostingEnvironment.WebRootPath, DirectoryPath);

            var exfilePath = Path.Combine(_hostingEnvironment.WebRootPath, "ExceptionLogs", "Exception_" + Path.GetFileName(DateTime.Now.ToString("dd_MM_yyyy") + ".txt"));
            //var FileName = Path.GetExtension(DateTime.Now.ToString("dd_MM_yyyy"));
            if (!File.Exists(exfilePath))
            {
                var myFile = File.Create(exfilePath);
                myFile.Close();
            }

            using StreamWriter sw = File.AppendText(exfilePath);
            sw.WriteLine("");
            sw.WriteLine("--------------------------------- " + DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt") + " ----------------------------------");
            sw.WriteLine("Requested URL: " + context.Request.Path.Value);
            sw.WriteLine("Exception: " + ex.Message);
            sw.WriteLine("InnerException: " + ex.InnerException);
            sw.WriteLine("Exception Email sent: ");
            if (ex.InnerException != null)
            {
                sw.WriteLine("Exception: " + ex.InnerException.InnerException);
            }
        }

        private void AddExceptionLogsToLoggerFile(HttpContext context, Exception exception)
        {
            ParamValue paramValues = CommonMethod.GetKeyValues(_httpContextAccessor.HttpContext);
            StringBuilder sb = new StringBuilder();
            sb.Append(Environment.NewLine + "Request Params: " + paramValues.HeaderValue +
                      Environment.NewLine + "Query String Params: " + paramValues.QueryStringValue +
                      Environment.NewLine + "Message: " + exception.Message);
            _logger.Error(sb.ToString());
        }

        private async void AddReqResLogsToLoggerFile(HttpContext context)
        {
            try
            {
                var exfilePath = Path.Combine(_hostingEnvironment.WebRootPath, "ReqResLogs", "ReqResLog_" + Path.GetFileName(DateTime.Now.ToString("dd_MM_yyyy") + ".txt"));

                //var FileName = Path.GetExtension(DateTime.Now.ToString("dd_MM_yyyy"));
                if (!File.Exists(exfilePath))
                {
                    var myFile = File.Create(exfilePath);
                    myFile.Close();
                }
                using StreamWriter sw = File.AppendText(exfilePath);
                sw.WriteLine("");
                sw.WriteLine("--------------------------------- " + DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt") + " ----------------------------------");
                sw.WriteLine("Requested URL: " + context.Request.Path.Value);
                sw.WriteLine("Context request: " + context.Request.ContentType);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
    #endregion
}
