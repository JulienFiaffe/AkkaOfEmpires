using System;
using Akka.Actor;
using AkkaOfEmpires.Domain.Messages.Gathering;

namespace AkkaOfEmpires.Supervisors
{
    public class ResourcesSupervisorActor : ReceiveActor
    {
        public UInt32 FoodAmount { get; private set; }
        public UInt32 WoodAmount { get; private set; }
        public UInt32 GoldAmount { get; private set; }
        public UInt32 StoneAmount { get; private set; }

        protected override void PreStart()
        {
            base.PreStart();
            Become(SuperviseResources);
        }

        private void SuperviseResources()
        {
            Receive<FoodGathered>(m => OnFoodGathered(m));
            Receive<WoodGathered>(m => OnWoodGathered(m));
            Receive<GoldGathered>(m => OnGoldGathered(m));
            Receive<StoneGathered>(m => OnStoneGathered(m));
        }

        private void OnStoneGathered(StoneGathered message)
        {
            StoneAmount += message.Quantity;
        }

        private void OnGoldGathered(GoldGathered message)
        {
            GoldAmount += message.Quantity;
        }

        private void OnWoodGathered(WoodGathered message)
        {
            WoodAmount += message.Quantity;
        }

        private void OnFoodGathered(FoodGathered message)
        {
            FoodAmount += message.Quantity;
        }
    }
}
