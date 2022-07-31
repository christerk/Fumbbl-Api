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
    }
}
