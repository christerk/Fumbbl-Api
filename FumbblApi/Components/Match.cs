using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fumbbl.Api.Components
{
    public class Match : ApiBase
    {
        public Match(HttpClient httpClient, string apiBase) : base(httpClient, apiBase)
        {
        }

        public async Task<List<DTO.Match>?> ListAsync(int? latestId = null)
        {
            var response = await _httpClient.GetAsync($"{_apiBase}/match/list{(latestId is not null ? "/" + latestId : "")}");
            return await Load<List<DTO.Match>>(response);
        }
    }
}
