using System.Text.Json.Serialization;

namespace WeatherForecastSample.WebAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers().AddJsonOptions(options =>
            {
                // Blazor sends enums to Web API as string value, so we need to register JsonStringEnumConverter.
                options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
            });
            
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();

            var jwtSettings = Configuration.GetSection("JWTSettings");
            services.AddAuthentication(jwtSettings);
            services.AddHttpContextAccessor();

            services.AddWeatherForecastDependencies();
            services.AddWeatherForecastDbContext();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();
            app.UseSwaggerUI();

            app.UseRouting();

            app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseAuthorization();

            //DON'T USE IN PRODUCTION: this will allow the Blazor UI to call the Web API
            app.UseCors(cors => cors.AllowAnyMethod()
                                    .AllowAnyHeader()
                                    .SetIsOriginAllowed(origin => true)
                                    .AllowCredentials());

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
