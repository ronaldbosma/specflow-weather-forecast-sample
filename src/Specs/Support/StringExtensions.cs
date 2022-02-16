namespace WeatherForecastSample.Specs.Support
{
    /// <summary>
    /// Contains extension methods for <see cref="string"/>.
    /// </summary>
    /// <remarks>
    /// See https://ronaldbosma.github.io/blog/2020/08/08/handling-technical-ids-in-gherkin-with-specflow/ for more details about this solution.
    /// </remarks>
    internal static class StringExtensions
    {
        /// <summary>
        /// Gets an id based on the value of <paramref name="functionalId"/>.
        /// </summary>
        /// <param name="functionalId">The functional id to get the technical id from.</param>
        /// <returns>an id.</returns>
        public static int GetTechnicalId(this string functionalId)
        {
            return Math.Abs(functionalId.GetHashCode());
        }
    }
}
