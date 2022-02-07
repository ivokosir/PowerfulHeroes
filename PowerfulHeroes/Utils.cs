using TaleWorlds.MountAndBlade;

namespace PowerfulHeroes
{
    public enum AgentType
    { Hero, HeroHorse, Other }

    public static class Utils
    {
        public static AgentType GetAgentType(Agent agent)
        {
            if (IsHero(agent))
            {
                return AgentType.Hero;
            }
            if (IsHeroHorse(agent))
            {
                return AgentType.HeroHorse;
            }
            return AgentType.Other;
        }

        private static bool IsHero(Agent agent)
        {
            return agent.IsHuman && agent.IsHero;
        }

        private static bool IsHeroHorse(Agent agent)
        {
            return agent.IsMount && agent.RiderAgent is not null && IsHero(agent.RiderAgent);
        }
    }
}
