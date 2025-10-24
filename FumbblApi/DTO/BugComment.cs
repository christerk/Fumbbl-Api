using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fumbbl.Api.DTO
{
    public class BugComment
    {
        public string Id { get; set; } = string.Empty;
        public string Date { get; set; } = string.Empty;
        public string text { get; set; } = string.Empty;
        public string Author { get; set; } = string.Empty;
        public string AuthorId { get; set; } = string.Empty;
        public List<int> Images { get; set; } = [];
        public string Comment { get; set; } = string.Empty;
        public string Note { get; set; } = string.Empty;
    }
}
