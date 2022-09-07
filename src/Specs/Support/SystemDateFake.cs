namespace WeatherForecastSample.Specs.Support
{
    internal class SystemDateFake : ISystemDate
    {
        public DateOnly Today { get; set; }

        public void Reset()
        {
            Today = DateOnly.FromDateTime(DateTime.Today);
        }
    }
}
