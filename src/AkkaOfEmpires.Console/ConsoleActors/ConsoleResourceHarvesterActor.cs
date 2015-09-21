using Akka.Actor;
using AkkaOfEmpires.Subroutines;
using System;

namespace AkkaOfEmpires.ConsoleUI.ConsoleActors
{
    public class ConsoleResourceHarvesterActor : ResourceHarvesterActor
    {
        public ConsoleResourceHarvesterActor(ITellScheduler messageScheduler, IActorRef villagerAcor)
            : base(messageScheduler, villagerAcor)
        {
        }

        public override void Handle(ResourceHarvested message)
        {
            base.Handle(message);
            Console.WriteLine("1 unit of {0} harvested. (carrying {1}).", ResourceToHarvest, CurrentlyCarrying);
        }
    }
}
