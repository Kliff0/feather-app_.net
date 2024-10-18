using System;

namespace feather_app_.net.Models;

public class RiotAccount
{
    public string GameName { get; set; }
    public string TagLine { get; set; }
    public string Puuid { get; set; }
}

public class SummonerAccount
{
    public string AccountId { get; set; }
    public int ProfileIconId { get; set; }
    public long RevisionDate { get; set; }
    public string SummonerId { get; set; }
    public string Puuid { get; set; }
    public long SummonerLevel { get; set; }
}
