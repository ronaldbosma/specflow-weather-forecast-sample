namespace WeatherForecastSample.Specs.StepDefinitions
{
    [Binding]
    internal class DateSteps
    {
        private readonly SystemDateFake _systemDate;

        public DateSteps(SystemDateFake systemDate)
        {
            _systemDate = systemDate;
        }

        [Given(@"today is (.*)")]
        public void GivenTodayIs(DateOnly today)
        {
            _systemDate.Today = today;
        }
        
        [AfterScenario]
        public void ResetSystemDateAfterScenario()
        {
            _systemDate.Reset();
        }
    }
}
