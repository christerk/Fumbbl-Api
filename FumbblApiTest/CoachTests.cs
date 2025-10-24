using Fumbbl.Api;
using System;
using Xunit;

namespace FumbblApiTest
{
    [Collection("Api collection")]
    public class CoachTests
    {
        private FumbblApi _fumbbl;

        public CoachTests(ApiFixture fixture)
        {
            _fumbbl = fixture.Fumbbl;
        }

        [Fact]
        public async void ExistingGet()
        {
            var coach = await _fumbbl.Coach.GetAsync(3);

            Assert.NotNull(coach);
            Assert.Equal(3, coach?.Id);
            Assert.Equal("Christer", coach?.Name);
        }

        [Fact]
        public async void NonExistingGet()
        {
            var coach = await _fumbbl.Coach.GetAsync(-1);
            Assert.Null(coach);
        }

        [Fact]
        public async void Search()
        {
            var coachList = await _fumbbl.Coach.SearchAsync("christer");

            Assert.NotNull(coachList);
            Assert.Contains(coachList, c => c.Id == 3 && c.Name.Equals("Christer"));
        }

        [Fact]
        public async void Teams()
        {
            var teamList = await _fumbbl.Coach.TeamsAsync(3);

            Assert.NotNull(teamList);
            Assert.NotNull(teamList?.Teams);
            Assert.Contains(teamList?.Teams, t => t.Id == 55051 && t.Name.Equals("Forgotten Kings"));
        }

    }
}