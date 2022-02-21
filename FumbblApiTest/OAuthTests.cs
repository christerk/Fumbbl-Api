using Fumbbl.Api;
using Xunit;

namespace FumbblApiTest
{
    [Collection("Api collection")]
    public class OAuthTests
    {
        private FumbblApi _fumbbl;

        public OAuthTests(ApiFixture fixture)
        {
            _fumbbl = fixture.Fumbbl;
        }

        [Fact]
        public async void Identity()
        {
            var identity = await _fumbbl.OAuth.Identity();

            Assert.NotEqual(0, identity);
        }
    }
}