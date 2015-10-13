using Akka.Actor;
using Akka.DI.Core;
using Akka.DI.StructureMap;
using AkkaOfEmpires.ConsoleUI.ConsoleActors;
using AkkaOfEmpires.Domain.Commands;
using AkkaOfEmpires.Subroutines;
using StructureMap;

namespace AkkaOfEmpires.ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            var system = AkkaOfEmpiresSystem.Start();
            var container = GetDependencyContainer(system);
            var resolver = new StructureMapDependencyResolver(container, system);

            var villagerProps = system.DI().Props<ConsoleVillagerActor>();
            var gathered = system.ActorOf(villagerProps);
            gathered.Tell(new GatherFruits());

            var shepherd = system.ActorOf(villagerProps);
            shepherd.Tell(new ShepherdFlock());

            var lumberjack = system.ActorOf(villagerProps);
            lumberjack.Tell(new CutTrees());

            system.AwaitTermination();
        }

        static IContainer GetDependencyContainer(ActorSystem system)
        {
            var container = new Container(c =>
            {
                c.For<ISubroutinesFactory>().Use<ConsoleSubroutinesFactory>();
                c.ForSingletonOf<IActorRef>().Add(system.ActorOf<ConsoleResourcesSupervisorActor>());
            });
            return container;
        }
    }
}
