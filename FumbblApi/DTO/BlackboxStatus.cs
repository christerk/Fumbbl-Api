using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fumbbl.Api.DTO
{
    public record BlackboxStatus
    {
        public HashSet<int> Coaches { get; set; } = new();
    }
}
