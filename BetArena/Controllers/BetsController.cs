using Microsoft.AspNetCore.Mvc;

namespace BetArena.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BetsController : ControllerBase
{
    private readonly IBetService _betService;
    private readonly IStatsCalculator _statsCalculator;

    public BetsController(IBetService betService, IStatsCalculator statsCalculator)
    {
        _betService = betService;
        _statsCalculator = statsCalculator;
    }

    [HttpPost]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    public IActionResult RegisterBet([FromBody] Bet bet)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        if (!_betService.RegisterBet(bet, out var error))
        {
            return BadRequest(new { message = error });
        }

        return Ok(new { message = "Apuesta registrada exitosamente." });
    }

    [HttpGet("stats")]
    [ProducesResponseType(200)]
    public IActionResult GetStats()
    {
        var bets = _betService.GetAllBets();
        var stats = _statsCalculator.CalculateStats(bets);

        return Ok(stats);
    }
}
