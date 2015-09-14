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
            Console.WriteLine("1 {0} harvested!", ResourceToHarvest);
            base.Handle(message);
        }
    }
}
