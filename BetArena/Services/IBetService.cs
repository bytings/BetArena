namespace BetArena.Services;

public interface IBetService
{
    bool RegisterBet(Bet bet, out string error);
    IEnumerable<Bet> GetAllBets();
}
