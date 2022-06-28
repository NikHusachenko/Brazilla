using Brazilla.EntityFramework;
using Brazilla.EntityFramework.Repository;
using Brazilla.Services.AuthenticationServices;
using Brazilla.Services.BlendServices;
using Brazilla.Services.BlendServices.Models;
using Brazilla.Services.BlendTypeServices;
using Brazilla.Services.BlendTypeServices.Models;
using Brazilla.Services.UserServices;
using Brazilla.Services.UserServices.Models;
using Brazilla.Web.Models.User;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;

// Add services to the container.
services.AddMvc()
    .AddFluentValidation();

string connectionString = builder.Configuration.GetSection("ConnectionStrings:DefaultConnection").Value;
services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connectionString));
services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));
services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.AccessDeniedPath = "/User/SignIn";
        options.LogoutPath = "/User/SignIn";
        options.LoginPath = "/User/SignIn";
        options.ExpireTimeSpan = TimeSpan.FromDays(7);
    });

#region Services
services.AddTransient<IBlendService, BlendService>();
services.AddTransient<IBlendTypeService, BlendTypeService>();
services.AddTransient<IUserService, UserService>();
services.AddTransient<IAuthenticationService, AuthenticationService>();
services.AddTransient<IHttpContextAccessor, HttpContextAccessor>();
services.AddTransient<ICurrentUser, CurrentUser>();
#endregion

#region Validation
services.AddTransient<IValidator<SignUpViewModel>, SignUpValidator>();
services.AddTransient<IValidator<SignInViewModel>, SignInValidator>();
services.AddTransient<IValidator<SettingsViewModel>, SettingsValidator>();
services.AddTransient<IValidator<CreateViewModel>, CreateValidator>();
#endregion

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
