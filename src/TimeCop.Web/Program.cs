using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.EntityFrameworkCore;
using Npgsql;
using Serilog;
using TimeCop.Identity;
using TimeCop.Identity.Data;
using TimeCop.Identity.Models;
using TimeCop.TimeSheet.Infrastructure;
using TimeCop.TimeSheet.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseSerilog(WriteLogs());

builder.Services.AddTransient<IEmailSender, TimeCop.Identity.EmailSender>();
builder.Services.AddDbContext<UserDbContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("Identity"),b=>b.UseNodaTime());
    
});
//NpgsqlConnection.GlobalTypeMapper.UseNodaTime();

builder.Services.AddDbContext<TimeSheetDbContext>
    (options => options.UseNpgsql(builder.Configuration.GetConnectionString("TimeSheet"), b => b.UseNodaTime()));

builder.Services.AddIdentity<ApplicationUser, IdentityRole>(options => options.SignIn.RequireConfirmedAccount = false)
    //.AddDefaultUI()
    .AddSignInManager()
    .AddEntityFrameworkStores<UserDbContext>()
    .AddDefaultTokenProviders();

builder.Services.AddRazorPages();

builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IBankHolidayService,BankHolidayService>();

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseStatusCodePagesWithReExecute("/errors/{0}");
    app.UseExceptionHandler("/error");
}
else
{
    app.UseStatusCodePagesWithReExecute("/errors/{0}");
    app.UseExceptionHandler("/error");
    app.UseHsts();
}

//app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages();

app.Run();

static Action<HostBuilderContext, LoggerConfiguration> WriteLogs()
    => (webHostBuilderContext, logger) =>
    {
        logger.ReadFrom.Configuration(webHostBuilderContext.Configuration);
    };
