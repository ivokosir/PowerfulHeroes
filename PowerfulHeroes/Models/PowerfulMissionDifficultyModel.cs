using TaleWorlds.MountAndBlade;

namespace PowerfulHeroes.Models
{
    internal class PowerfulMissionDifficultyModel : SandBox.SandboxMissionDifficultyModel
    {
        public override float GetDamageMultiplierOfCombatDifficulty(Agent agent, Agent? attackerAgent = null)
        {
            var initial = base.GetDamageMultiplierOfCombatDifficulty(agent, attackerAgent);
            if (!Settings.Instance!.DamageMultiplierEnabled) return initial;

            return Utils.GetAgentType(agent) switch
            {
                AgentType.Hero => initial * Settings.Instance!.DamageMultiplier,
                AgentType.HeroHorse => initial * Settings.Instance!.HorseDamageMultiplier,
                _ => initial,
            };
        }
    }
}
