namespace WeatherForecastSample.WebAPI.ApplicationLogic
{
    public class SystemDate : ISystemDate
    {
        public DateOnly Today => DateOnly.FromDateTime(DateTime.Today);
    }
}
