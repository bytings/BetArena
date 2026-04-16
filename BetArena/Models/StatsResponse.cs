namespace BetArena.Models;

public class StatsResponse
{
    public List<GameStats> Games { get; set; } = new();
    public List<BetStats> Users { get; set; } = new();
}
