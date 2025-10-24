using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fumbbl.Api.DTO
{
    public record Bug(string? Id, string? Ref, string? Status, string? ReportDate, string? Title, string? Score, List<Tag>? Tags);
    public class Tag : List<string>;
    }
