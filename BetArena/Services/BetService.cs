namespace BetArena.Services;

public class BetService : IBetService
{
    private readonly List<Bet> _bets = new();

    public bool RegisterBet(Bet bet, out string error)
    {
        error = string.Empty;

        // Validar que el stake sea mayor a 0
        if (bet.Stake <= 0)
        {
            error = "El stake debe ser mayor a 0.";
            return false;
        }

        // Validar que el userId sea válido
        if (bet.UserId <= 0)
        {
            error = "El userId debe ser mayor a 0.";
            return false;
        }

        // Validar que el game no esté vacío
        if (string.IsNullOrWhiteSpace(bet.Game))
        {
            error = "El juego no puede estar vacío.";
            return false;
        }

        // Validar que el winAmount no sea negativo
        if (bet.WinAmount < 0)
        {
            error = "El winAmount no puede ser negativo.";
            return false;
        }

        // Guardar la apuesta en memoria
        _bets.Add(bet);
        return true;
    }

    public IEnumerable<Bet> GetAllBets()
    {
        return _bets.AsReadOnly();
    }
}
