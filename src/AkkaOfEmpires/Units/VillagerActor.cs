using Akka.Actor;
using AkkaOfEmpires.Domain;
using AkkaOfEmpires.Domain.Commands;
using AkkaOfEmpires.Domain.Messages;

namespace AkkaOfEmpires.Units
{
    public class VillagerActor : ReceiveActor
    {
        private readonly IActorRef _resourcesSupervisor;

        public VillagerActor(IActorRef resourcesSupervisor)
        {
            _resourcesSupervisor = resourcesSupervisor;
            Profession = Profession.Idle;
        }

        public Profession Profession { get; private set; }
        public Resource ResourceToRecolt { get; private set; }

        protected override void PreStart()
        {
            base.PreStart();
            Become(Idle);
        }

        private void Idle()
        {
            ListenForCommands();
        }

        //private void Gatherer()
        //{
        //    Profession = Profession.Gatherer;
        //    ResourceToRecolt = Resource.Food;
        //    // repeat until new order or lack of bushes
        //    _resourcesSupervisor.Tell(new ResourceRecolted { ResourceType = ResourceToRecolt, Quantity = 10 });

        //    CommandsHandler();
        //}

        //private void Shepherd()
        //{
        //    Profession = Profession.Shepherd;
        //    ResourceToRecolt = Resource.Food;
        //    // repeat until new order or lack of sheeps
        //    _resourcesSupervisor.Tell(new ResourceRecolted { ResourceType = ResourceToRecolt, Quantity = 10 });

        //    CommandsHandler();
        //}

        //private void Hunter()
        //{
        //    Profession = Profession.Hunter;
        //    ResourceToRecolt = Resource.Food;

        //    _resourcesSupervisor.Tell(new ResourceRecolted{ResourceType = ResourceToRecolt, Quantity = 10});

        //    CommandsHandler();
        //}

        //private void Farmer()
        //{
        //    Profession = Profession.Farmer;
        //    ResourceToRecolt = Resource.Food;

        //    _resourcesSupervisor.Tell(new ResourceRecolted { ResourceType = ResourceToRecolt, Quantity = 10 });

        //    CommandsHandler();
        //}

        //private void Fisherman()
        //{
        //    Profession = Profession.Fisherman;
        //    ResourceToRecolt = Resource.Food;

        //    _resourcesSupervisor.Tell(new ResourceRecolted { ResourceType = ResourceToRecolt, Quantity = 10 });

        //    CommandsHandler();
        //}

        //private void Lumberjack()
        //{
        //    Profession = Profession.Lumberjack;
        //    ResourceToRecolt = Resource.Wood;

        //    _resourcesSupervisor.Tell(new ResourceRecolted {ResourceType = ResourceToRecolt, Quantity = 10});
        //}

        //private void StoneMiner()
        //{
        //    Profession = Profession.StoneMiner;
        //    ResourceToRecolt = Resource.Stone;

        //    _resourcesSupervisor.Tell(new ResourceRecolted { ResourceType = ResourceToRecolt, Quantity = 10 });
        //}

        //private void GoldMiner()
        //{
        //    Profession = Profession.GoldMiner;
        //    ResourceToRecolt = Resource.Gold;

        //    _resourcesSupervisor.Tell(new ResourceRecolted { ResourceType = ResourceToRecolt, Quantity = 10 });
        //}

        private void ResourceHarvester(IHarvestResourceCommand command)
        {
            Profession = command.AssociatedProfession;
            ResourceToRecolt = command.ResourceToRecolt;

            _resourcesSupervisor.Tell(new ResourceRecolted { ResourceType = ResourceToRecolt, Quantity = 10 });

            ListenForCommands();
        }

        private void ListenForCommands()
        {
            Receive<IHarvestResourceCommand>(m => Become(() => ResourceHarvester(m)));

            //Receive<GatherFruits>(m => Become(Gatherer));
            //Receive<ShepherdFlock>(m => Become(Shepherd));
            //Receive<HuntPrey>(m => Become(Hunter));
            //Receive<FarmCrops>(m => Become(Farmer));
            //Receive<CatchFish>(m => Become(Fisherman));
            //Receive<CutTrees>(m => Become(Lumberjack));
            //Receive<MineStone>(m => Become(StoneMiner));
            //Receive<MineGold>(m => Become(GoldMiner));
        }
    }
}
