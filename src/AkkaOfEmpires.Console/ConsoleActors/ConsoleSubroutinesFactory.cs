using AkkaOfEmpires.Subroutines;
using Akka.Actor;

namespace AkkaOfEmpires.ConsoleUI.ConsoleActors
{
    public class ConsoleSubroutinesFactory : ISubroutinesFactory
    {
        public IActorRef CreateResourceHarvesterActor(IActorContext actorContext, IActorRef villagerActor)
        {
            var props = Props.Create<ConsoleResourceHarvesterActor>(actorContext.System.Scheduler, villagerActor);
            var consoleActor = actorContext.ActorOf(props);
            return consoleActor;
        }
    }
}
