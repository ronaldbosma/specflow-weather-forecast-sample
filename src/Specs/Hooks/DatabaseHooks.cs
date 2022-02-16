namespace WeatherForecastSample.Specs.Hooks
{
    [Binding]
    internal class DatabaseHooks
    {
        private readonly DataContext _dataContext;

        public DatabaseHooks(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        [BeforeScenario(Order = 10)]
        public void CleanDatabase()
        {
            _dataContext.CleanDatabase();
        }
    }
}
