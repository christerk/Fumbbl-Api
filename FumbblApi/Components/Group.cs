using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fumbbl.Api.Components
{
    public class Group(HttpClient _httpClient, string _apiBase) : ApiBase(_httpClient, _apiBase)
    {
        public async Task<DTO.Group?> Get(int groupId)
        {
            var response = await _httpClient.GetAsync($"{_apiBase}/group/get/{groupId}");

            return await Load<DTO.Group>(response);
        }
    }
}
