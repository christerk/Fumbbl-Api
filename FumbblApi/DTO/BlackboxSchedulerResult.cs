using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fumbbl.Api.DTO
{
    public record BlackboxSchedulerResult
    {
        public Dictionary<int, List<BlackboxTeam>> Activated { get; set; } = new();
        public List<BlackboxMatch> PossibleMatches { get; set; } = new();
        public List<BlackboxMatch> ScheduledMatches { get; set; } = new();

        public void AddActivatedTeam(int coachId, BlackboxTeam team)
        {
            if (!Activated.ContainsKey(coachId))
            {
                Activated.Add(coachId, new() { team });
            }
            else
            {
                Activated[coachId].Add(team);
            }
        }
    }
}
