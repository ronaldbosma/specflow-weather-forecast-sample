using System.Security.Claims;

namespace WeatherForecastSample.WebAPI.ApplicationLogic
{
    /// <summary>
    /// Represents the current authenticated user.
    /// </summary>
    internal class AuthenticatedUser : IAuthenticatedUser
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public AuthenticatedUser(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public string GetUsername()
        {
            var nameClaim = _httpContextAccessor.HttpContext?.User.Claims.SingleOrDefault(c => c.Type == ClaimTypes.Name);
            if (string.IsNullOrWhiteSpace(nameClaim?.Value))
            {
                throw new InvalidOperationException("Username not found in claims.");
            }

            return nameClaim.Value;
        }
    }
}
