namespace WeatherForecastSample.Shared.Authentication
{
    public class LoginResponse
    {
        public bool IsAuthenticationSuccessful { get; set; }

        public string? ErrorMessage { get; set; }

        public string? Token { get; set; }
    }
}
