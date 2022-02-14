namespace WeatherForecastSample.WebAPI.Entities
{
    public class UserSettings
    {
        public string UserId { get; set; } = null!;

        public TemperatureUnit TemperatureUnit { get; set; }

        public int LocationId { get; set; }
    }
}
