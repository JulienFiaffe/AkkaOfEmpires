using Akka.Actor;
using AkkaOfEmpires.ConsoleUI.ConsoleActors;
using AkkaOfEmpires.Domain.Commands;

namespace AkkaOfEmpires.ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            var system = AkkaOfEmpiresSystem.Start();

            var supervisorProps = Props.Create<ConsoleResourcesSupervisorActor>();
            var supervisor = system.ActorOf(supervisorProps);

            var villagerProps = Props.Create<ConsoleVillagerActor>(supervisor);
            var gathered = system.ActorOf(villagerProps);
            gathered.Tell(new GatherFruits());

            var shepherd = system.ActorOf(villagerProps);
            shepherd.Tell(new ShepherdFlock());

            var lumberjack = system.ActorOf(villagerProps);
            lumberjack.Tell(new CutTrees());

            system.AwaitTermination();
        }
    }
}
