using Duende.IdentityModel.OidcClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fumbbl.Api.Components
{
    public class Bugs(HttpClient _httpClient, string _apiBase) : ApiBase(_httpClient, _apiBase)
    {
        public async Task<List<DTO.BugComment>> GetComments(string? id)
        {
            var response = await _httpClient.GetAsync($"{_apiBase}/bug/comments/{id}");
            return await Load<List<DTO.BugComment>>(response) ?? [];
        }

        public async Task<HttpResponseMessage> ReadyForRetest(string taskGid)
        {
            return await _httpClient.PostAsync($"{_apiBase}/bug/readyForRetest/{taskGid}", null);
        }

        public async Task<List<DTO.Bug>> Search()
        {
            var response = await _httpClient.GetAsync($"{_apiBase}/bug/search");
            return await Load<List<DTO.Bug>>(response) ?? [];
        }

        public async Task<HttpResponseMessage> SetBugData(string jsonData)
        {
            var content = new MultipartFormDataContent();
            content.Add(new StringContent(jsonData), "data");

            return await _httpClient.PostAsync($"{_apiBase}/bugs/set", content);
        }

        public async Task SetRef(string? id, string asanaId)
        {
            var content = new MultipartFormDataContent();
            content.Add(new StringContent(asanaId), "ref");

            await _httpClient.PostAsync($"{_apiBase}/bug/setRef/{id}", content);
        }
    }
}
