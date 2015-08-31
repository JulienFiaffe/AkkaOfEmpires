using Akka.Actor;
using Akka.TestKit;
using Akka.TestKit.Xunit;
using AkkaOfEmpires.Domain;
using AkkaOfEmpires.Domain.Messages;
using AkkaOfEmpires.Subroutines;
using AkkaOfEmpires.Tests.Helpers;
using Moq;
using Shouldly;
using System;
using Xunit;

namespace AkkaOfEmpires.Tests.Subroutines
{
    public class ResourceHarvesterActor_Should : TestKit
    {
        protected override void Dispose(bool disposing)
        {
            Shutdown();
            base.Dispose(disposing);
        }

        private readonly TestActorRef<ResourceHarvesterActor> _harvester;

        private readonly Mock<ITellScheduler> _mockScheduler;

        public ResourceHarvesterActor_Should()
        {
            _mockScheduler = new Mock<ITellScheduler>();
            _harvester = ActorOfAsTestActorRef<ResourceHarvesterActor>(Props.Create<ResourceHarvesterActor>(_mockScheduler.Object, TestActor));
        }

        [Fact(DisplayName = "ResourceHarvesterActor Should Store ResourceToRecolt From Command")]
        public void Store_ResourceToHarvest_From_Command()
        {
            _harvester.Tell(VillagerOrders.CutTrees);
            _harvester.UnderlyingActor.ResourceToHarvest.ShouldBe(Resource.Wood);
        }

        [Fact(DisplayName = "ResourceHarvesterActor Should Schedule A ResourceHarvested When Harvesting Resource")]
        public void Schedule_A_ResourceHarvested_When_Harvesting_Resource()
        {
            _harvester.Tell(VillagerOrders.CutTrees);
            _mockScheduler.Verify(m => m.ScheduleTellOnce(It.IsAny<TimeSpan>(), _harvester, It.IsAny<ResourceHarvesterActor.ResourceHarvested>(), _harvester));
        }

        [Fact(DisplayName = "ResourceHarvesterActor Should Increment CurrentlyCarrying When ResourceHarvested Received")]
        public void Increment_CurrentlyCarrying_When_ResourceHarvested_Received()
        {
            _harvester.Tell(new ResourceHarvesterActor.ResourceHarvested());
            _harvester.UnderlyingActor.CurrentlyCarrying.ShouldBe<uint>(1);
        }

        [Fact(DisplayName = "ResourceHarvesterActor Should Schedule A ResourceHarvested When Receiving One")]
        public void Schedule_A_ResourceHarvested_When_Receiving_One()
        {
            _harvester.Tell(new ResourceHarvesterActor.ResourceHarvested());
            _mockScheduler.Verify(m => m.ScheduleTellOnce(It.IsAny<TimeSpan>(), _harvester, It.IsAny<ResourceHarvesterActor.ResourceHarvested>(), _harvester));
        }

        [Fact(DisplayName = "ResourceHarvesterActor Should Send ResourceGathered When MaxCapacity Reached")]
        public void Send_ResourceGathered_When_MaxCapacity_Reached()
        {
            for (int i = 0; i < 10; i++)
                _harvester.Tell(new ResourceHarvesterActor.ResourceHarvested());

            ExpectMsg<ResourceGathered>();
        }

        [Fact(DisplayName = "ResourceHarvesterActor Should Empty CurrentlyCarrying If Different Resource To Harvest")]
        public void test()
        {
            _harvester.Tell(VillagerOrders.CutTrees);
            _harvester.Tell(new ResourceHarvesterActor.ResourceHarvested());
            _harvester.UnderlyingActor.CurrentlyCarrying.ShouldBe<uint>(1);
            _harvester.Tell(VillagerOrders.CatchFish);
            _harvester.UnderlyingActor.CurrentlyCarrying.ShouldBe<uint>(0);
        }
    }
}
