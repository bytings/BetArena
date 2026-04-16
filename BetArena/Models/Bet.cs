namespace BetArena.Models;

public class Bet
{
    public int UserId { get; set; }
    public string Game { get; set; } = string.Empty;
    public decimal Stake { get; set; }
    public decimal WinAmount { get; set; }
}
