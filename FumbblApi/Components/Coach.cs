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
    public class Coach : ApiBase
    {
        public Coach(HttpClient httpClient, string apiBase) : base(httpClient, apiBase)
        {
        }

        public async Task<DTO.Coach?> GetAsync(int coachId)
        {
            var response = await _httpClient.GetAsync($"{_apiBase}/coach/get/{coachId}");
            return await Load<DTO.Coach>(response);
        }

        public async Task<IEnumerable<DTO.Coach>> SearchAsync(string term)
        {
            var response = await _httpClient.GetAsync($"{_apiBase}/coach/search/{HttpUtility.UrlEncode(term)}");
            return await Load<IEnumerable<DTO.Coach>>(response) ?? new List<DTO.Coach>();
        }

        public async Task<DTO.CoachTeams?> TeamsAsync(int coachId)
        {
            var response = await _httpClient.GetAsync($"{_apiBase}/coach/teams/{coachId}");
            return await Load<DTO.CoachTeams>(response);
        }

        public async Task<DTO.CoachTeams?> LfgTeamsAsync(int coachId)
        {
            var response = await _httpClient.GetAsync($"{_apiBase}/coach/lfgteams/{coachId}");
            return await Load<DTO.CoachTeams>(response);
        }

    }
}
