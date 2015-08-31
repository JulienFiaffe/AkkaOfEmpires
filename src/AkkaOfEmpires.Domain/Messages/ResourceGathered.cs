namespace AkkaOfEmpires.Domain.Messages
{
    public class ResourceGathered
    {
        public Resource ResourceType { get; set; }
        public uint Quantity { get; set; }
    }
}
