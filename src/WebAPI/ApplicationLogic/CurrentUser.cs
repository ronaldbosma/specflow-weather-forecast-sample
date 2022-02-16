using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace WeatherForecastSample.WebAPI.ApplicationLogic
{
    /// <summary>
    /// Represents the current authenticated user.
    /// </summary>
    internal class CurrentUser : ICurrentUser
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly UserManager<IdentityUser> _userManager;

        public CurrentUser(IHttpContextAccessor httpContextAccessor, UserManager<IdentityUser> userManager)
        {
            _httpContextAccessor = httpContextAccessor;
            _userManager = userManager;
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
