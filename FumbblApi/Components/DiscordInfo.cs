using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fumbbl.Api.Components
{
    public class DiscordInfo(HttpClient _httpClient, string _apiBase) : ApiBase(_httpClient, _apiBase)
    {
        public async Task<int?> Get(ulong userId)
        {
            var response = await _httpClient.GetAsync($"{_apiBase}/discordinfo/get/{userId}");

            return await Load<int>(response);
        }

        public async Task<string?> GetName(ulong discordId)
        {
            var response = await _httpClient.GetAsync($"{_apiBase}/discordinfo/getName/{discordId}");

            return await Load<string>(response);
        }

        public async Task RefreshPatron(ulong id)
        {
            await _httpClient.PostAsync($"{_apiBase}/discordinfo/refreshPatron/{id}", null);
        }
    }
}
