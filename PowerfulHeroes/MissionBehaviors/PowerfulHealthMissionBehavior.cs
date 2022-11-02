using TaleWorlds.Core;
using TaleWorlds.MountAndBlade;

namespace PowerfulHeroes.MissionBehaviors
{
    internal class PowerfulHealthMissionBehaviour : MissionLogic
    {
        public override void OnAgentBuild(Agent agent, Banner banner)
        {
            var agentType = Utils.GetAgentType(agent);
            if (agentType == AgentType.Other) return;

            var multiplier = Utils.GetHitPointsMultiplier(agentType);
            var healthLimit = agent.HealthLimit;
            var health = agent.Health;

            agent.BaseHealthLimit *= multiplier;
            agent.HealthLimit *= multiplier;
            agent.Health *= multiplier;
            Message.Debug($"{agent.Name} ({agentType}) {health}/{healthLimit} -> {agent.Health}/{agent.HealthLimit}");
        }

        protected override void OnEndMission()
        {
            foreach (var agent in Mission.Agents)
            {
                var agentType = Utils.GetAgentType(agent);
                if (agentType == AgentType.Other) continue;

                var multiplier = Utils.GetHitPointsMultiplier(agentType);
                var healthLimit = agent.HealthLimit;
                var health = agent.Health;

                agent.BaseHealthLimit /= multiplier;
                agent.HealthLimit /= multiplier;
                agent.Health /= multiplier;
                Message.Debug($"Revert {agent.Name} ({agentType}) {health}/{healthLimit} -> {agent.Health}/{agent.HealthLimit}");
            }
        }
    }
}
