using Bannerlord.PowerfulHeroes.CampaignBehaviors;
using Bannerlord.PowerfulHeroes.MissionBehaviors;
using Bannerlord.PowerfulHeroes.Models;
using System.Linq;
using TaleWorlds.CampaignSystem;
using TaleWorlds.Core;
using TaleWorlds.Engine;
using TaleWorlds.MountAndBlade;

namespace Bannerlord.PowerfulHeroes
{
    public class SubModule : MBSubModuleBase
    {
        protected override void OnSubModuleLoad()
        {
            base.OnSubModuleLoad();
        }

        protected override void OnSubModuleUnloaded()
        {
            base.OnSubModuleUnloaded();
        }

        protected override void OnBeforeInitialModuleScreenSetAsRoot()
        {
            base.OnBeforeInitialModuleScreenSetAsRoot();

            if (!Utilities.GetModulesNames().ToList().Contains("Bannerlord.MBOptionScreen"))
            {
                Message.Error("Requires MCM, please install the MCM module");
            }
            else
            {
                Message.Debug("MCM Module is loaded");
            }
            if (Settings.Instance is not null)
            {
                Message.Debug("Settings loaded successfully");
            }
            else
            {
                Message.Error("Settings failed to load");
            }

            Message.Info("Loaded");
        }

        protected override void OnGameStart(Game game, IGameStarter gameStarter)
        {
            base.OnGameStart(game, gameStarter);

            if (Settings.Instance is null) return;

            gameStarter.AddModel(new PowerfulMissionDifficultyModel());
            Message.Debug("Loaded PowerfulMissionDifficultyModel");

            if (gameStarter is CampaignGameStarter campaignGameStarter)
            {
                campaignGameStarter.AddBehavior(new PowerfulHealthCampaignBehavior());
                Message.Debug("Loaded PowerfulHealthCampaignBehavior");
            }
        }

        public override void OnMissionBehaviorInitialize(Mission mission)
        {
            base.OnMissionBehaviorInitialize(mission);

            mission.AddMissionBehavior(new PowerfulHealthMissionBehaviour());
            Message.Debug("Loaded PowerfulHealthMissionBehaviour");
        }
    }
}
