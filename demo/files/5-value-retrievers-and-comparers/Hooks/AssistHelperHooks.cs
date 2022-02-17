using TechTalk.SpecFlow.Assist;
using WeatherForecastSample.Specs.Support;

namespace WeatherForecastSample.Specs.Hooks
{
    [Binding]
    internal class AssistHelperHooks
    {
        [BeforeTestRun]
        public static void RegisterAssistHelpersBeforeTestRun()
        {
            Service.Instance.ValueRetrievers.Register(new DateOnlyValueRetriever());
        }
    }
}
