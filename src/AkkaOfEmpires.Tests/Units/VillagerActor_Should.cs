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


        [Fact(DisplayName = "VillagerActor Should Send ResourceRecolted With Food When GatherFruits Received")]
        public void Send_FoodGathered_When_GatherFood_Received()
        {
            _villager.Tell(VillagerOrders.GatherFruits);

            var message = ExpectMsg<ResourceRecolted>();
            message.ResourceType.ShouldBe(Resource.Food);
        }

        [Fact(DisplayName = "VillagerActor Should Send ResourceRecolted With Food When ShepherdFlock Received")]
        public void Send_FoodGathered_When_ShepherdFlock_Received()
        {
            _villager.Tell(VillagerOrders.ShepherdFlock);

            var message = ExpectMsg<ResourceRecolted>();
            message.ResourceType.ShouldBe(Resource.Food);
        }

        [Fact(DisplayName = "VillagerActor Should Send ResourceRecolted With Food When HuntPrey Received")]
        public void Send_FoodGathered_When_HuntPrey_Received()
        {
            _villager.Tell(VillagerOrders.HuntPrey);

            var message = ExpectMsg<ResourceRecolted>();
            message.ResourceType.ShouldBe(Resource.Food);
        }

        [Fact(DisplayName = "VillagerActor Should Send ResourceRecolted With Food When FarmCrops Received")]
        public void Send_FoodGathered_When_FarmCrops_Received()
        {
            _villager.Tell(VillagerOrders.FarmCrops);

            var message = ExpectMsg<ResourceRecolted>();
            message.ResourceType.ShouldBe(Resource.Food);
        }

        [Fact(DisplayName = "VillagerActor Should Send ResourceRecolted With Food When CatchFish Received")]
        public void Send_FoodGathered_When_CatchFish_Received()
        {
            _villager.Tell(VillagerOrders.CatchFish);

            var message = ExpectMsg<ResourceRecolted>();
            message.ResourceType.ShouldBe(Resource.Food);
        }

        [Fact(DisplayName = "VillagerActor Should Send ResourceRecolted With Wood When CutTrees Received")]
        public void Send_FoodGathered_When_CutTrees_Received()
        {
            _villager.Tell(VillagerOrders.CutTrees);

            var message = ExpectMsg<ResourceRecolted>();
            message.ResourceType.ShouldBe(Resource.Wood);
        }

        [Fact(DisplayName = "VillagerActor Should Send ResourceRecolted With Wood When MineStone Received")]
        public void Send_FoodGathered_When_MineStone_Received()
        {
            _villager.Tell(VillagerOrders.MineStone);

            var message = ExpectMsg<ResourceRecolted>();
            message.ResourceType.ShouldBe(Resource.Stone);
        }

        [Fact(DisplayName = "VillagerActor Should Send ResourceRecolted With Wood When MineGold Received")]
        public void Send_FoodGathered_When_MineGold_Received()
        {
            _villager.Tell(VillagerOrders.MineGold);

            var message = ExpectMsg<ResourceRecolted>();
            message.ResourceType.ShouldBe(Resource.Gold);
        }
    }
}
