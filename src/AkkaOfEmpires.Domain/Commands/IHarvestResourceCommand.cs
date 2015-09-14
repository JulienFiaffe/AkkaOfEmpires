namespace AkkaOfEmpires.Domain.Commands
{
    public interface IHarvestResourceCommand
    {
        Resource ResourceToRecolt { get; }
        Profession AssociatedProfession { get; }
    }

    public abstract class HarvestFood : IHarvestResourceCommand
    {
        public Resource ResourceToRecolt
        {
            get { return Resource.Food; }
        }

        public abstract Profession AssociatedProfession { get; }
    }

    public abstract class HarvestWood : IHarvestResourceCommand
    {
        public Resource ResourceToRecolt
        {
            get { return Resource.Wood; }
        }

        public abstract Profession AssociatedProfession { get; }
    }

    public abstract class HarvestGold : IHarvestResourceCommand
    {
        public Resource ResourceToRecolt
        {
            get { return Resource.Gold; }
        }

        public abstract Profession AssociatedProfession { get; }
    }

    public abstract class HarvestStone : IHarvestResourceCommand
    {
        public Resource ResourceToRecolt
        {
            get { return Resource.Stone; }
        }

        public abstract Profession AssociatedProfession { get; }
    }
}
