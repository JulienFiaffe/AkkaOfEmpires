using Akka.Actor;
using AkkaOfEmpires.Domain;
using AkkaOfEmpires.Domain.Commands;
using AkkaOfEmpires.Domain.Messages;
using AkkaOfEmpires.Subroutines;
using AkkaOfEmpires.Supervisors;

namespace AkkaOfEmpires.Units
{
    public class VillagerActor : ReceiveActor
    {
        private readonly IActorRef _resourcesSupervisor;
        private readonly ISubroutinesFactory _subroutinesFactory;

        public VillagerActor(ISupervisorsFactory supervisorsFactory, ISubroutinesFactory subroutinesFactory)
        {
            _resourcesSupervisor = supervisorsFactory.GetResourcesSupervisor();
            _subroutinesFactory = subroutinesFactory;
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

        protected virtual void ResourceHarvester(IHarvestResourceCommand command)
        {
            _currentCommand = command;
            Profession = command.AssociatedProfession;
            ResourceToRecolt = command.ResourceToRecolt;

            var resourceHarvesterRoutine = _subroutinesFactory.CreateResourceHarvesterActor(Context, Self);
            resourceHarvesterRoutine.Tell(command);

            ListenForCommands();
        }

        protected virtual void ResourceCarrier(uint quantity)
        {
            _resourcesSupervisor.Tell(new ResourceGathered(ResourceToRecolt, quantity));
            Self.Tell(_currentCommand);
            ListenForCommands();
        }

        private void ListenForCommands()
        {
            Receive<IHarvestResourceCommand>(m => Become(() => ResourceHarvester(m)));
            Receive<MaxCapacityReached>(m => Become(() => ResourceCarrier(m.Quantity)));
        }
    }
}
