namespace WeatherForecastSample.WebAPI.Controllers.Mappers
{
    internal static class EnumMapper
    {
        public static TTarget MapTo<TTarget>(this Enum source)
            where TTarget : struct, Enum
        {
            var name = Enum.GetName(source.GetType(), source);
            if (Enum.TryParse<TTarget>(name, out var result))
            {
                return result;
            }

            throw new InvalidOperationException($"Unable to map value {source} from {source.GetType().FullName} to {typeof(TTarget).FullName}");
        }
    }
}
