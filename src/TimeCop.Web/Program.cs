using Microsoft.EntityFrameworkCore;
using TimeCop.TimeSheet;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<TimeSheetDbContext>
    (options => options.UseNpgsql(builder.Configuration.GetConnectionString("TimeSheet")));

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();
