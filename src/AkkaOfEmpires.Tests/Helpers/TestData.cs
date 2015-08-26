using AkkaOfEmpires.Domain.Commands;

namespace AkkaOfEmpires.Tests.Helpers
{
    public static class TestData
    {
        public static ShepherdFlock ShepherdCommand = new ShepherdFlock();
        public static GatherFruits GathererCommand = new GatherFruits();
    }
}
