namespace BetArena.Services;

public interface IStatsCalculator
{
    StatsResponse CalculateStats(IEnumerable<Bet> bets);
    double CalculateRTP(IEnumerable<Bet> gameBets);
}
