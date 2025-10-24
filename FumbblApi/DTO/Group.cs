using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fumbbl.Api.DTO
{
    public record Group
    {
        public int Id { get; set; }
        public string Name { get; set; } = String.Empty;
        public int Owner { get; set; }
        public string Type { get; set; } = String.Empty;
        public string Score { get; set; } = String.Empty;
        public int Ruleset { get; set; }
        public List<int> Staff { get; set; } = [];
    }
}
