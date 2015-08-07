using TechTalk.SpecFlow;

namespace AkkaOfEmpires.Tests.Scenario.Villager
{
    [Binding]
    public class ResourcesGatheringSteps
    {
        [Given(@"I have a villager")]
        public void GivenIHaveAVillager()
        {
            ScenarioContext.Current.Pending();
        }

        [When(@"it gathers food")]
        public void WhenItGathersFood()
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"the food amount is increased")]
        public void ThenTheFoodAmountIsIncreased()
        {
            ScenarioContext.Current.Pending();
        }

    }
}
