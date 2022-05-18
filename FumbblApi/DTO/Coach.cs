using System.Text.Json.Serialization;

namespace Fumbbl.Api.DTO
{
    public record Coach
    {
        public int Id { get; set; }
        public string Name { get; set; } = String.Empty;
        public string Rating { get; set; } = String.Empty;
        public bool CanLfg { get; set; } = true;
    }
}