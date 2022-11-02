using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.Settlements;
using TaleWorlds.Core;
using TaleWorlds.MountAndBlade;

namespace PowerfulHeroes.CampaignBehaviors
{
    internal class PowerfulHealthCampaignBehavior : CampaignBehaviorBase
    {
        public override void RegisterEvents()
        {
            CampaignEvents.PlayerStartedTournamentMatch.AddNonSerializedListener(this, PlayerStartedTournamentMatch);
        }

        public void PlayerStartedTournamentMatch(Town town)
        {
            foreach (var agent in Mission.Current.Agents)
            {
                if (agent.IsPlayerControlled)
                {
                    var agentType = Utils.GetAgentType(agent);
                    if (agentType == AgentType.Other) continue;

                    var multiplier = Utils.GetHitPointsMultiplier(agentType);

                    Message.Debug($"Fix {agent.Name} ({agentType}) {agent.Health} -> {agent.Health * multiplier}");
                    agent.Health *= multiplier;
                }
            }
        }

        public override void SyncData(IDataStore dataStore)
        {
        }
    }
}
