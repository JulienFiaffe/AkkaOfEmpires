using AkkaOfEmpires.Supervisors;
using AkkaOfEmpires.Domain.Messages;
using System;

namespace AkkaOfEmpires.ConsoleUI.ConsoleActors
{
    public class ConsoleResourcesSupervisorActor : ResourcesSupervisorActor
    {
        public override void Handle(ResourceGathered message)
        {
            Console.WriteLine("ResourceGathered: {0} {1}", message.Quantity, message.ResourceType);
            base.Handle(message);
        }
    }
}
