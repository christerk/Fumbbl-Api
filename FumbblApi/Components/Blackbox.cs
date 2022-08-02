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
    public class Blackbox : ApiBase
    {
        public Blackbox(HttpClient httpClient, string apiBase) : base(httpClient, apiBase)
        {
        }

        public async Task<DTO.BlackboxStatus?> StatusAsync()
        {
            var response = await _httpClient.GetAsync($"{_apiBase}/blackbox/status");
            return await Load<DTO.BlackboxStatus>(response);
        }

        public async Task ReportRoundAsync(DTO.BlackboxSchedulerResult result)
        {
            IList<KeyValuePair<string, string>> data = new List<KeyValuePair<string, string>>()
            {
                { new KeyValuePair<string, string>("data", JsonSerializer.Serialize(result)) }
            };
            HttpContent content = new FormUrlEncodedContent(data);
            await _httpClient.PostAsync($"{_apiBase}/blackbox/reportround", content);
        }

        public async Task startActivationsAsync()
        {
            var response = await _httpClient.PostAsync($"{_apiBase}/blackbox/startActivations", null);
        }


    }
}
