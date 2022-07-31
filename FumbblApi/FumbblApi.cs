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
        private readonly HttpClient _httpClient;
        private readonly string _apiBase;

        public readonly Coach Coach;
        public readonly Blackbox Blackbox;
        public readonly GameState GameState;
        public readonly OAuth OAuth;

        public FumbblApi(IConfiguration config, HttpClient httpClient)
        {
            _httpClient = httpClient;
            _apiBase = config["Fumbbl:OAuth:base"];

            Blackbox = new(_httpClient, _apiBase);
            Coach = new(_httpClient, _apiBase);
            GameState = new(_httpClient, _apiBase);
            OAuth = new(_httpClient, _apiBase);
        }


    }
}
