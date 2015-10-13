using Akka.Actor;

namespace AkkaOfEmpires.Supervisors
{
    public interface ISupervisorsFactory
    {
        IActorRef GetResourcesSupervisor();
    }

    public class SupervisorsFactory : ISupervisorsFactory
    {
        public SupervisorsFactory(ActorSystem system)
        {
            _resourcesSupervisor = system.ActorOf<ResourcesSupervisorActor>();
        }

        private readonly IActorRef _resourcesSupervisor;

        public IActorRef GetResourcesSupervisor()
        {
            return _resourcesSupervisor;
        }
    }
}
