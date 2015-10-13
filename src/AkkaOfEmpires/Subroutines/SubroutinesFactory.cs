using Akka.Actor;

namespace AkkaOfEmpires.Subroutines
{
    public interface ISubroutinesFactory
    {
        IActorRef CreateResourceHarvesterActor(IActorContext actorContext, IActorRef villagerActor);
    }

    public class SubroutinesFactory : ISubroutinesFactory
    {
        public IActorRef CreateResourceHarvesterActor(IActorContext actorContext, IActorRef villagerActor)
        {
            var props = Props.Create<ResourceHarvesterActor>(actorContext.System.Scheduler, villagerActor);
            var resourceHarvesterRoutine = actorContext.ActorOf(props);
            return resourceHarvesterRoutine;
        }
    }
}
