using Akka.Actor;
using Akka.TestKit;
using Akka.TestKit.Xunit;
using AkkaOfEmpires.Domain;
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
            _villager.Tell(VillagerOrders.ShepherdFlock);
            _villager.UnderlyingActor.Profession.ShouldBe(Profession.Shepherd);
            _villager.Tell(VillagerOrders.GatherFruits);
            _villager.UnderlyingActor.Profession.ShouldBe(Profession.Gatherer);
        }
    }
}
