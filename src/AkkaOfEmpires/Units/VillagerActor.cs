using Akka.Actor;
using AkkaOfEmpires.Domain.Commands;
using AkkaOfEmpires.Domain.Messages;

namespace AkkaOfEmpires.Units
{
    public class VillagerActor : ReceiveActor
    {
        private readonly IActorRef _resourcesSupervisor;

        public VillagerActor(IActorRef resourcesSupervisor)
        {
            _resourcesSupervisor = resourcesSupervisor;
        }

        protected override void PreStart()
        {
            base.PreStart();
            Become(Gatherer);
        }

        private void Gatherer()
        {
            Receive<GatherFood>(m => OnGatherFood());
            Receive<GatherWood>(m => OnGatherWood());
            Receive<GatherGold>(m => OnGatherGold());
            Receive<GatherStone>(m => OnGatherStone());
        }

        private void OnGatherFood()
        {
            _resourcesSupervisor.Tell(new FoodGathered{ Quantity = 10 });
        }

        private void OnGatherWood()
        {
            _resourcesSupervisor.Tell(new WoodGathered{ Quantity = 10 });
        }

        private void OnGatherGold()
        {
            _resourcesSupervisor.Tell(new GoldGathered { Quantity = 10 });
        }

        private void OnGatherStone()
        {
            _resourcesSupervisor.Tell(new StoneGathered { Quantity = 10 });
        }
    }
}
