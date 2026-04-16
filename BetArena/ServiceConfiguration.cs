namespace BetArena;

public static class ServiceConfiguration
{
    public static void AddBetArenaServices(this IServiceCollection services)
    {
        services.AddSingleton<IBetService, BetService>();
        services.AddSingleton<IStatsCalculator, StatsCalculator>();
    }
}
