using Akka.TestKit.VsTest;
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
            var message = new FoodGathered{Amount=10};
            actor.Tell(message);
            actor.UnderlyingActor.FoodAmount.ShouldBe<uint>(10);
        }

        [TestMethod]
        public void When_WoodGathered_Received_Then_WoodAmount_Is_Increased()
        {
            var actor = ActorOfAsTestActorRef<ResourcesSupervisorActor>();
            var message = new WoodGathered { Amount = 12 };
            actor.Tell(message);
            actor.UnderlyingActor.WoodAmount.ShouldBe<uint>(12);
        }
    }
}
