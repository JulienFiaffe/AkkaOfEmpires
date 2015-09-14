namespace AkkaOfEmpires.Domain.Messages
{
    public class ResourceGathered
    {
        public ResourceGathered(Resource resourceType, uint quantity)
        {
            ResourceType = resourceType;
            Quantity = quantity;
        }

        public Resource ResourceType { get; private set; }
        public uint Quantity { get; private set; }
    }
}
