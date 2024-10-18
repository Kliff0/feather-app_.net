using Newtonsoft.Json;
using feather_app_.net.Models;


public class RiotApiService
{
    private readonly HttpClient _httpClient;
    private readonly string _riotApiKey;
    private readonly string _baseURL;
    private readonly IConfiguration _config;

    public RiotApiService(HttpClient httpClient, IConfiguration config)
    {
        _httpClient = httpClient;
        _config = config;
        _riotApiKey = config["RiotApi:ApiKey"];
        _baseURL = config["RiotApi:BaseUrl"];
    }

    public async Task<RiotAccount> GetRiotAccount(string gameName, string tagLine)
    {
        var endpoint = _config["RiotApi:Endpoints:RiotIdEndpoint"];
        var url = "https://americas" + _baseURL + endpoint.Replace("{gameName}", gameName).Replace("{tagLine}", tagLine);
        // Set API key in headers
        _httpClient.DefaultRequestHeaders.Add("X-Riot-Token", _riotApiKey);


        var response = await _httpClient.GetAsync(url);
        if (!response.IsSuccessStatusCode) return null;
        var jsonString = await response.Content.ReadAsStringAsync();
        var riotAccount = JsonConvert.DeserializeObject<RiotAccount>(jsonString);
        return riotAccount;
    }

    public async Task<SummonerAccount> GetSummonerAccount(string encryptedPUUID)
    {
        var endpoint = _config["RiotApi:Endpoints:SummonerEndpoint"];
        var url = "https://OC1" + _baseURL + endpoint.Replace("{encryptedPUUID}", encryptedPUUID);
        _httpClient.DefaultRequestHeaders.Add("X-Riot-Token", _riotApiKey);
        var response = await _httpClient.GetAsync(url);
        Console.WriteLine(response);
        if (!response.IsSuccessStatusCode) return null;
        var jsonString = await response.Content.ReadAsStringAsync();
        var summonerAccount = JsonConvert.DeserializeObject<SummonerAccount>(jsonString);
        return summonerAccount;
    }
}