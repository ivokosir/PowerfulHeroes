using PowerfulHeroes.CampaignBehaviors;
using PowerfulHeroes.Models;
using System.Linq;
using TaleWorlds.CampaignSystem;
using TaleWorlds.Core;
using TaleWorlds.Engine;
using TaleWorlds.MountAndBlade;

namespace PowerfulHeroes
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
                Message.ShowDebug = Settings.Instance.Debug;
                Message.Debug("Settings loaded successfully");
            }
            else
            {
                Message.Error("Settings failed to load");
            }
            Message.DisplayModLoadedMessage();
        }

        protected override void OnGameStart(Game game, IGameStarter gameStarter)
        {
            base.OnGameStart(game, gameStarter);

            if (game.GameType is not Campaign) return;
            if (Settings.Instance is null) return;

            CampaignGameStarter campaignGameStarter = (CampaignGameStarter)gameStarter;

            if (Settings.Instance.HitPointMultiplierEnabled)
            {
                campaignGameStarter.AddBehavior(new PowerfulHealthBehavior());
                Message.Debug("Loaded PowerfulHealthBehavior Behavior");
            }
            if (Settings.Instance.DamageMultiplierEnabled)
            {
                campaignGameStarter.AddModel(new PowerfulMissionDifficultyModel());
                Message.Debug("Loaded PowerfulMissionDifficultyModel Model");
            }
        }
    }
}
