using Akka.Actor;
using AkkaOfEmpires.Domain;
using AkkaOfEmpires.Domain.Commands;
using AkkaOfEmpires.Domain.Messages;
using System;

namespace AkkaOfEmpires.Subroutines
{
    public class ResourceHarvesterActor : TypedActor,
        IHandle<IHarvestResourceCommand>,
        IHandle<ResourceHarvesterActor.ResourceHarvested>
    {
        private readonly ITellScheduler _messageScheduler;
        private readonly IActorRef _resourcesSupervisor;

        public const uint MAX_CAPACITY = 10;
        public uint CurrentlyCarrying { get; private set; }

        public Resource ResourceToHarvest { get; private set; }

        public ResourceHarvesterActor(ITellScheduler messageScheduler, IActorRef resourcesSupervisor)
        {
            _messageScheduler = messageScheduler;
            _resourcesSupervisor = resourcesSupervisor;
            CurrentlyCarrying = 0;
        }

        public void Handle(IHarvestResourceCommand message)
        {
            if (message.ResourceToRecolt != ResourceToHarvest)
            {
                ResourceToHarvest = message.ResourceToRecolt;
                CurrentlyCarrying = 0;
            }
            _messageScheduler.ScheduleTellOnce(TimeSpan.FromSeconds(1), Self, new ResourceHarvested(), Self);
        }

        public void Handle(ResourceHarvested message)
        {
            CurrentlyCarrying++;
            if (CurrentlyCarrying == MAX_CAPACITY)
                _resourcesSupervisor.Tell(new ResourceGathered(ResourceToHarvest, CurrentlyCarrying));
            else
                _messageScheduler.ScheduleTellOnce(TimeSpan.FromSeconds(1), Self, new ResourceHarvested(), Self);
        }

        public class ResourceHarvested { }
    }
}
