using Microsoft.AspNetCore.Identity;

namespace WeatherForecastSample.WebAPI.DataAccess.TestData
{
    /// <summary>
    /// Creates user test data
    /// </summary>
    internal class IdentityUserSeeder
    {
        private readonly WeatherForecastDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public IdentityUserSeeder(WeatherForecastDbContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public void SeedData()
        {
            AddIdentityUser("John", "P@ssw0rd");
            AddIdentityUser("Jane", "P@ssw0rd");

            _context.SaveChanges();
        }

        private void AddIdentityUser(string username, string password)
        {
            var userDoesNotExist = !_context.Users.Any(u => u.UserName == username);
            if (userDoesNotExist)
            {
                var user = new IdentityUser(username);
                _userManager.CreateAsync(user, password).Wait();
            }
        }
    }
}
