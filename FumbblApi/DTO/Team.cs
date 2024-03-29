﻿using System.Collections.Generic;

namespace Fumbbl.Api.DTO
{
    public record Team
    {
        public int Id { get; set; }
        public int CoachId { get; set; }
        public Coach? Coach { get; set; }
        public Roster? Roster { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Race { get; set; } = string.Empty;
        public int DivisionId { get; set; }
        public string Division { get; set; } = string.Empty;
        public bool Competitive { get; set; }
        public int? LeagueId { get; set; }
        public string? League { get; set; }
        public int? LastOpponent { get; set; }
        public int Rerolls { get; set; }
        public int RulesetId { get; set; }
        public string Status { get; set; } = string.Empty;
        public int TeamValue { get; set; }
        public int CurrentTeamValue { get; set; }
        public int TeamValueReduction { get; set; }
        public int SchedulingTeamValue { get; set; }
        public int Treasury { get; set; }
        public TeamRecord Record { get; set; } = TeamRecord.Empty;
        public Dictionary<string, SpecialRule> SpecialRules { get; set; } = new();
        public IEnumerable<Player> Players { get; set; } = Enumerable.Empty<Player>();
        public string IsLfg { get; set; } = string.Empty;
        public string CanLfg { get; set; } = string.Empty;
        public string LfgMode { get; set; } = string.Empty;
        public IEnumerable<RaceLogo> RaceLogos { get; set; } = Enumerable.Empty<RaceLogo>();
        public Season? Season { get; set; }
        public Tournament? Tournament { get; set; }
        public Options Options { get; set; } = new();
        public TvLimit TvLimit { get; set; } = new();
    }
}
