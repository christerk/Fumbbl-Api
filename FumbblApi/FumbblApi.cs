using Fumbbl.Api.Components;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fumbbl.Api
{
    public class FumbblApi
    {
        public readonly Auth Auth;
        public readonly Blackbox Blackbox;
        public readonly Bugs Bugs;
        public readonly Coach Coach;
        public readonly DiscordGuildInfo DiscordGuildInfo;
        public readonly DiscordInfo DiscordInfo;
        public readonly GameState GameState;
        public readonly Group Group;
        public readonly Match Match;
        public readonly OAuth OAuth;
        public readonly Replay Replay;

        public FumbblApi(IConfiguration config, HttpClient httpClient)
        {
            var _httpClient = httpClient;
            var _apiBase = config["Fumbbl:OAuth:base"] ?? string.Empty;

            Auth = new(_httpClient, _apiBase);
            Blackbox = new(_httpClient, _apiBase);
            Coach = new(_httpClient, _apiBase);
            DiscordGuildInfo = new(_httpClient, _apiBase);
            DiscordInfo = new(_httpClient, _apiBase);
            GameState = new(_httpClient, _apiBase);
            Group = new(_httpClient, _apiBase);
            Match = new(_httpClient, _apiBase);
            OAuth = new(_httpClient, _apiBase);
            Replay = new(_httpClient, _apiBase);
            Bugs = new(_httpClient, _apiBase);
        }
    }
}
