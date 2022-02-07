using MCM.Abstractions.Attributes;
using MCM.Abstractions.Attributes.v2;
using MCM.Abstractions.Settings.Base;
using MCM.Abstractions.Settings.Base.Global;
using System;
using System.Collections.Generic;
using TaleWorlds.Localization;

namespace PowerfulHeroes
{
    public class Settings : AttributeGlobalSettings<Settings>
    {
        public override string Id => Statics.InstanceID;
        public override string DisplayName => $"{new TextObject("{=PH_DisplayName}" + Statics.DisplayName)} {typeof(Settings).Assembly.GetName().Version.ToString(3)}";
        public override string FolderName => Statics.ModuleFolder;
        public override string FormatType => Statics.FormatType;

        [SettingPropertyBool("{=PH_Damage_Multiplier_Group}Damage Recieved Multiplier", IsToggle = true, RequireRestart = true,
            HintText = "{=PH_Damage_Multiplier_Group_Desc}Changes damage recieved, like in difficulty settings, but for every hero.")]
        [SettingPropertyGroup("{=PH_Damage_Multiplier_Group}Damage Recieved Multiplier")]
        public bool DamageMultiplierEnabled { get; set; } = true;

        [SettingPropertyFloatingInteger("{=PH_Hero_Damage_Multiplier}Hero Damage Recieved Multiplier", 0.1f, 2.0f, "0%", RequireRestart = false,
            HintText = "{=PH_Hero_Damage_Multiplier_Desc}This value is used to calculate the damage every hero (Companion, Noble, Player...) receives.")]
        [SettingPropertyGroup("{=PH_Damage_Multiplier_Group}Damage Recieved Multiplier")]
        public float DamageMultiplier { get; set; } = 0.7f;

        [SettingPropertyFloatingInteger("{=PH_Horse_Damage_Multiplier}Horse Damage Recieved Multiplier", 0.1f, 2.0f, "0%", RequireRestart = false,
            HintText = "{=PH_Horse_Damage_Multiplier_Desc}This value is used to calculate the damage hero's horse recieves.")]
        [SettingPropertyGroup("{=PH_Damage_Multiplier_Group}Damage Recieved Multiplier")]
        public float HorseDamageMultiplier { get; set; } = 0.7f;

        [SettingPropertyBool("{=PH_HitPoints_Multiplier_Group}HitPoints Multiplier", IsToggle = true, RequireRestart = true,
            HintText = "{=PH_HitPoints_Multiplier_Group_Desc}Changes hitpoints in battle. Does not affect campaign. Usefull when you want to survive long, but still be staggered.")]
        [SettingPropertyGroup("{=PH_HitPoints_Multiplier_Group}HitPoints Multiplier")]
        public bool HitPointMultiplierEnabled { get; set; } = true;

        [SettingPropertyFloatingInteger("{=PH_Hero_HitPoints_Multiplier}Hero HitPoints Multiplier", 0.5f, 10.0f, "0%", RequireRestart = false,
            HintText = "{=PH_Hero_HitPoints_Multiplier_Desc}This value is used to calculate hero hitpoints in battle. Heroes will still take same damage but will have more health.")]
        [SettingPropertyGroup("{=PH_HitPoints_Multiplier_Group}HitPoints Multiplier")]
        public float HitPointsMultiplier { get; set; } = 1.3f;

        [SettingPropertyFloatingInteger("{=PH_Horse_HitPoints_Multiplier}Horse HitPoints Multiplier", 0.5f, 10.0f, "0%", RequireRestart = false,
            HintText = "{=PH_Horse_HitPoints_Multiplier_Desc}This value is used to calculate hero's horse hitpoints in battle. Notice, this is calculated on start of a battle, so even if dismounted changes will persist.")]
        [SettingPropertyGroup("{=PH_HitPoints_Multiplier_Group}HitPoints Multiplier")]
        public float HorseHitPointsMultiplier { get; set; } = 1.0f;

        [SettingPropertyBool("{=PH_Debug}Debug", RequireRestart = true, HintText = "{=PH_Debug_Desc}Show debug info")]
        [SettingPropertyGroup("{=PH_Logging}Logging")]
        public bool Debug { get; set; } = false;

        public override IDictionary<string, Func<BaseSettings>> GetAvailablePresets()
        {
            IDictionary<string, Func<BaseSettings>>? basePresets = base.GetAvailablePresets();

            basePresets.Add("Native all off", () => new Settings()
            {
                DamageMultiplierEnabled = false,
                DamageMultiplier = 1.0f,
                HorseDamageMultiplier = 1.0f,
                HitPointMultiplierEnabled = false,
                HitPointsMultiplier = 1.0f,
                HorseHitPointsMultiplier = 1.0f,
            });

            basePresets.Add("Native all on", () => new Settings()
            {
                DamageMultiplierEnabled = true,
                DamageMultiplier = 1.0f,
                HorseDamageMultiplier = 1.0f,
                HitPointMultiplierEnabled = true,
                HitPointsMultiplier = 1.0f,
                HorseHitPointsMultiplier = 1.0f,
            });

            return basePresets;
        }

        public Settings()
        {
        }
    }
}
