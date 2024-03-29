﻿namespace WeatherForecastSample.Specs.Support
{
    /// <summary>
    /// Contains default data used in the automation code.
    /// </summary>
    internal static class Default
    {
        public const string Location = "Amsterdam";
        public static int LocationId = Location.GetTechnicalId();

        public const string Username = "Dean";
        public const string UserId = Username;
    }
}
