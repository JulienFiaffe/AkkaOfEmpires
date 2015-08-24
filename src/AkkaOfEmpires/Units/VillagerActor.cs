using Akka.Actor;
using AkkaOfEmpires.Domain;
using AkkaOfEmpires.Domain.Commands;
using AkkaOfEmpires.Domain.Messages;

namespace AkkaOfEmpires.Units
{
    public class VillagerActor : TypedActor,
        IHandle<GatherFruits>,
        IHandle<ShepherdFlock>
    {
        private readonly IActorRef _resourcesSupervisor;

        public VillagerActor(IActorRef resourcesSupervisor)
        {
            _resourcesSupervisor = resourcesSupervisor;
            Profession = Profession.Idle;
        }

        public Profession Profession { get; private set; }
        public Resource ResourceToRecolt { get; private set; }

        public void Handle(GatherFruits message)
        {
            ResourceToRecolt = Resource.Food;
            _resourcesSupervisor.Tell(new FoodGathered { Quantity = 10 });
        }

        public void Handle(ShepherdFlock message)
        {
            ResourceToRecolt = Resource.Food;
            _resourcesSupervisor.Tell(new FoodGathered { Quantity = 10 });
        }
    }
}
