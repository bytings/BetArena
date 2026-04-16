namespace BetArena.Services;

public class StatsCalculator : IStatsCalculator
{
    public StatsResponse CalculateStats(IEnumerable<Bet> bets)
    {
        var betList = bets.ToList();

        var gameStats = CalculateGameStats(betList);
        var userStats = CalculateUserStats(betList);

        return new StatsResponse
        {
            Games = gameStats,
            Users = userStats
        };
    }

    public double CalculateRTP(IEnumerable<Bet> gameBets)
    {
        var betList = gameBets.ToList();

        if (!betList.Any())
        {
            return 0;
        }

        var totalStake = betList.Sum(b => b.Stake);
        var totalWin = betList.Sum(b => b.WinAmount);

        if (totalStake == 0)
        {
            return 0;
        }

        // RTP = (Total Win / Total Stake) * 100
        var rtp = ((double)totalWin / (double)totalStake) * 100;
        return Math.Round(rtp, 2);
    }

    private List<GameStats> CalculateGameStats(List<Bet> bets)
    {
        return bets
            .GroupBy(b => b.Game)
            .Select(g => new GameStats
            {
                Game = g.Key,
                RTP = CalculateRTP(g)
            })
            .ToList();
    }

    private List<BetStats> CalculateUserStats(List<Bet> bets)
    {
        return bets
            .GroupBy(b => b.UserId)
            .Select(g => new BetStats
            {
                UserId = g.Key,
                TotalStake = g.Sum(b => b.Stake),
                TotalWin = g.Sum(b => b.WinAmount)
            })
            .ToList();
    }
}
