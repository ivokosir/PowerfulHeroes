using TaleWorlds.MountAndBlade;

namespace PowerfulHeroes
{
    public enum AgentType
    { Player, PlayerHorse, Ally, AllyHorse, Enemy, EnemyHorse, Other }

    public static class Utils
    {
        public static float GetDamageMultiplier(AgentType agentType)
        {
            if (Settings.Instance == null) return 1.0f;

            if (!Settings.Instance.Simple)
            {
                return agentType switch
                {
                    AgentType.Player => Settings.Instance.PlayerDamageMultiplier,
                    AgentType.PlayerHorse => Settings.Instance.PlayerHorseDamageMultiplier,
                    AgentType.Ally => Settings.Instance.AllyDamageMultiplier,
                    AgentType.AllyHorse => Settings.Instance.AllyHorseDamageMultiplier,
                    AgentType.Enemy => Settings.Instance.EnemyDamageMultiplier,
                    AgentType.EnemyHorse => Settings.Instance.EnemyHorseDamageMultiplier,
                    _ => 1.0f,
                };
            }
            return agentType switch
            {
                AgentType.Player or AgentType.Ally or AgentType.Enemy => Settings.Instance.DamageMultiplier,
                AgentType.PlayerHorse or AgentType.AllyHorse or AgentType.EnemyHorse => Settings.Instance.HorseDamageMultiplier,
                _ => 1.0f,
            };
        }

        public static float GetHitPointsMultiplier(AgentType agentType)
        {
            if (Settings.Instance == null) return 1.0f;

            if (!Settings.Instance.Simple)
            {
                return agentType switch
                {
                    AgentType.Player => Settings.Instance.PlayerHitPointsMultiplier,
                    AgentType.PlayerHorse => Settings.Instance.PlayerHorseHitPointsMultiplier,
                    AgentType.Ally => Settings.Instance.AllyHitPointsMultiplier,
                    AgentType.AllyHorse => Settings.Instance.AllyHorseHitPointsMultiplier,
                    AgentType.Enemy => Settings.Instance.EnemyHitPointsMultiplier,
                    AgentType.EnemyHorse => Settings.Instance.EnemyHorseHitPointsMultiplier,
                    _ => 1.0f,
                };
            }
            return agentType switch
            {
                AgentType.Player or AgentType.Ally or AgentType.Enemy => Settings.Instance.HitPointsMultiplier,
                AgentType.PlayerHorse or AgentType.AllyHorse or AgentType.EnemyHorse => Settings.Instance.HorseHitPointsMultiplier,
                _ => 1.0f,
            };
        }

        public static AgentType GetAgentType(Agent agent)
        {
            if (IsHero(agent))
            {
                if (agent.IsPlayerControlled) return AgentType.Player;
                if (agent.Team.Mission == null || agent.Team.IsPlayerAlly) return AgentType.Ally;
                return AgentType.Enemy;
            }
            if (IsHeroHorse(agent))
            {
                return GetAgentType(agent.RiderAgent) switch
                {
                    AgentType.Player => AgentType.PlayerHorse,
                    AgentType.Ally => AgentType.AllyHorse,
                    AgentType.Enemy => AgentType.EnemyHorse,
                    _ => AgentType.Other,
                };
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
