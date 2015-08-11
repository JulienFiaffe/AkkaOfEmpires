using Akka.TestKit.Xunit;
using AkkaOfEmpires.Domain.Messages;
using AkkaOfEmpires.Supervisors;
using Shouldly;
using Xunit;

namespace AkkaOfEmpires.Tests.Unit.Supervisors
{
    public class ResourcesSupervisorActor_Should : TestKit
    {
        protected override void Dispose(bool disposing)
        {
            Shutdown();
            base.Dispose(disposing);
        }

        [Fact]
        public void Increase_FoodAmount_When_FoodGathered_Message_Received()
        {
            var actor = ActorOfAsTestActorRef<ResourcesSupervisorActor>();
            var message = new FoodGathered { Quantity = 10 };
            actor.Tell(message);
            actor.UnderlyingActor.FoodAmount.ShouldBe<uint>(10);
        }

        [Fact]
        public void Increase_WoodAmound_When_WoodGathered_Message_Received()
        {
            var actor = ActorOfAsTestActorRef<ResourcesSupervisorActor>();
            var message = new WoodGathered { Quantity = 12 };
            actor.Tell(message);
            actor.UnderlyingActor.WoodAmount.ShouldBe<uint>(12);
        }

        [Fact]
        public void Increase_GoldAmound_When_GoldGathered_Message_Received()
        {
            var actor = ActorOfAsTestActorRef<ResourcesSupervisorActor>();
            var message = new GoldGathered { Quantity = 8 };
            actor.Tell(message);
            actor.UnderlyingActor.GoldAmount.ShouldBe<uint>(8);
        }

        [Fact]
        public void Increase_StoneAmound_When_StoneGathered_Message_Received()
        {
            var actor = ActorOfAsTestActorRef<ResourcesSupervisorActor>();
            var message = new StoneGathered { Quantity = 5 };
            actor.Tell(message);
            actor.UnderlyingActor.StoneAmount.ShouldBe<uint>(5);
        }
    }
}
