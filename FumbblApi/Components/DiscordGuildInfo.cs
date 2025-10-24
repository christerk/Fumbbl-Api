using Duende.IdentityModel.OidcClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Fumbbl.Api.Components
{
    public class DiscordGuildInfo(HttpClient _httpClient, string _apiBase) : ApiBase(_httpClient, _apiBase)
    {
        public async Task<DTO.DiscordGuildInfo?> Get(ulong guildId)
        {
            var response = await _httpClient.GetAsync($"{_apiBase}/discordguildinfo/get/{guildId}");

            return await Load<DTO.DiscordGuildInfo>(response);
        }

        public async Task<DTO.DiscordGuildInfo?> Save(ulong guildId, DTO.DiscordGuildInfo guildInfo)
        {
            IList<KeyValuePair<string, string>> data = new List<KeyValuePair<string, string>>()
            {
                { new KeyValuePair<string, string>("data", JsonSerializer.Serialize(guildInfo)) }
            };
            HttpContent content = new FormUrlEncodedContent(data);

            var response = await _httpClient.PostAsync($"{_apiBase}/discordguildinfo/set/{guildId}", content);

            return await Load<DTO.DiscordGuildInfo>(response);
        }
    }
}
