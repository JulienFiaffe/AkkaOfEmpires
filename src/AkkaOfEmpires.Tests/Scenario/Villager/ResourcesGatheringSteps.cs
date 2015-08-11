using System;
using System.Threading.Tasks;
using Akka.Actor;
using Akka.TestKit;
using Akka.TestKit.Xunit;
using AkkaOfEmpires.Domain.Commands;
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

        [BeforeScenario]
        public void BeforeScenario()
        {
            _resourcesSupervisor = ActorOfAsTestActorRef<ResourcesSupervisorActor>();
        }

        private IActorRef _villagerActor;
        private TestActorRef<ResourcesSupervisorActor> _resourcesSupervisor;

        [Given(@"I have a villager")]
        public void GivenIHaveAVillager()
        {
            var props = Props.Create<VillagerActor>(_resourcesSupervisor);
            _villagerActor = ActorOf(props);
        }


        [When(@"he gathers food")]
        public void WhenHeGathersFood()
        {
            _villagerActor.Tell(new GatherFood());
        }

        [When(@"he gathers wood")]
        public void WhenHeGathersWood()
        {
            _villagerActor.Tell(new GatherWood());
        }

        [When(@"he gathers gold")]
        public void WhenHeGathersGold()
        {
            _villagerActor.Tell(new GatherGold());
        }

        [When(@"he gathers stone")]
        public void WhenHeGathersStone()
        {
            _villagerActor.Tell(new GatherStone());
        }


        [Then(@"food amount is increased")]
        public async void ThenTheFoodAmountIsIncreased()
        {
            await Task.Delay(TimeSpan.FromMilliseconds(10));    // waiting for the message to be processed
            _resourcesSupervisor.UnderlyingActor.FoodAmount.ShouldBeGreaterThan<uint>(0);
        }

        [Then(@"wood amount is increased")]
        public async void ThenTheSupervisorWoodAmountIsIncreased()
        {
            await Task.Delay(TimeSpan.FromMilliseconds(10));
            _resourcesSupervisor.UnderlyingActor.WoodAmount.ShouldBeGreaterThan<uint>(0);
        }

        [Then(@"gold amount is increased")]
        public async void ThenTheSupervisorGoldAmountIsIncreased()
        {
            await Task.Delay(TimeSpan.FromMilliseconds(10));
            _resourcesSupervisor.UnderlyingActor.GoldAmount.ShouldBeGreaterThan<uint>(0);
        }

        [Then(@"stone amount is increased")]
        public async void ThenTheSupervisorStoneAmountIsIncreased()
        {
            await Task.Delay(TimeSpan.FromMilliseconds(10));
            _resourcesSupervisor.UnderlyingActor.StoneAmount.ShouldBeGreaterThan<uint>(0);
        }
    }
}
