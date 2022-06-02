using Fumbbl.Api.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Web;

namespace Fumbbl.Api.Components
{
    public class GameState : ApiBase
    {
        public GameState(HttpClient httpClient, string apiBase) : base(httpClient, apiBase)
        {
        }

        public async Task<DTO.GameStateResult?> CheckAsync(int team1, int team2)
        {
            var response = await _httpClient.GetAsync($"{_apiBase}/gamestate/check/{team1}/{team2}");
            return await Load<DTO.GameStateResult>(response);
        }

        public async Task<DTO.GameStateResult?> OptionsAsync(int team1, int team2)
        {
            var response = await _httpClient.GetAsync($"{_apiBase}/gamestate/options/{team1}/{team2}");
            return await Load<DTO.GameStateResult>(response);
        }

        public async Task<DTO.GameStateResult?> ScheduleAsync(int team1, int team2)
        {
            var response = await _httpClient.PostAsync($"{_apiBase}/gamestate/schedule/{team1}/{team2}", null);
            return await Load<DTO.GameStateResult>(response);
        }

    }
}
