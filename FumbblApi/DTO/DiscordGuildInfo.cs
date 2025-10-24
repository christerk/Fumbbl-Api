using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fumbbl.Api.DTO
{
    public record DiscordGuildInfo(string? ResultsChannel, string? VerifiedRole, List<int> Groups, bool DisplayAllResults);
}
