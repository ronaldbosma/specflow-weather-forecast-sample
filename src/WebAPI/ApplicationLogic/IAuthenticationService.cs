namespace WeatherForecastSample.WebAPI.ApplicationLogic
{
    public interface IAuthenticationService
    {
        Task<bool> AreCredentialsValidAsync(string username, string password);

        string GenerateToken(string username);
    }
}