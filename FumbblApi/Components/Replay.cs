using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fumbbl.Api.Components
{
    public class Replay : ApiBase
    {
        public Replay(HttpClient httpClient, string apiBase) : base(httpClient, apiBase)
        {
        }

        public async Task<Stream?> GetAsync(int replayId)
        {
            var response = await _httpClient.GetAsync($"{_apiBase}/replay/get/{replayId}/gz");
            return await LoadStream(response);
        }
    }
}
