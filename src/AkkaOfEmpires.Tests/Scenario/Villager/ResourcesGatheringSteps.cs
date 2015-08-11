using Akka.Actor;
using Akka.TestKit;
using Akka.TestKit.Xunit;
using AkkaOfEmpires.Domain.Commands.Gathering;
using AkkaOfEmpires.Supervisors;
using AkkaOfEmpires.Units;
using Shouldly;
using TechTalk.SpecFlow;

namespace AkkaOfEmpires.Tests.Scenario.Villager
{
    [Binding]
    public class ResourcesGatheringSteps : TestKit
    {
        [AfterScenario]
        public void AfterScenario()
        {
            Shutdown();
        }

        private IActorRef _villagerActor;
        private readonly TestActorRef<ResourcesSupervisorActor> _resourcesSupervisor;

        public ResourcesGatheringSteps()
        {
            _resourcesSupervisor = ActorOfAsTestActorRef<ResourcesSupervisorActor>();
        }

        [Given(@"I have a villager")]
        public void GivenIHaveAVillager()
        {
            var props = Props.Create<VillagerActor>(_resourcesSupervisor);
            _villagerActor = ActorOf(props);
        }

        [When(@"it gathers food")]
        public void WhenItGathersFood()
        {
            _villagerActor.Tell(new GatherFood());
        }

        [Then(@"the supervisor food amount is increased")]
        public void ThenTheFoodAmountIsIncreased()
        {
            _resourcesSupervisor.UnderlyingActor.FoodAmount.ShouldBeGreaterThan<uint>(0);
        }

    }
}
