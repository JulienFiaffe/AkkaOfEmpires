using System;

namespace AkkaOfEmpires.Domain.Messages
{
    public class FoodGathered
    {
        public UInt32 Quantity { get; set; }
    }

    public class GoldGathered
    {
        public UInt32 Quantity { get; set; }
    }

    public class StoneGathered
    {
        public UInt32 Quantity { get; set; }
    }

    public class WoodGathered
    {
        public UInt32 Quantity { get; set; }
    }
}
