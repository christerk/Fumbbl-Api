using System.Collections.Generic;

namespace Fumbbl.Api.DTO
{
    public record Team
    {
        public int Id { get; set; }
        public Coach Coach { get; set; }
        public Roster Roster { get; set; }
        public string Name { get; set; } = string.Empty;
        public int DivisionId { get; set; }
        public string Division { get; set; } = string.Empty;
        public int League { get; set; }
        public int Rerolls { get; set; }
        public int Ruleset { get; set; }
        public string Status { get; set; } = string.Empty;
        public int TeamValue { get; set; }
        public int Treasury { get; set; }
        public TeamRecord Record { get; set; }
        public Dictionary<string, SpecialRule> SpecialRules { get; set; } = new();
        public List<Player> Players { get; set; } = new();
    }
}
