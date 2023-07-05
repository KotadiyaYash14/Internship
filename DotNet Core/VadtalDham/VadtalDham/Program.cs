using VadtalDham;
using VadtalDham.Logger;
using VadtalDham.Middleware;
using VadtalDham.Model.AppSetting;
using VadtalDham.Model.Config;
using VadtalDham.Model.SMTPSetting;
using VadtalDham.Services.JWTAuthentication;

var builder = WebApplication.CreateBuilder(args);
builder.Services.Configure<DataConfig>(builder.Configuration.GetSection("ConnectionStrings"));
RegisterServices.RegisterService(builder.Services);
builder.Services.Configure<SMTPSetting>(builder.Configuration.GetSection("SMTPSettings"));
builder.Services.Configure<AppSetting>(builder.Configuration.GetSection("AppSettings"));
builder.Services.AddSingleton<IJWTAuthenticationServices, JWTAuthenticationServices>();
builder.Services.AddSingleton<ILoggerManager, LoggerManager>();
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

// Add services to the container.
builder.Services.AddControllersWithViews();

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

app.UseAuthorization();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Login}/{action=SignIn}/{id?}");

app.Run();
