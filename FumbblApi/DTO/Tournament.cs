namespace Fumbbl.Api.DTO
{
    public record Tournament
    {
        public int Id { get; set; } = 0;
        public IEnumerable<int> Opponents { get; set; } = Enumerable.Empty<int>();

    }
}