using Akka.Actor;
using AkkaOfEmpires.Domain;
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
            Profession = Profession.Idle;
        }

        public Profession Profession { get; private set; }
        public Resource ResourceToRecolt { get; private set; }

        protected override void PreStart()
        {
            base.PreStart();
            Become(Idle);
        }

        private void Idle()
        {
            CommandsHandler();
        }

        private void Gatherer()
        {
            Profession = Profession.Gatherer;
            ResourceToRecolt = Resource.Food;
            // repeat until new order or lack of bushes
            _resourcesSupervisor.Tell(new ResourceRecolted { ResourceType = ResourceToRecolt, Quantity = 10 });

            CommandsHandler();
        }

        private void Shepherd()
        {
            Profession = Profession.Shepherd;
            ResourceToRecolt = Resource.Food;
            // repeat until new order or lack of sheeps
            _resourcesSupervisor.Tell(new ResourceRecolted { ResourceType = ResourceToRecolt, Quantity = 10 });

            CommandsHandler();
        }

        private void CommandsHandler()
        {
            Receive<GatherFruits>(m => Become(Gatherer));
            Receive<ShepherdFlock>(m => Become(Shepherd));
        }
    }
}
