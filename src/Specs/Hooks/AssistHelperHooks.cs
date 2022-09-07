namespace WeatherForecastSample.Specs.Hooks
{
    [Binding]
    internal class AssistHelperHooks
    {
        [BeforeTestRun]
        public static void RegisterAssistHelpersBeforeTestRun()
        {
            Service.Instance.ValueRetrievers.Register(new DateOnlyValueRetriever());
            Service.Instance.ValueComparers.Register(new DateOnlyValueComparer());
        }
    }
}
