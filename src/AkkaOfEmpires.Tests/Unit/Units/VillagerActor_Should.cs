using Akka.Actor;
using Akka.TestKit.Xunit;
using AkkaOfEmpires.Domain.Commands;
using AkkaOfEmpires.Domain.Messages;
using AkkaOfEmpires.Units;
using Xunit;

namespace AkkaOfEmpires.Tests.Unit.Units
{
    public class VillagerActor_Should : TestKit
    {
        protected override void Dispose(bool disposing)
        {
            Shutdown();
            base.Dispose(disposing);
        }

        [Fact]
        public void Send_FoodGathered_When_GatherFood_Received()
        {
            var villager = ActorOf(Props.Create<VillagerActor>(TestActor));
            var command = new GatherFood();
            
            villager.Tell(command);
            
            ExpectMsg<FoodGathered>();
        }

        [Fact]
        public void Send_WoodGathered_When_GatherWood_Received()
        {
            var villager = ActorOf(Props.Create<VillagerActor>(TestActor));
            var command = new GatherWood();

            villager.Tell(command);

            ExpectMsg<WoodGathered>();
        }

        [Fact]
        public void Send_GoldGathered_When_GatherGold_Received()
        {
            var villager = ActorOf(Props.Create<VillagerActor>(TestActor));
            var command = new GatherGold();

            villager.Tell(command);

            ExpectMsg<GoldGathered>();
        }

        [Fact]
        public void Send_StoneGathered_When_GatherStone_Received()
        {
            var villager = ActorOf(Props.Create<VillagerActor>(TestActor));
            var command = new GatherStone();

            villager.Tell(command);

            ExpectMsg<StoneGathered>();
        }
    }
}
