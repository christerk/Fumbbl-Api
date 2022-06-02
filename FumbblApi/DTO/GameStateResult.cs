namespace Fumbbl.Api.DTO
{
    public record GameStateResult
    {
        public string Result { get; set; } = string.Empty;
        public string Message { get; set; } = string.Empty;
        public int GameId { get; set; }

        public Dictionary<string, object> Options = new Dictionary<string, object>();
    }
}