using AkkaOfEmpires.Supervisors;
using AkkaOfEmpires.Domain.Messages;
using System;
using AkkaOfEmpires.Domain;

namespace AkkaOfEmpires.ConsoleUI.ConsoleActors
{
    public class ConsoleResourcesSupervisorActor : ResourcesSupervisorActor
    {
        public override void Handle(ResourceGathered message)
        {
            Console.WriteLine("ResourceGathered: {0} {1}", message.Quantity, message.ResourceType);
            base.Handle(message);
            Console.WriteLine("Resources available: {0}: {1} | {2}: {3} | {4}: {5} | {6}: {7}",
                Resource.Food, ResourcesAmounts[Resource.Food],
                Resource.Wood, ResourcesAmounts[Resource.Wood],
                Resource.Gold, ResourcesAmounts[Resource.Gold],
                Resource.Stone, ResourcesAmounts[Resource.Stone]);
        }
    }
}
