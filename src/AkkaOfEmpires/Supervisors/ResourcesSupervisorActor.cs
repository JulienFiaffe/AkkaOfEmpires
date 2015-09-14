using System.Collections.Generic;
using Akka.Actor;
using AkkaOfEmpires.Domain;
using AkkaOfEmpires.Domain.Messages;

namespace AkkaOfEmpires.Supervisors
{
    public class ResourcesSupervisorActor : TypedActor, IHandle<ResourceGathered>
    {
        public Dictionary<Resource, uint> ResourcesAmounts { get; private set; }

        public ResourcesSupervisorActor()
        {
            ResourcesAmounts = new Dictionary<Resource, uint>
            {
                {Resource.Food, 0},
                {Resource.Wood, 0},
                {Resource.Stone, 0},
                {Resource.Gold, 0}
            };
        }

        public virtual void Handle(ResourceGathered message)
        {
            ResourcesAmounts[message.ResourceType] += message.Quantity;
        }
    }
}
