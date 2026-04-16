using BetArena.Controllers;
using BetArena.Models;
using BetArena.Services;
using Microsoft.AspNetCore.Mvc;

namespace BetArena.Tests;

#region ==================== TESTS UNITARIOS: VALIDACIONES ====================

/// <summary>
/// Tests unitarios para validaciones de apuestas (VS-001 a VS-012)
/// Valida: Stake, UserId, Game, WinAmount
/// </summary>
public class BetServiceValidationTests : IDisposable
{
    private readonly BetService _betService;

    public BetServiceValidationTests()
    {
        _betService = new BetService();
    }

    public void Dispose()
    {
        // Limpieza si es necesaria
    }

    #region Validación de Stake (VS-001 a VS-003)

    [Fact(DisplayName = "VS-001: Stake válido y positivo debe registrar apuesta")]
    public void RegisterBet_WithValidPositiveStake_ReturnsTrue()
    {
        // Arrange
        var bet = new Bet { UserId = 1, Game = "Roulette", Stake = 100, WinAmount = 250 };

        // Act
        var result = _betService.RegisterBet(bet, out var error);

        // Assert
        Assert.True(result);
        Assert.Empty(error);
    }

    [Fact(DisplayName = "VS-002: Stake igual a cero debe rechazar apuesta")]
    public void RegisterBet_WithZeroStake_ReturnsFalseAndError()
    {
        // Arrange
        var bet = new Bet { UserId = 1, Game = "Roulette", Stake = 0, WinAmount = 250 };

        // Act
        var result = _betService.RegisterBet(bet, out var error);

        // Assert
        Assert.False(result);
        Assert.NotEmpty(error);
        Assert.Contains("mayor a 0", error);
    }

    [Fact(DisplayName = "VS-003: Stake negativo debe rechazar apuesta")]
    public void RegisterBet_WithNegativeStake_ReturnsFalseAndError()
    {
        // Arrange
        var bet = new Bet { UserId = 1, Game = "Roulette", Stake = -50, WinAmount = 250 };

        // Act
        var result = _betService.RegisterBet(bet, out var error);

        // Assert
        Assert.False(result);
        Assert.Contains("mayor a 0", error);
    }

    #endregion

    #region Validación de UserId (VS-004 a VS-006)

    [Fact(DisplayName = "VS-004: UserId válido y positivo debe registrar apuesta")]
    public void RegisterBet_WithValidPositiveUserId_ReturnsTrue()
    {
        // Arrange
        var bet = new Bet { UserId = 1, Game = "Blackjack", Stake = 50, WinAmount = 100 };

        // Act
        var result = _betService.RegisterBet(bet, out var error);

        // Assert
        Assert.True(result);
        Assert.Empty(error);
    }

    [Fact(DisplayName = "VS-005: UserId igual a cero debe rechazar apuesta")]
    public void RegisterBet_WithZeroUserId_ReturnsFalseAndError()
    {
        // Arrange
        var bet = new Bet { UserId = 0, Game = "Roulette", Stake = 100, WinAmount = 250 };

        // Act
        var result = _betService.RegisterBet(bet, out var error);

        // Assert
        Assert.False(result);
        Assert.Contains("userId debe ser mayor a 0", error);
    }

    [Fact(DisplayName = "VS-006: UserId negativo debe rechazar apuesta")]
    public void RegisterBet_WithNegativeUserId_ReturnsFalseAndError()
    {
        // Arrange
        var bet = new Bet { UserId = -1, Game = "Roulette", Stake = 100, WinAmount = 250 };

        // Act
        var result = _betService.RegisterBet(bet, out var error);

        // Assert
        Assert.False(result);
        Assert.NotEmpty(error);
    }

    #endregion

    #region Validación de Game (VS-007 a VS-009)

    [Fact(DisplayName = "VS-007: Game válido no vacío debe registrar apuesta")]
    public void RegisterBet_WithValidGame_ReturnsTrue()
    {
        // Arrange
        var bet = new Bet { UserId = 1, Game = "Slots", Stake = 75, WinAmount = 150 };

        // Act
        var result = _betService.RegisterBet(bet, out var error);

        // Assert
        Assert.True(result);
        Assert.Empty(error);
    }

    [Fact(DisplayName = "VS-008: Game vacío debe rechazar apuesta")]
    public void RegisterBet_WithEmptyGame_ReturnsFalseAndError()
    {
        // Arrange
        var bet = new Bet { UserId = 1, Game = string.Empty, Stake = 100, WinAmount = 250 };

        // Act
        var result = _betService.RegisterBet(bet, out var error);

        // Assert
        Assert.False(result);
        Assert.Contains("no puede estar vacío", error);
    }

    [Fact(DisplayName = "VS-009: Game solo espacios debe rechazar apuesta")]
    public void RegisterBet_WithWhitespaceGame_ReturnsFalseAndError()
    {
        // Arrange
        var bet = new Bet { UserId = 1, Game = "   ", Stake = 100, WinAmount = 250 };

        // Act
        var result = _betService.RegisterBet(bet, out var error);

        // Assert
        Assert.False(result);
        Assert.Contains("no puede estar vacío", error);
    }

    #endregion

    #region Validación de WinAmount (VS-010 a VS-012)

    [Fact(DisplayName = "VS-010: WinAmount válido en cero debe registrar apuesta")]
    public void RegisterBet_WithZeroWinAmount_ReturnsTrue()
    {
        // Arrange
        var bet = new Bet { UserId = 1, Game = "Roulette", Stake = 100, WinAmount = 0 };

        // Act
        var result = _betService.RegisterBet(bet, out var error);

        // Assert
        Assert.True(result);
        Assert.Empty(error);
    }

    [Fact(DisplayName = "VS-011: WinAmount válido y positivo debe registrar apuesta")]
    public void RegisterBet_WithPositiveWinAmount_ReturnsTrue()
    {
        // Arrange
        var bet = new Bet { UserId = 1, Game = "Blackjack", Stake = 50, WinAmount = 250 };

        // Act
        var result = _betService.RegisterBet(bet, out var error);

        // Assert
        Assert.True(result);
        Assert.Empty(error);
    }

    [Fact(DisplayName = "VS-012: WinAmount negativo debe rechazar apuesta")]
    public void RegisterBet_WithNegativeWinAmount_ReturnsFalseAndError()
    {
        // Arrange
        var bet = new Bet { UserId = 1, Game = "Roulette", Stake = 100, WinAmount = -50 };

        // Act
        var result = _betService.RegisterBet(bet, out var error);

        // Assert
        Assert.False(result);
        Assert.Contains("no puede ser negativo", error);
    }

    #endregion
}

#endregion

#region ==================== TESTS UNITARIOS: FUNCIONAMIENTO ====================

/// <summary>
/// Tests unitarios para funcionalidad de almacenamiento (FS-001 a FS-003)
/// </summary>
public class BetServiceFunctionalityTests : IDisposable
{
    private readonly BetService _betService;

    public BetServiceFunctionalityTests()
    {
        _betService = new BetService();
    }

    public void Dispose()
    {
        // Limpieza
    }

    [Fact(DisplayName = "FS-001: Registrar apuesta válida retorna true sin error")]
    public void RegisterBet_ValidBet_ReturnsTrueAndEmptyError()
    {
        // Arrange
        var bet = new Bet { UserId = 1, Game = "Roulette", Stake = 100, WinAmount = 50 };

        // Act
        var result = _betService.RegisterBet(bet, out var error);

        // Assert
        Assert.True(result);
        Assert.Empty(error);
    }

    [Fact(DisplayName = "FS-002: GetAllBets devuelve la apuesta registrada")]
    public void GetAllBets_AfterRegisteringBet_ReturnsBetInCollection()
    {
        // Arrange
        var bet = new Bet { UserId = 1, Game = "Blackjack", Stake = 50, WinAmount = 100 };
        _betService.RegisterBet(bet, out _);

        // Act
        var bets = _betService.GetAllBets().ToList();

        // Assert
        Assert.Single(bets);
        Assert.Equal(1, bets[0].UserId);
        Assert.Equal("Blackjack", bets[0].Game);
    }

    [Fact(DisplayName = "FS-003: Registrar múltiples apuestas retorna todas")]
    public void RegisterBet_MultipleBets_AllBetsReturnedByGetAllBets()
    {
        // Arrange
        var bet1 = new Bet { UserId = 1, Game = "Roulette", Stake = 100, WinAmount = 150 };
        var bet2 = new Bet { UserId = 2, Game = "Slots", Stake = 50, WinAmount = 0 };
        var bet3 = new Bet { UserId = 1, Game = "Blackjack", Stake = 75, WinAmount = 200 };

        _betService.RegisterBet(bet1, out _);
        _betService.RegisterBet(bet2, out _);
        _betService.RegisterBet(bet3, out _);

        // Act
        var bets = _betService.GetAllBets().ToList();

        // Assert
        Assert.Equal(3, bets.Count);
    }
}

#endregion

#region ==================== TESTS UNITARIOS: CÁLCULO RTP ====================

/// <summary>
/// Tests unitarios para cálculo de RTP (RTP-001 a RTP-005)
/// RTP = (Total Win / Total Stake) * 100
/// </summary>
public class StatsCalculatorRTPTests : IDisposable
{
    private readonly StatsCalculator _statsCalculator;

    public StatsCalculatorRTPTests()
    {
        _statsCalculator = new StatsCalculator();
    }

    public void Dispose()
    {
        // Limpieza
    }

    [Fact(DisplayName = "RTP-001: RTP con bets válidas (50 Win / 100 Stake = 50%)")]
    public void CalculateRTP_WithValidBets_ReturnsCorrectPercentage()
    {
        // Arrange
        var bets = new List<Bet>
        {
            new Bet { UserId = 1, Game = "Roulette", Stake = 100, WinAmount = 50 }
        };

        // Act
        var rtp = _statsCalculator.CalculateRTP(bets);

        // Assert
        Assert.Equal(50.0, rtp);
    }

    [Fact(DisplayName = "RTP-002: RTP con múltiples bets (150 Win / 200 Stake = 75%)")]
    public void CalculateRTP_WithMultipleBets_ReturnsAggregatedRTP()
    {
        // Arrange
        var bets = new List<Bet>
        {
            new Bet { UserId = 1, Game = "Roulette", Stake = 100, WinAmount = 50 },
            new Bet { UserId = 2, Game = "Roulette", Stake = 100, WinAmount = 100 }
        };

        // Act
        var rtp = _statsCalculator.CalculateRTP(bets);

        // Assert
        Assert.Equal(75.0, rtp); // (50 + 100) / (100 + 100) * 100
    }

    [Fact(DisplayName = "RTP-003: RTP con ganancia total (200 Win / 100 Stake = 200%)")]
    public void CalculateRTP_WithTotalWin_ReturnsRTPGreaterThan100()
    {
        // Arrange
        var bets = new List<Bet>
        {
            new Bet { UserId = 1, Game = "Slots", Stake = 100, WinAmount = 200 }
        };

        // Act
        var rtp = _statsCalculator.CalculateRTP(bets);

        // Assert
        Assert.Equal(200.0, rtp);
    }

    [Fact(DisplayName = "RTP-004: RTP sin bets retorna 0")]
    public void CalculateRTP_WithEmptyBets_ReturnsZero()
    {
        // Arrange
        var bets = new List<Bet>();

        // Act
        var rtp = _statsCalculator.CalculateRTP(bets);

        // Assert
        Assert.Equal(0, rtp);
    }

    [Fact(DisplayName = "RTP-005: RTP con decimales se redondea correctamente")]
    public void CalculateRTP_WithDecimalValues_ReturnsRoundedValue()
    {
        // Arrange
        var bets = new List<Bet>
        {
            new Bet { UserId = 1, Game = "Poker", Stake = 100.50m, WinAmount = 50.25m }
        };

        // Act
        var rtp = _statsCalculator.CalculateRTP(bets);

        // Assert - (50.25 / 100.50) * 100 ≈ 50.0
        Assert.Equal(50.0, rtp);
    }
}

#endregion

#region ==================== TESTS UNITARIOS: ESTADÍSTICAS ====================

/// <summary>
/// Tests unitarios para estadísticas de usuarios y juegos (USTATS, GSTATS)
/// </summary>
public class StatsCalculatorAggregationTests : IDisposable
{
    private readonly StatsCalculator _statsCalculator;

    public StatsCalculatorAggregationTests()
    {
        _statsCalculator = new StatsCalculator();
    }

    public void Dispose()
    {
        // Limpieza
    }

    #region Estadísticas por Usuario

    [Fact(DisplayName = "USTATS-001: Un usuario, una apuesta")]
    public void CalculateStats_SingleUserSingleBet_ReturnsCorrectUserStats()
    {
        // Arrange
        var bets = new List<Bet>
        {
            new Bet { UserId = 1, Game = "Roulette", Stake = 100, WinAmount = 50 }
        };

        // Act
        var stats = _statsCalculator.CalculateStats(bets);

        // Assert
        Assert.Single(stats.Users);
        Assert.Equal(1, stats.Users[0].UserId);
        Assert.Equal(100, stats.Users[0].TotalStake);
        Assert.Equal(50, stats.Users[0].TotalWin);
    }

    [Fact(DisplayName = "USTATS-002: Un usuario, múltiples apuestas")]
    public void CalculateStats_SingleUserMultipleBets_ReturnAggregatedStats()
    {
        // Arrange
        var bets = new List<Bet>
        {
            new Bet { UserId = 1, Game = "Roulette", Stake = 100, WinAmount = 150 },
            new Bet { UserId = 1, Game = "Blackjack", Stake = 50, WinAmount = 0 },
            new Bet { UserId = 1, Game = "Slots", Stake = 150, WinAmount = 250 }
        };

        // Act
        var stats = _statsCalculator.CalculateStats(bets);

        // Assert
        Assert.Single(stats.Users);
        Assert.Equal(300, stats.Users[0].TotalStake); // 100 + 50 + 150
        Assert.Equal(400, stats.Users[0].TotalWin);   // 150 + 0 + 250
    }

    [Fact(DisplayName = "USTATS-003: Múltiples usuarios con estadísticas independientes")]
    public void CalculateStats_MultipleUsers_ReturnIndependentStats()
    {
        // Arrange
        var bets = new List<Bet>
        {
            new Bet { UserId = 1, Game = "Roulette", Stake = 100, WinAmount = 50 },
            new Bet { UserId = 2, Game = "Blackjack", Stake = 50, WinAmount = 100 },
            new Bet { UserId = 1, Game = "Slots", Stake = 75, WinAmount = 0 }
        };

        // Act
        var stats = _statsCalculator.CalculateStats(bets);

        // Assert
        Assert.Equal(2, stats.Users.Count);

        var user1 = stats.Users.First(u => u.UserId == 1);
        Assert.Equal(175, user1.TotalStake);
        Assert.Equal(50, user1.TotalWin);

        var user2 = stats.Users.First(u => u.UserId == 2);
        Assert.Equal(50, user2.TotalStake);
        Assert.Equal(100, user2.TotalWin);
    }

    [Fact(DisplayName = "USTATS-004: Sin apuestas retorna lista vacía")]
    public void CalculateStats_WithoutBets_ReturnsEmptyUserStats()
    {
        // Arrange
        var bets = new List<Bet>();

        // Act
        var stats = _statsCalculator.CalculateStats(bets);

        // Assert
        Assert.Empty(stats.Users);
    }

    #endregion

    #region Estadísticas por Juego

    [Fact(DisplayName = "GSTATS-001: Un juego, una apuesta")]
    public void CalculateStats_SingleGameSingleBet_ReturnsCorrectGameStats()
    {
        // Arrange
        var bets = new List<Bet>
        {
            new Bet { UserId = 1, Game = "Roulette", Stake = 100, WinAmount = 50 }
        };

        // Act
        var stats = _statsCalculator.CalculateStats(bets);

        // Assert
        Assert.Single(stats.Games);
        Assert.Equal("Roulette", stats.Games[0].Game);
        Assert.Equal(50.0, stats.Games[0].RTP);
    }

    [Fact(DisplayName = "GSTATS-002: Un juego, múltiples apuestas con RTP agregado")]
    public void CalculateStats_SingleGameMultipleBets_ReturnAggregatedRTP()
    {
        // Arrange
        var bets = new List<Bet>
        {
            new Bet { UserId = 1, Game = "Roulette", Stake = 100, WinAmount = 50 },
            new Bet { UserId = 2, Game = "Roulette", Stake = 100, WinAmount = 100 }
        };

        // Act
        var stats = _statsCalculator.CalculateStats(bets);

        // Assert
        Assert.Single(stats.Games);
        Assert.Equal("Roulette", stats.Games[0].Game);
        Assert.Equal(75.0, stats.Games[0].RTP); // (50 + 100) / 200 * 100
    }

    [Fact(DisplayName = "GSTATS-003: Múltiples juegos con RTP independiente")]
    public void CalculateStats_MultipleGames_ReturnIndependentRTP()
    {
        // Arrange
        var bets = new List<Bet>
        {
            new Bet { UserId = 1, Game = "Roulette", Stake = 100, WinAmount = 50 },
            new Bet { UserId = 1, Game = "Blackjack", Stake = 100, WinAmount = 200 },
            new Bet { UserId = 2, Game = "Roulette", Stake = 100, WinAmount = 100 }
        };

        // Act
        var stats = _statsCalculator.CalculateStats(bets);

        // Assert
        Assert.Equal(2, stats.Games.Count);

        var roulette = stats.Games.First(g => g.Game == "Roulette");
        Assert.Equal(75.0, roulette.RTP); // (50 + 100) / 200

        var blackjack = stats.Games.First(g => g.Game == "Blackjack");
        Assert.Equal(200.0, blackjack.RTP); // 200 / 100
    }

    #endregion
}

#endregion

#region ==================== TESTS DE INTEGRACIÓN: API CONTROLLER ====================

/// <summary>
/// Tests de integración para el controlador API (API-POST-001 a API-POST-005, API-GET-001 a API-GET-003)
/// </summary>
public class BetsControllerIntegrationTests : IDisposable
{
    private readonly BetsController _controller;
    private readonly BetService _betService;
    private readonly StatsCalculator _statsCalculator;

    public BetsControllerIntegrationTests()
    {
        _betService = new BetService();
        _statsCalculator = new StatsCalculator();
        _controller = new BetsController(_betService, _statsCalculator);
    }

    public void Dispose()
    {
        // Limpieza
    }

    #region Tests POST /api/bets

    [Fact(DisplayName = "API-POST-001: Apuesta válida retorna 200 OK")]
    public void RegisterBet_WithValidBet_Returns200OK()
    {
        // Arrange
        var bet = new Bet
        {
            UserId = 1,
            Game = "Roulette",
            Stake = 100,
            WinAmount = 50
        };

        // Act
        var result = _controller.RegisterBet(bet);

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result);
        Assert.Equal(200, okResult.StatusCode);
    }

    [Fact(DisplayName = "API-POST-002: Stake inválido retorna 400 Bad Request")]
    public void RegisterBet_WithInvalidStake_Returns400BadRequest()
    {
        // Arrange
        var bet = new Bet
        {
            UserId = 1,
            Game = "Roulette",
            Stake = 0,
            WinAmount = 50
        };

        // Act
        var result = _controller.RegisterBet(bet);

        // Assert
        var badResult = Assert.IsType<BadRequestObjectResult>(result);
        Assert.Equal(400, badResult.StatusCode);
    }

    [Fact(DisplayName = "API-POST-003: Game vacío retorna 400 Bad Request")]
    public void RegisterBet_WithEmptyGame_Returns400BadRequest()
    {
        // Arrange
        var bet = new Bet
        {
            UserId = 1,
            Game = string.Empty,
            Stake = 100,
            WinAmount = 50
        };

        // Act
        var result = _controller.RegisterBet(bet);

        // Assert
        var badResult = Assert.IsType<BadRequestObjectResult>(result);
        Assert.Equal(400, badResult.StatusCode);
    }

    [Fact(DisplayName = "API-POST-004: UserId inválido retorna 400 Bad Request")]
    public void RegisterBet_WithInvalidUserId_Returns400BadRequest()
    {
        // Arrange
        var bet = new Bet
        {
            UserId = 0,
            Game = "Roulette",
            Stake = 100,
            WinAmount = 50
        };

        // Act
        var result = _controller.RegisterBet(bet);

        // Assert
        var badResult = Assert.IsType<BadRequestObjectResult>(result);
        Assert.Equal(400, badResult.StatusCode);
    }

    [Fact(DisplayName = "API-POST-005: WinAmount negativo retorna 400 Bad Request")]
    public void RegisterBet_WithNegativeWinAmount_Returns400BadRequest()
    {
        // Arrange
        var bet = new Bet
        {
            UserId = 1,
            Game = "Roulette",
            Stake = 100,
            WinAmount = -50
        };

        // Act
        var result = _controller.RegisterBet(bet);

        // Assert
        var badResult = Assert.IsType<BadRequestObjectResult>(result);
        Assert.Equal(400, badResult.StatusCode);
    }

    #endregion

    #region Tests GET /api/bets/stats

    [Fact(DisplayName = "API-GET-001: Sin apuestas retorna Games y Users vacíos")]
    public void GetStats_WithoutBets_ReturnsEmptyCollections()
    {
        // Act
        var result = _controller.GetStats();

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result);
        var response = Assert.IsType<StatsResponse>(okResult.Value);
        Assert.Empty(response.Games);
        Assert.Empty(response.Users);
    }

    [Fact(DisplayName = "API-GET-002: Con apuestas retorna datos correctos")]
    public void GetStats_WithBets_ReturnsCorrectStats()
    {
        // Arrange
        var bet1 = new Bet { UserId = 1, Game = "Roulette", Stake = 100, WinAmount = 50 };
        var bet2 = new Bet { UserId = 1, Game = "Blackjack", Stake = 50, WinAmount = 100 };

        _betService.RegisterBet(bet1, out _);
        _betService.RegisterBet(bet2, out _);

        // Act
        var result = _controller.GetStats();

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result);
        var response = Assert.IsType<StatsResponse>(okResult.Value);

        Assert.Equal(2, response.Games.Count);
        Assert.Single(response.Users);
        Assert.Equal(150, response.Users[0].TotalStake);
        Assert.Equal(150, response.Users[0].TotalWin);
    }

    [Fact(DisplayName = "API-GET-003: Múltiples usuarios y juegos con agrupaciones correctas")]
    public void GetStats_WithMultipleUsersAndGames_ReturnsCorrectAggregation()
    {
        // Arrange
        var bets = new List<Bet>
        {
            new Bet { UserId = 1, Game = "Roulette", Stake = 100, WinAmount = 50 },
            new Bet { UserId = 2, Game = "Roulette", Stake = 100, WinAmount = 100 },
            new Bet { UserId = 1, Game = "Blackjack", Stake = 50, WinAmount = 0 }
        };

        foreach (var bet in bets)
        {
            _betService.RegisterBet(bet, out _);
        }

        // Act
        var result = _controller.GetStats();

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result);
        var response = Assert.IsType<StatsResponse>(okResult.Value);

        Assert.Equal(2, response.Games.Count);
        Assert.Equal(2, response.Users.Count);

        // Verificar Roulette RTP
        var roulette = response.Games.First(g => g.Game == "Roulette");
        Assert.Equal(75.0, roulette.RTP); // (50 + 100) / 200 * 100

        // Verificar User 1 stats
        var user1 = response.Users.First(u => u.UserId == 1);
        Assert.Equal(150, user1.TotalStake);
        Assert.Equal(50, user1.TotalWin);
    }

    #endregion
}

#endregion

#region ==================== TESTS EDGE CASES ====================

/// <summary>
/// Tests para casos extremos (Edge Cases)
/// EDGE-001 a EDGE-006
/// </summary>
public class EdgeCaseTests : IDisposable
{
    private readonly StatsCalculator _statsCalculator;
    private readonly BetService _betService;

    public EdgeCaseTests()
    {
        _statsCalculator = new StatsCalculator();
        _betService = new BetService();
    }

    public void Dispose()
    {
        // Limpieza
    }

    [Fact(DisplayName = "EDGE-001: Números decimales muy pequeños (0.01)")]
    public void RegisterBet_WithSmallDecimalStake_AcceptsValue()
    {
        // Arrange
        var bet = new Bet { UserId = 1, Game = "Slots", Stake = 0.01m, WinAmount = 0.01m };

        // Act
        var result = _betService.RegisterBet(bet, out _);

        // Assert
        Assert.True(result);
    }

    [Fact(DisplayName = "EDGE-002: Números muy grandes (999999.99)")]
    public void RegisterBet_WithLargeDecimalStake_AcceptsValue()
    {
        // Arrange
        var bet = new Bet { UserId = 1, Game = "Poker", Stake = 999999.99m, WinAmount = 500000 };

        // Act
        var result = _betService.RegisterBet(bet, out _);

        // Assert
        Assert.True(result);
    }

    [Fact(DisplayName = "EDGE-003: Game con caracteres especiales")]
    public void RegisterBet_WithSpecialCharactersInGame_AcceptsValue()
    {
        // Arrange
        var bet = new Bet { UserId = 1, Game = "Roulette-Premium@2024", Stake = 100, WinAmount = 50 };

        // Act
        var result = _betService.RegisterBet(bet, out _);

        // Assert
        Assert.True(result);
    }

    [Fact(DisplayName = "EDGE-004: Múltiples juegos del mismo usuario")]
    public void CalculateStats_MultipleGamesPerUser_CorrectlyAggregates()
    {
        // Arrange
        var bets = new List<Bet>
        {
            new Bet { UserId = 1, Game = "Roulette", Stake = 100, WinAmount = 50 },
            new Bet { UserId = 1, Game = "Blackjack", Stake = 50, WinAmount = 100 },
            new Bet { UserId = 1, Game = "Slots", Stake = 75, WinAmount = 0 }
        };

        // Act
        var stats = _statsCalculator.CalculateStats(bets);

        // Assert
        Assert.Single(stats.Users);
        Assert.Equal(225, stats.Users[0].TotalStake);
        Assert.Equal(150, stats.Users[0].TotalWin);
        Assert.Equal(3, stats.Games.Count);
    }

    [Fact(DisplayName = "EDGE-005: RTP > 100% (ganancias mayores que stakes)")]
    public void CalculateRTP_WithWinGreaterThanStake_ReturnsRTPGreaterThan100()
    {
        // Arrange
        var bets = new List<Bet>
        {
            new Bet { UserId = 1, Game = "Slots", Stake = 100, WinAmount = 500 }
        };

        // Act
        var rtp = _statsCalculator.CalculateRTP(bets);

        // Assert
        Assert.Equal(500.0, rtp);
    }

    [Fact(DisplayName = "EDGE-006: Valores cero en stake y win (apuesta perdida sin ganancia)")]
    public void RegisterBet_WithZeroWinAndPositiveStake_AcceptsValue()
    {
        // Arrange
        var bet = new Bet { UserId = 1, Game = "Roulette", Stake = 100, WinAmount = 0 };

        // Act
        var result = _betService.RegisterBet(bet, out _);

        // Assert
        Assert.True(result);
    }
}

#endregion
