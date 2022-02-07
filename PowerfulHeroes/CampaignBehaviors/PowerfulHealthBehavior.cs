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
                if (!Settings.Instance!.HitPointMultiplierEnabled) return;
                var multiplier = Settings.Instance!.HitPointsMultiplier;
                var horseMultiplier = Settings.Instance!.HorseHitPointsMultiplier;
                var healthLimit = agent.HealthLimit;
                var health = agent.Health;
                switch (Utils.GetAgentType(agent))
                {
                    case AgentType.Hero:
                        agent.BaseHealthLimit *= multiplier;
                        agent.HealthLimit *= multiplier;
                        agent.Health *= multiplier;
                        Message.Debug($"New Hero {health}/{healthLimit} -> {agent.Health}/{agent.HealthLimit}");
                        break;

                    case AgentType.HeroHorse:
                        agent.BaseHealthLimit *= horseMultiplier;
                        agent.HealthLimit *= horseMultiplier;
                        agent.Health *= horseMultiplier;
                        Message.Debug($"New Hero Horse {agent.Health}/{agent.HealthLimit}");
                        break;
                }
            }

            protected override void OnEndMission()
            {
                if (!Settings.Instance!.HitPointMultiplierEnabled) return;
                var multiplier = Settings.Instance!.HitPointsMultiplier;
                foreach (var agent in Mission.Agents)
                {
                    if (Utils.GetAgentType(agent) == AgentType.Hero)
                    {
                        var healthLimit = agent.HealthLimit;
                        var health = agent.Health;
                        agent.BaseHealthLimit /= multiplier;
                        agent.HealthLimit /= multiplier;
                        agent.Health /= multiplier;
                        Message.Debug($"Revert Hero {health}/{healthLimit} -> {agent.Health}/{agent.HealthLimit}");
                    }
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
