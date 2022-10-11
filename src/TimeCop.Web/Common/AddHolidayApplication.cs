using TimeCop.TimeSheet.Application;
using TimeCop.TimeSheet.Infrastructure;

namespace TimeCop.Web.Common;

public static class HolidayApplicationInjection
{
    public static IServiceCollection AddHolidayApplication(this IServiceCollection services)
    {
        services.AddScoped<IHolidayRepository, HolidayRepository>();
        services.AddScoped<IHolidayService, HolidayService>();

        return services;
    }
}
