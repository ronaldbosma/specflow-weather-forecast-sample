using Microsoft.AspNetCore.Identity;
using Moq;
using TechTalk.SpecFlow;
using WeatherForecastSample.Specs.Support;
using WeatherForecastSample.WebAPI.ApplicationLogic;
using WeatherForecastSample.WebAPI.DataAccess;
using WeatherForecastSample.WebAPI.Entities;

namespace WeatherForecastSample.Specs.StepDefinitions
{
    [Binding]
    internal class UserSteps
    {
        private Mock<IAuthenticatedUser> _authenticatedUserFake;
        private WeatherForecastDbContext _dbContext;

        public UserSteps(Mock<IAuthenticatedUser> authenticatedUserFake, WeatherForecastDbContext dbContext)
        {
            _authenticatedUserFake = authenticatedUserFake;
            _dbContext = dbContext;
        }

        [Given(@"the authenticated user '(.*)'")]
        public async Task GivenTheAuthenticatedUser(string username)
        {
            // Make sure the user exists in the database
            _dbContext.Users.Add(new IdentityUser(username) { Id = username });
            await _dbContext.SaveChangesAsync();

            _authenticatedUserFake.Setup(u => u.GetUsername()).Returns(username);
        }

        [Given(@"the preferred location of '([^']*)' is '([^']*)'")]
        public void GivenThePreferredLocationOfIs(string username, string preferredLocation)
        {
            var userSettings = new UserSettings
            {
                UserId = username,
                LocationId = preferredLocation.GetTechnicalId(),
                TemperatureUnit = TemperatureUnit.DegreesCelsius,
            };
            _dbContext.UserSettings.Add(userSettings);
            _dbContext.SaveChanges();
        }
    }
}
