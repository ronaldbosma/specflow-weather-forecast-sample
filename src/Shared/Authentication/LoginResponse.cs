namespace WeatherForecastSample.Shared.Authentication
{
    public class LoginResponse
    {
        /// <summary>
        /// Gets or sets indication if authentication was successful
        /// </summary>
        public bool IsAuthenticationSuccessful { get; set; }

        /// <summary>
        /// Gets or sets error message in case authentication failed
        /// </summary>
        public string? ErrorMessage { get; set; }

        /// <summary>
        /// Gets or sets token that can be used for successive calls to the API
        /// </summary>
        public string? Token { get; set; }
    }
}
