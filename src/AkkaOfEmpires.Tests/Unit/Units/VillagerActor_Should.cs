using Akka.Actor;
using Akka.TestKit.Xunit;
using AkkaOfEmpires.Domain.Commands.Gathering;
using AkkaOfEmpires.Domain.Messages.Gathering;
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

    }
}
