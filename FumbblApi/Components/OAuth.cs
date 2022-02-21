using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fumbbl.Api.Components
{
    public class OAuth : ApiBase
    {
        public OAuth(HttpClient httpClient, string apiBase) : base(httpClient, apiBase)
        {
        }

        public async Task<int> Identity()
        {
            var response = await _httpClient.GetAsync($"{_apiBase}/oauth/identity");

            return int.Parse(await response.Content.ReadAsStringAsync());
        }
    }
}
