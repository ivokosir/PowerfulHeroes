using TaleWorlds.Core;
using TaleWorlds.MountAndBlade;

namespace PowerfulHeroes.MissionBehaviors
{
    internal class PowerfulHealthMissionBehaviour : MissionLogic
    {
        private void BuffAgent(Agent agent)
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

        private void RevertAgent(Agent agent)
        {
            var agentType = Utils.GetAgentType(agent);
            if (agentType == AgentType.Other) return;

            var multiplier = Utils.GetHitPointsMultiplier(agentType);
            var healthLimit = agent.HealthLimit;
            var health = agent.Health;

            agent.BaseHealthLimit /= multiplier;
            agent.HealthLimit /= multiplier;
            agent.Health /= multiplier;
            Message.Debug($"Revert {agent.Name} ({agentType}) {health}/{healthLimit} -> {agent.Health}/{agent.HealthLimit}");
        }

        public override void OnAgentBuild(Agent agent, Banner banner)
        {
            BuffAgent(agent);
        }

        public override void OnAgentDeleted(Agent affectedAgent)
        {
            RevertAgent(affectedAgent);
        }

        public override void OnAgentRemoved(Agent affectedAgent, Agent affectorAgent, AgentState agentState, KillingBlow blow)
        {
            RevertAgent(affectedAgent);
        }

        protected override void OnEndMission()
        {
            foreach (var agent in Mission.Agents)
            {
                RevertAgent(agent);
            }
        }
    }
}
