using System;
using Akka.Actor;
using AkkaOfEmpires.Domain.Messages.Gathering;

namespace AkkaOfEmpires.Supervisor
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
        }

        private void OnFoodGathered(FoodGathered message)
        {
            FoodAmount += message.Amount;
        }
    }
}
