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
            var coach = await _fumbbl.Coach.Get(3);

            Assert.NotNull(coach);
            Assert.Equal(3, coach?.Id);
            Assert.Equal("Christer", coach?.Name);
        }

        [Fact]
        public async void NonExistingGet()
        {
            await Assert.ThrowsAsync<Exception>(async () => await _fumbbl.Coach.Get(-1));
        }

        [Fact]
        public async void Search()
        {
            var coachList = await _fumbbl.Coach.Search("christer");

            Assert.NotNull(coachList);
            Assert.Contains(coachList, c => c.Id == 3 && c.Name.Equals("Christer"));
        }

        [Fact]
        public async void Teams()
        {
            var teamList = await _fumbbl.Coach.Teams(3);

            Assert.NotNull(teamList);
            Assert.NotNull(teamList?.Teams);
            Assert.Contains(teamList?.Teams, t => t.Id == 55051 && t.Name.Equals("Forgotten Kings"));
        }

    }
}