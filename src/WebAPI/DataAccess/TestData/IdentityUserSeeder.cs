using Microsoft.AspNetCore.Identity;

namespace WeatherForecastSample.WebAPI.DataAccess.TestData
{
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
            AddIdentityUser("john@example.org", "P@ssw0rd");
            AddIdentityUser("jane@example.org", "P@ssw0rd");

            _context.SaveChanges();
        }

        private void AddIdentityUser(string email, string password)
        {
            var userDoesNotExist = !_context.Users.Any(u => u.UserName == email);
            if (userDoesNotExist)
            {
                var user = new IdentityUser
                {
                    UserName = email,
                    Email = email
                };
                _userManager.CreateAsync(user, password).Wait();
            }
        }
    }
}
