using Akka.Actor;
using AkkaOfEmpires.Domain;
using AkkaOfEmpires.Domain.Commands;
using AkkaOfEmpires.Domain.Messages;
using AkkaOfEmpires.Subroutines;

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

        private IHarvestResourceCommand _currentCommand;

        protected override void PreStart()
        {
            base.PreStart();
            Become(Idle);
        }

        private void Idle()
        {
            ListenForCommands();
        }

        private void ResourceHarvester(IHarvestResourceCommand command)
        {
            _currentCommand = command;
            Profession = command.AssociatedProfession;
            ResourceToRecolt = command.ResourceToRecolt;

            var props = Props.Create<ResourceHarvesterActor>(Context.System.Scheduler, Self);
            var resourceHarvesterRoutine = Context.ActorOf(props);
            resourceHarvesterRoutine.Tell(command);

            ListenForCommands();
        }

        private void ResourceCarrier(MaxCapacityReached message)
        {
            _resourcesSupervisor.Tell(new ResourceGathered(ResourceToRecolt, message.Quantity));
            Self.Tell(_currentCommand);     //continue harvesting
            ListenForCommands();
        }

        private void ListenForCommands()
        {
            Receive<IHarvestResourceCommand>(m => Become(() => ResourceHarvester(m)));
            Receive<MaxCapacityReached>(m => Become(() => ResourceCarrier(m)));
        }
    }
}
