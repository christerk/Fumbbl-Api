using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fumbbl.Api.Components
{
    public class Auth(HttpClient _httpClient, string _apiBase) : ApiBase(_httpClient, _apiBase)
    {
        public async Task<string?> Generate(string type, int uid, string extra)
        {
            var content = new MultipartFormDataContent();
            content.Add(new StringContent(type), "type");
            content.Add(new StringContent(uid.ToString()), "uid");
            content.Add(new StringContent(extra), "extra");

            var response = await _httpClient.PostAsync($"{_apiBase}/auth/generate", content);

            return await Load<string>(response);
        }
    }
}
