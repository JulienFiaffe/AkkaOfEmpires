using AkkaOfEmpires.Supervisors;
using Akka.Actor;

namespace AkkaOfEmpires.ConsoleUI.ConsoleActors
{
    public class ConsoleSupervisorsFactory : ISupervisorsFactory
    {
        public ConsoleSupervisorsFactory(ActorSystem system)
        {
            _resourcesSupervisor = system.ActorOf<ConsoleResourcesSupervisorActor>();
        }

        private readonly IActorRef _resourcesSupervisor;

        public IActorRef GetResourcesSupervisor()
        {
            return _resourcesSupervisor;
        }
    }
}
