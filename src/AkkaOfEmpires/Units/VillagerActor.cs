using Akka.Actor;
using AkkaOfEmpires.Domain;
using AkkaOfEmpires.Domain.Commands;
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

            var props = Props.Create<ResourceHarvesterActor>(Context.System.Scheduler, _resourcesSupervisor);
            _resourceHarvesterRoutine = Context.ActorOf(props);
        }

        public Profession Profession { get; private set; }
        public Resource ResourceToRecolt { get; private set; }

        private readonly IActorRef _resourceHarvesterRoutine;

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
            Profession = command.AssociatedProfession;
            ResourceToRecolt = command.ResourceToRecolt;

            _resourceHarvesterRoutine.Tell(command);

            ListenForCommands();
        }

        private void ListenForCommands()
        {
            Receive<IHarvestResourceCommand>(m => Become(() => ResourceHarvester(m)));
            // cancel subroutine if something else to do
        }
    }
}
