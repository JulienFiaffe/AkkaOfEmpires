using Akka.Actor;
using Akka.TestKit;
using Akka.TestKit.Xunit;
using AkkaOfEmpires.Domain;
using AkkaOfEmpires.Supervisors;
using AkkaOfEmpires.Tests.Helpers;
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
            _villagerActor.Tell(VillagerOrders.GatherFruits);
        }

        [When(@"he becomes a shepherd")]
        public void WhenHeBecomesAShepherd()
        {
            _villagerActor.Tell(VillagerOrders.ShepherdFlock);
        }

        [When(@"he becomes a hunter")]
        public void WhenHeBecomesAHunter()
        {
            _villagerActor.Tell(VillagerOrders.HuntPrey);
        }

        [When(@"he becomes a farmer")]
        public void WhenHeBecomesAFarmer()
        {
            _villagerActor.Tell(VillagerOrders.FarmCrops);
        }

        [When(@"he becomes a fisherman")]
        public void WhenHeBecomesAFisherman()
        {
            _villagerActor.Tell(VillagerOrders.CatchFish);
        }

        [When(@"he becomes a lumberjack")]
        public void WhenHeBecomesALumberjack()
        {
            _villagerActor.Tell(VillagerOrders.CutTrees);
        }

        [When(@"he becomes a stone miner")]
        public void WhenHeBecomesAStoneMiner()
        {
            _villagerActor.Tell(VillagerOrders.MineStone);
        }

        [When(@"he becomes a gold miner")]
        public void WhenHeBecomesAGoldMiner()
        {
            _villagerActor.Tell(VillagerOrders.MineGold);
        }


        [Then(@"he recolts food")]
        public void ThenHeWillRecoltFood()
        {
            _villagerActor.UnderlyingActor.ResourceToRecolt.ShouldBe(Resource.Food);
        }

        [Then(@"he recolts wood")]
        public void ThenHeRecoltsWood()
        {
            _villagerActor.UnderlyingActor.ResourceToRecolt.ShouldBe(Resource.Wood);
        }

        [Then(@"he recolts stone")]
        public void ThenHeRecoltsStone()
        {
            _villagerActor.UnderlyingActor.ResourceToRecolt.ShouldBe(Resource.Stone);
        }

        [Then(@"he recolts gold")]
        public void ThenHeRecoltsGold()
        {
            _villagerActor.UnderlyingActor.ResourceToRecolt.ShouldBe(Resource.Gold);
        }
    }
}
