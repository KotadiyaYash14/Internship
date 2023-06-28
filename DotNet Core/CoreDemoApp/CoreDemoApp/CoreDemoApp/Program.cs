using CoreDemoApp;
using CoreDemoApp.Logger;
using CoreDemoApp.Middleware;
using CoreDemoApp.Model.AppSetting;
using CoreDemoApp.Model.Config;
using CoreDemoApp.Services.JWTAuthentication;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.Configure<DataConfig>(builder.Configuration.GetSection("ConnectionStrings"));
RegisterServices.RegisterService(builder.Services);
builder.Services.Configure<AppSetting>(builder.Configuration.GetSection("AppSettings"));
builder.Services.AddSingleton<IJWTAuthenticationServices, JWTAuthenticationServices>();
builder.Services.AddSingleton<ILoggerManager, LoggerManager>();
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseSession();

app.UseMiddleware<CustomMiddleware>();

app.UseAuthentication();

app.UseAuthorization();

//app.MapRazorPages();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Login}/{action=SignIn}/{id?}");

app.Run();
