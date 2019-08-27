using System;
using SiegeApi;
using SiegeApi.Enums;

namespace SiegeApiSample
{
    class Program
    {
        static void Main(string[] args)
        {
            Api api = Api.GetInstance(email: "Your ubisoft email", password: "Your ubisoft password");

            var player = api.GetPlayerByName("Aixel.", Platform.UPLAY).Result;
            Console.WriteLine($"player.ProfileId: {player.ProfileId}");
            Console.WriteLine($"player.UserId: {player.UserId}");
            Console.WriteLine($"player.PlatformType: {player.PlatformType}");
            Console.WriteLine($"player.IdOnPlatform: {player.IdOnPlatform}");
            Console.WriteLine($"player.NameOnPlatform: {player.NameOnPlatform}");

            var rank = player.GetRank(Region.ASIA).Result;
            Console.WriteLine($"rank.MaxMmr: {rank.MaxMmr}");
            Console.WriteLine($"rank.SkillMean: {rank.SkillMean}");
            Console.WriteLine($"rank.MaxMDeathsmr: {rank.Deaths}");
            Console.WriteLine($"rank.ProfileId: {rank.ProfileId}");
            Console.WriteLine($"rank.NextRankMmr: {rank.NextRankMmr}");
            Console.WriteLine($"rank.RankId: {rank.RankId}");
            Console.WriteLine($"rank.MaxRank: {rank.MaxRank}");
            Console.WriteLine($"rank.BoardId: {rank.BoardId}");
            Console.WriteLine($"rank.SkillStdev: {rank.SkillStdev}");
            Console.WriteLine($"rank.Kills: {rank.Kills}");
            Console.WriteLine($"rank.LastMatchSkillStdevChange: {rank.LastMatchSkillStdevChange}");
            Console.WriteLine($"rank.UpdateTime: {rank.UpdateTime}");
            Console.WriteLine($"rank.LastMatchMmrChange: {rank.LastMatchMmrChange}");
            Console.WriteLine($"rank.Abandons: {rank.Abandons}");
            Console.WriteLine($"rank.Season: {rank.Season}");
            Console.WriteLine($"rank.LastMatchSkillMeanChange: {rank.LastMatchSkillMeanChange}");
            Console.WriteLine($"rank.Mmr: {rank.Mmr}");
            Console.WriteLine($"rank.PreviousRankMmr: {rank.PreviousRankMmr}");
            Console.WriteLine($"rank.LastMatchResult: {rank.LastMatchResult}");
            Console.WriteLine($"rank.Wins: {rank.Wins}");
            Console.WriteLine($"rank.Region: {rank.Region}");
            Console.WriteLine($"rank.Losses: {rank.Losses}");
        }
    }
}
