﻿namespace WeatherForecastSample.Specs.StepDefinitions
{
    [Binding]
    internal class UserSteps
    {
        private Mock<IAuthenticatedUser> _authenticatedUserFake;
        private DataContext _dataContext;

        public UserSteps(DataContext dataContext)
        {
            _authenticatedUserFake = ScenarioContext.Current.Get<Mock<IAuthenticatedUser>>();
            _dataContext = dataContext;
        }

        [Given(@"the authenticated user '(.*)'")]
        public void GivenTheAuthenticatedUser(string username)
        {
            _dataContext.AddUser(username);
            _authenticatedUserFake.Setup(u => u.GetUsername()).Returns(username);
        }

        [Given(@"the preferred location of '([^']*)' is '([^']*)'")]
        public void GivenThePreferredLocationOfIs(string username, string preferredLocation)
        {
            _dataContext.AddUserSettings(username, TemperatureUnit.DegreesCelsius, preferredLocation.GetTechnicalId());
        }
    }
}
