using Microsoft.AspNetCore.Mvc;


[ApiController]
[Route("api/[controller]")]
public class RiotAccountController : ControllerBase
{
    private readonly RiotApiService _riotApiService;

    public RiotAccountController(RiotApiService riotApiService)
    {
        _riotApiService = riotApiService;
    }

    [HttpGet("{gameName}/{tagLine}")]
    public async Task<IActionResult> GetRiotAccount(string gameName, string tagLine)
    {
        var account = await _riotApiService.GetRiotAccount(gameName, tagLine);
        if (account == null) return NotFound();

        await Task.Delay(2000);

        // Use the puuid to get the summoner account
        var summonerAccount = await _riotApiService.GetSummonerAccount(account.Puuid);
        if (summonerAccount == null) return NotFound();

        // Return both accounts
        return Ok(new
        {
            RiotAccount = account,
            SummonerAccount = summonerAccount
        });
    }
}