namespace Fumbbl.Api.DTO
{
    public record BlackboxMatch
    {
        public BlackboxTeam Team1 { get; set; } = new(0, 0);
        public BlackboxTeam Team2 { get; set; } = new(0, 0);
        public int Suitability { get; set; }
    }
}