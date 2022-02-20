using Fumbbl.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FumbblApiTest
{
    public class ApiFixture : IDisposable
    {
        public FumbblApi Fumbbl;

        public ApiFixture(FumbblApi fumbbl)
        {
            Fumbbl = fumbbl;
        }
        public void Dispose()
        {
        }
    }
}
