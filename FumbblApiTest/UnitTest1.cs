using Fumbbl.Api;
using Xunit;

namespace FumbblApiTest
{
    [Collection("Api collection")]
    public class UnitTest1
    {
        private FumbblApi _fumbbl;

        public UnitTest1(ApiFixture fixture)
        {
            _fumbbl = fixture.Fumbbl;
        }

        [Fact]
        public async void Test1()
        {
            var identity = await _fumbbl.OAuth.Identity();

            Assert.NotEqual(0, identity);
        }
    }
}