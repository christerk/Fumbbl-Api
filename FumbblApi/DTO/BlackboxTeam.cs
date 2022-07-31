using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fumbbl.Api.DTO
{
    public record BlackboxTeam
    {
        public int TeamId { get; set; }
        public int TeamValue { get; set; }

        public BlackboxTeam(int teamId, int teamValue)
        {
            TeamId = teamId;
            TeamValue = teamValue;
        }
    }
}
