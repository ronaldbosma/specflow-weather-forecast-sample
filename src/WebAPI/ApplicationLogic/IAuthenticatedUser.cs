namespace WeatherForecastSample.WebAPI.ApplicationLogic
{
    /// <summary>
    /// Represents the current authenticated user.
    /// </summary>
    public interface IAuthenticatedUser
    {
        string GetUsername();
    }
}
