using Akka.Actor;
using Akka.TestKit.Xunit;
using AkkaOfEmpires.Domain;
using AkkaOfEmpires.Domain.Commands;
using AkkaOfEmpires.Domain.Messages;
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

        [Fact(DisplayName = "VillagerActor Should Be Idle By Default")]
        public void Be_Idle_By_Default()
        {
            var villager = ActorOfAsTestActorRef<VillagerActor>(Props.Create<VillagerActor>(TestActor));
            villager.UnderlyingActor.Profession.ShouldBe(Profession.Idle);
        }

        [Fact(DisplayName = "VillagerActor Should Send ResourceRecolted With Food When GatherFruits Received")]
        public void Send_FoodGathered_When_GatherFood_Received()
        {
            var villager = ActorOf(Props.Create<VillagerActor>(TestActor));
            var command = new GatherFruits();
            
            villager.Tell(command);

            var message = ExpectMsg<ResourceRecolted>();
            message.ResourceType.ShouldBe(Resource.Food);
        }

        [Fact(DisplayName = "VillagerActor Should Send ResourceRecolted With Food When ShepherdFlock Received")]
        public void Send_FoodGathered_When_ShepherdFlock_Received()
        {
            var villager = ActorOf(Props.Create<VillagerActor>(TestActor));
            var command = new ShepherdFlock();

            villager.Tell(command);

            var message = ExpectMsg<ResourceRecolted>();
            message.ResourceType.ShouldBe(Resource.Food);
        }

        [Fact(DisplayName = "VillagerActor Should Be Able To Change Profession")]
        public void Be_Able_To_Change_Profession()
        {
            var villager = ActorOfAsTestActorRef<VillagerActor>(Props.Create<VillagerActor>(TestActor));
            var shepherdCommand = new ShepherdFlock();
            villager.Tell(shepherdCommand);

            var gatherCommand = new GatherFruits();

            villager.Tell(gatherCommand);

            villager.UnderlyingActor.Profession.ShouldBe(Profession.Gatherer);
        }
    }
}
