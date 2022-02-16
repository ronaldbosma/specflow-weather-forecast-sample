namespace WeatherForecastSample.Specs.Hooks
{
    [Binding]
    internal class DatabaseHooks
    {
        private readonly DataContext _dataContext;

        public DatabaseHooks(DataContext dataContext)
        {
            _dataContext = new DataContext();
            ScenarioContext.Current.Set(_dataContext);
        }

        [BeforeScenario(Order = 10)]
        public void CleanDatabase()
        {
            _dataContext.CleanDatabase();
        }
    }
}
