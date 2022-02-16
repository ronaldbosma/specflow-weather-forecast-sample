using BoDi;

namespace WeatherForecastSample.Specs
{
    [Binding]
    internal class Startup
    {
        private readonly IObjectContainer _objectContainer;

        public Startup(IObjectContainer objectContainer)
        {
            _objectContainer = objectContainer;
        }

        [BeforeScenario(Order = 0)]
        public void RegisterDependencies()
        {
            var authenticatedUserFake = new Mock<IAuthenticatedUser>();
            _objectContainer.RegisterInstanceAs(authenticatedUserFake);
        }
    }
}
