using Akka.Actor;
using Akka.TestKit;
using Akka.TestKit.Xunit;
using AkkaOfEmpires.Domain;
using AkkaOfEmpires.Domain.Commands;
using AkkaOfEmpires.Supervisors;
using AkkaOfEmpires.Units;
using Shouldly;
using TechTalk.SpecFlow;

namespace AkkaOfEmpires.Tests.Scenarios.Villager
{
    [Binding]
    public sealed class VillagerSteps : TestKit
    {
        [AfterScenario]
        public void AfterScenario()
        {
            Shutdown();
        }

        [BeforeScenario]
        public void BeforeScenario()
        {
            _resourcesSupervisor = ActorOfAsTestActorRef<ResourcesSupervisorActor>();
        }

        private TestActorRef<VillagerActor> _villagerActor;
        private TestActorRef<ResourcesSupervisorActor> _resourcesSupervisor;

        [Given(@"I have a villager")]
        public void GivenIHaveAVillager()
        {
            var props = Props.Create<VillagerActor>(_resourcesSupervisor);
            _villagerActor = ActorOfAsTestActorRef<VillagerActor>(props);
        }

        [When(@"he becomes a gatherer")]
        public void WhenHeBecomesAGatherer()
        {
            _villagerActor.Tell(new GatherFruits());
        }

        [When(@"he becomes a shepherd")]
        public void WhenHeBecomesAShepherd()
        {
            _villagerActor.Tell(new ShepherdFlock());
        }

        [Then(@"he recolts food")]
        public void ThenHeWillRecoltFood()
        {
            _villagerActor.UnderlyingActor.ResourceToRecolt.ShouldBe(Resource.Food);
        }
    }
}
