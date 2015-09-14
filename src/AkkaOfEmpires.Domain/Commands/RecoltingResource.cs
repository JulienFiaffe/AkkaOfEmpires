namespace AkkaOfEmpires.Domain.Commands
{
    public class GatherFruits : HarvestFood
    {
        public override Profession AssociatedProfession
        {
            get { return Profession.Gatherer; }
        }
    }

    public class ShepherdFlock : HarvestFood
    {
        public override Profession AssociatedProfession
        {
            get { return Profession.Shepherd; }
        }
    }

    public class HuntPrey : HarvestFood
    {
        public override Profession AssociatedProfession
        {
            get { return Profession.Hunter; }
        }
    }

    public class FarmCrops : HarvestFood
    {
        public override Profession AssociatedProfession
        {
            get { return Profession.Farmer; }
        }
    }

    public class CatchFish : HarvestFood
    {
        public override Profession AssociatedProfession
        {
            get { return Profession.Fisherman; }
        }
    }

    public class CutTrees : HarvestWood
    {
        public override Profession AssociatedProfession
        {
            get { return Profession.Lumberjack; }
        }
    }

    public class MineStone : HarvestStone
    {
        public override Profession AssociatedProfession
        {
            get { return Profession.Miner; }
        }
    }

    public class MineGold : HarvestGold
    {
        public override Profession AssociatedProfession
        {
            get { return Profession.Miner; }
        }
    }
}
