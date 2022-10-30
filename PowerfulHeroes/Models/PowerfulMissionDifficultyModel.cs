using TaleWorlds.MountAndBlade;

namespace PowerfulHeroes.Models
{
    internal class PowerfulMissionDifficultyModel : SandBox.GameComponents.SandboxMissionDifficultyModel
    {
        public override float GetDamageMultiplierOfCombatDifficulty(Agent agent, Agent? attackerAgent = null)
        {
            var initial = base.GetDamageMultiplierOfCombatDifficulty(agent, attackerAgent);

            var agentType = Utils.GetAgentType(agent);
            if (agentType == AgentType.Other) return initial;

            var multiplier = Utils.GetDamageMultiplier(agentType);
            return initial * multiplier;
        }
    }
}
