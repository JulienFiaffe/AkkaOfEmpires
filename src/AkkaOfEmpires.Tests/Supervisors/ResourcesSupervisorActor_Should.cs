using Akka.TestKit.Xunit;
using AkkaOfEmpires.Domain;
using AkkaOfEmpires.Domain.Messages;
using AkkaOfEmpires.Supervisors;
using Shouldly;
using Xunit;

namespace AkkaOfEmpires.Tests.Supervisors
{
    public class ResourcesSupervisorActor_Should : TestKit
    {
        protected override void Dispose(bool disposing)
        {
            Shutdown();
            base.Dispose(disposing);
        }

        [Fact(DisplayName = "ResourcesSupervisorActor Should Increase Food Amount When Food Recolted")]
        public void Increase_FoodAmount_When_FoodGathered_Message_Received()
        {
            var actor = ActorOfAsTestActorRef<ResourcesSupervisorActor>();
            var message = new ResourceRecolted { ResourceType = Resource.Food, Quantity = 10 };
            actor.Tell(message);
            actor.UnderlyingActor.ResourcesAmounts[Resource.Food].ShouldBe<uint>(10);
        }

        [Fact(DisplayName = "ResourcesSupervisorActor Should Increase Wood Amount When Wood Recolted")]
        public void Increase_WoodAmound_When_WoodGathered_Message_Received()
        {
            var actor = ActorOfAsTestActorRef<ResourcesSupervisorActor>();
            var message = new ResourceRecolted { ResourceType = Resource.Wood, Quantity = 12 };
            actor.Tell(message);
            actor.UnderlyingActor.ResourcesAmounts[Resource.Wood].ShouldBe<uint>(12);
        }

        [Fact(DisplayName = "ResourcesSupervisorActor Should Increase Gold Amount When Gold Recolted")]
        public void Increase_GoldAmound_When_GoldGathered_Message_Received()
        {
            var actor = ActorOfAsTestActorRef<ResourcesSupervisorActor>();
            var message = new ResourceRecolted { ResourceType = Resource.Gold, Quantity = 8 };
            actor.Tell(message);
            actor.UnderlyingActor.ResourcesAmounts[Resource.Gold].ShouldBe<uint>(8);
        }

        [Fact(DisplayName = "ResourcesSupervisorActor Should Increase Stone Amount When Stone Recolted")]
        public void Increase_StoneAmound_When_StoneGathered_Message_Received()
        {
            var actor = ActorOfAsTestActorRef<ResourcesSupervisorActor>();
            var message = new ResourceRecolted { ResourceType = Resource.Stone, Quantity = 5 };
            actor.Tell(message);
            actor.UnderlyingActor.ResourcesAmounts[Resource.Stone].ShouldBe<uint>(5);
        }
    }
}
