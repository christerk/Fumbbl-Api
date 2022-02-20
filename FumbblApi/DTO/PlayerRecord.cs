namespace Fumbbl.Api.DTO
{
    public record PlayerRecord
    {
        public int Completions { get; set; }
        public int Touchdowns { get; set; }
        public int Interceptions { get; set; }
        public int Casualties { get; set; }
        public int Mvps { get; set; }
        public int Spp { get; set; }
    }
}