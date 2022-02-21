using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Fumbbl.Api.Components
{
    public abstract class ApiBase
    {
        protected HttpClient _httpClient;
        protected string _apiBase;
        private JsonSerializerOptions _jsonOptions;

        public ApiBase(HttpClient httpClient, string apiBase)
        {
            _httpClient = httpClient;
            _apiBase = apiBase;
            _jsonOptions = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
            };
        }

        protected async Task<T?> Load<T>(HttpResponseMessage? response)
        {
            if (response is null)
            {
                return default(T);
            }

            string? json = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
            {
                var message = JsonSerializer.Deserialize<string>(json);
                throw new Exception(message);
            }


            var result = JsonSerializer.Deserialize<T>(json, _jsonOptions);
            return result;
        }
    }
}
