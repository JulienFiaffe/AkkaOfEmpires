using Akka.TestKit.Xunit;
using AkkaOfEmpires.Domain.Messages.Gathering;
using AkkaOfEmpires.Supervisor;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;

namespace AkkaOfEmpires.Tests.Unit.Supervisor
{
    [TestClass]
    public class ResourcesSupervisorActorTests : TestKit
    {
        [TestCleanup]
        public void Cleanup()
        {
            Shutdown();
        }

        [TestMethod]
        public void When_FoodGathered_Received_Then_FoodAmount_Is_Increased()
        {
            var actor = ActorOfAsTestActorRef<ResourcesSupervisorActor>();
            var message = new FoodGathered { Quantity = 10 };
            actor.Tell(message);
            actor.UnderlyingActor.FoodAmount.ShouldBe<uint>(10);
        }

        [TestMethod]
        public void When_WoodGathered_Received_Then_WoodAmount_Is_Increased()
        {
            var actor = ActorOfAsTestActorRef<ResourcesSupervisorActor>();
            var message = new WoodGathered { Quantity = 12 };
            actor.Tell(message);
            actor.UnderlyingActor.WoodAmount.ShouldBe<uint>(12);
        }

        [TestMethod]
        public void When_GoldGathered_Received_Then_GoldAmount_Is_Increased()
        {
            var actor = ActorOfAsTestActorRef<ResourcesSupervisorActor>();
            var message = new GoldGathered { Quantity = 8 };
            actor.Tell(message);
            actor.UnderlyingActor.GoldAmount.ShouldBe<uint>(8);
        }

        [TestMethod]
        public void When_StoneGathered_Received_Then_StoneAmount_Is_Increased()
        {
            var actor = ActorOfAsTestActorRef<ResourcesSupervisorActor>();
            var message = new StoneGathered { Quantity = 5 };
            actor.Tell(message);
            actor.UnderlyingActor.StoneAmount.ShouldBe<uint>(5);
        }
    }
}
