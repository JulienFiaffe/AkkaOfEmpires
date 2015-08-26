using Akka.Actor;
using Akka.TestKit;
using Akka.TestKit.Xunit;
using AkkaOfEmpires.Domain;
using AkkaOfEmpires.Domain.Commands;
using AkkaOfEmpires.Domain.Messages;
using AkkaOfEmpires.Tests.Helpers;
using AkkaOfEmpires.Units;
using Shouldly;
using Xunit;

namespace AkkaOfEmpires.Tests.Units
{
    public class VillagerActor_Should : TestKit
    {
        protected override void Dispose(bool disposing)
        {
            Shutdown();
            base.Dispose(disposing);
        }

        private readonly TestActorRef<VillagerActor> _villager;

        public VillagerActor_Should()
        {
            _villager = ActorOfAsTestActorRef<VillagerActor>(Props.Create<VillagerActor>(TestActor));
        }

        [Fact(DisplayName = "VillagerActor Should Be Idle By Default")]
        public void Be_Idle_By_Default()
        {
            _villager.UnderlyingActor.Profession.ShouldBe(Profession.Idle);
        }

        [Fact(DisplayName = "VillagerActor Should Be Able To Change Profession")]
        public void Be_Able_To_Change_Profession()
        {
            _villager.Tell(TestData.ShepherdCommand);
            _villager.Tell(TestData.GathererCommand);
            _villager.UnderlyingActor.Profession.ShouldBe(Profession.Gatherer);
        }


        [Fact(DisplayName = "VillagerActor Should Send ResourceRecolted With Food When GatherFruits Received")]
        public void Send_FoodGathered_When_GatherFood_Received()
        {
            _villager.Tell(TestData.GathererCommand);

            var message = ExpectMsg<ResourceRecolted>();
            message.ResourceType.ShouldBe(Resource.Food);
        }

        [Fact(DisplayName = "VillagerActor Should Send ResourceRecolted With Food When ShepherdFlock Received")]
        public void Send_FoodGathered_When_ShepherdFlock_Received()
        {
            _villager.Tell(TestData.ShepherdCommand);

            var message = ExpectMsg<ResourceRecolted>();
            message.ResourceType.ShouldBe(Resource.Food);
        }

    }
}
