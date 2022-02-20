using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fumbbl.Api.Components
{
    public class OAuth
    {
        private HttpClient _httpClient;
        private string _apiBase;

        public OAuth(HttpClient httpClient, string apiBase)
        {
            _httpClient = httpClient;
            _apiBase = apiBase;
        }

        public async Task<int> Identity()
        {
            var response = await _httpClient.GetAsync($"{_apiBase}/oauth/identity");

            return int.Parse(await response.Content.ReadAsStringAsync());
        }
    }
}
