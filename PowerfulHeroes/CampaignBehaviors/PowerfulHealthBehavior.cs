using TaleWorlds.CampaignSystem;
using TaleWorlds.Core;
using TaleWorlds.MountAndBlade;

namespace PowerfulHeroes.CampaignBehaviors
{
    internal class PowerfulHealthBehavior : CampaignBehaviorBase
    {
        private class PowerfulHealthMissionLogic : MissionLogic
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
                Message.Debug($"{agentType} {health}/{healthLimit} -> {agent.Health}/{agent.HealthLimit}");
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
                    Message.Debug($"Revert {agentType} {health}/{healthLimit} -> {agent.Health}/{agent.HealthLimit}");
                }
            }
        }

        public override void RegisterEvents()
        {
            CampaignEvents.OnMissionStartedEvent.AddNonSerializedListener(this, OnMissionStarted);
        }

        public void OnMissionStarted(IMission obj)
        {
            var missionBehavior = new PowerfulHealthBehavior.PowerfulHealthMissionLogic();
            Mission.Current.AddMissionBehavior(missionBehavior);
        }

        public override void SyncData(IDataStore dataStore)
        {
        }
    }
}
