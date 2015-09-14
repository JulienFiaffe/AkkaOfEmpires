using Akka.Actor;

namespace AkkaOfEmpires
{
    public static class AkkaOfEmpiresSystem
    {
        public static ActorSystem Start()
        {
            var system = ActorSystem.Create("AkkaOfEmpires");

            return system;
        }
    }
}
