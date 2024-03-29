﻿using System.Text.Json.Serialization;

namespace Fumbbl.Api.DTO
{
    public record CoachTeams
    {
        public int Id { get; set; }
        public string Name { get; set; } = String.Empty;
        public string Ranking { get; set; } = String.Empty;
        public IEnumerable<int>? RecentOpponents { get; set; } = Enumerable.Empty<int>();
        public IEnumerable<Team> Teams { get; set; } = Enumerable.Empty<Team>();
    }
}