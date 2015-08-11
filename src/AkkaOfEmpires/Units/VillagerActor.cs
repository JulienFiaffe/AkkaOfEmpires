using Akka.Actor;
using AkkaOfEmpires.Domain.Commands.Gathering;
using AkkaOfEmpires.Domain.Messages.Gathering;

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
            Receive<GatherFood>(m => OnGatherFood(m));
        }

        private void OnGatherFood(GatherFood command)
        {
            _resourcesSupervisor.Tell(new FoodGathered{ Quantity = 10 });
        }
    }
}
