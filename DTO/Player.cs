using Skill = System.String;

namespace Fumbbl.Api.DTO
{
    public record Player
    {
        public int Id { get; set; }
        public int Number { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Position { get; set; } = string.Empty;
        public int PositionId { get; set; }
        public PlayerRecord Record { get; set; } = new PlayerRecord();
        public string Injuries { get; set; } = string.Empty;
        public List<Skill> Skills { get; set; } = new();
    }
}