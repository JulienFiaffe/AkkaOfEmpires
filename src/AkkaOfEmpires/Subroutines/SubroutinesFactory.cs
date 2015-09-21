using Akka.Actor;

namespace AkkaOfEmpires.Subroutines
{
    public class SubroutinesFactory
    {
        public virtual IActorRef CreateResourceHarvesterActor(IActorContext actorContext, IActorRef villagerActor)
        {
            var props = Props.Create<ResourceHarvesterActor>(actorContext.System.Scheduler, villagerActor);
            var resourceHarvesterRoutine = actorContext.ActorOf(props);
            return resourceHarvesterRoutine;
        }
    }
}
