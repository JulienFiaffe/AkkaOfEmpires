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
        private readonly IActorRef _villagerActor;

        public const uint MAX_CAPACITY = 10;
        public uint CurrentlyCarrying { get; private set; }

        public Resource ResourceToHarvest { get; private set; }

        public ResourceHarvesterActor(ITellScheduler messageScheduler, IActorRef villagerAcor)
        {
            _messageScheduler = messageScheduler;
            _villagerActor = villagerAcor;
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

        public virtual void Handle(ResourceHarvested message)
        {
            CurrentlyCarrying++;
            if (CurrentlyCarrying == MAX_CAPACITY)
            {
                _villagerActor.Tell(new MaxCapacityReached(CurrentlyCarrying));
                Context.Stop(Self);
            }
            else
                _messageScheduler.ScheduleTellOnce(TimeSpan.FromSeconds(1), Self, new ResourceHarvested(), Self);
        }

        public class ResourceHarvested { }
    }
}
