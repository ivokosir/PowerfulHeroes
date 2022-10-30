using MCM.Abstractions;
using MCM.Abstractions.Attributes;
using MCM.Abstractions.Attributes.v2;
using MCM.Abstractions.Base.Global;
using System.Collections.Generic;

namespace PowerfulHeroes
{
    public class Settings : AttributeGlobalSettings<Settings>
    {
        public override string Id => Statics.InstanceID;
        public override string DisplayName => $"{Statics.DisplayName} {typeof(Settings).Assembly.GetName().Version.ToString(3)}";
        public override string FolderName => Statics.ModuleFolder;
        public override string FormatType => Statics.FormatType;

        [SettingPropertyBool("Simple settings", IsToggle = true, RequireRestart = false, HintText = "Simple settings that changes data for all heroes (Companion, Noble, Player...)")]
        [SettingPropertyGroup("Simple settings", GroupOrder = 1)]
        public bool Simple
        {
            get => _Simple;
            set
            {
                _Simple = value;
                OnPropertyChanged(nameof(Advanced));
            }
        }

        private bool _Simple = true;

        private const string DamageMultiplierName = "Damage Recieved Multiplier";

        private const string DamageMultiplierHint = "This value is used to calculate the damage every hero receives, similar to difficulty in Native";

        private const string HorseDamageMultiplierName = "Horse Damage Recieved Multiplier";

        private const string HorseDamageMultiplierHint = "This value is used to calculate the damage hero's horse recieves";

        private const string HitPointsMultiplierName = "HitPoints Multiplier";

        private const string HitPointsMultiplierHint = "This value is used to calculate hero hitpoints in battle. Heroes will still take same damage but will have more health. If you increase this instead of lowering Damage Recieved Multiplier, hero will suffer the same amount of stagger as before the buff.";

        private const string HorseHitPointsMultiplierName = "Horse HitPoints Multiplier";

        private const string HorseHitPointsMultiplierHint = "This value is used to calculate hero's horse hitpoints in battle. Notice, this is calculated on start of a battle, so even if dismounted initial changes will persist.";

        [SettingPropertyFloatingInteger(DamageMultiplierName, 0.1f, 2.0f, "0%", RequireRestart = false, Order = 1, HintText = DamageMultiplierHint)]
        [SettingPropertyGroup("Simple settings", GroupOrder = 1)]
        public float DamageMultiplier { get; set; } = 0.7f;

        [SettingPropertyFloatingInteger(HorseDamageMultiplierName, 0.1f, 2.0f, "0%", RequireRestart = false, Order = 2, HintText = HorseDamageMultiplierHint)]
        [SettingPropertyGroup("Simple settings", GroupOrder = 1)]
        public float HorseDamageMultiplier { get; set; } = 0.7f;

        [SettingPropertyFloatingInteger(HitPointsMultiplierName, 0.5f, 10.0f, "0%", RequireRestart = false, Order = 3, HintText = HitPointsMultiplierHint)]
        [SettingPropertyGroup("Simple settings", GroupOrder = 1)]
        public float HitPointsMultiplier { get; set; } = 1.3f;

        [SettingPropertyFloatingInteger(HorseHitPointsMultiplierName, 0.5f, 10.0f, "0%", RequireRestart = false, Order = 4, HintText = HorseHitPointsMultiplierHint)]
        [SettingPropertyGroup("Simple settings", GroupOrder = 1)]
        public float HorseHitPointsMultiplier { get; set; } = 1.0f;

        [SettingPropertyBool("Advanced settings", HintText = "Advanced settings, use this if you want to set different settings for a specific hero type (Player, Ally, Enemy)", IsToggle = true, RequireRestart = false)]
        [SettingPropertyGroup("Advanced settings", GroupOrder = 2)]
        public bool Advanced
        {
            get => !_Simple;
            set
            {
                _Simple = !value;
                OnPropertyChanged(nameof(Simple));
            }
        }

        [SettingPropertyFloatingInteger(DamageMultiplierName, 0.1f, 2.0f, "0%", RequireRestart = false, Order = 1, HintText = DamageMultiplierHint)]
        [SettingPropertyGroup("Advanced settings/Player", GroupOrder = 1)]
        public float PlayerDamageMultiplier { get; set; } = 0.7f;

        [SettingPropertyFloatingInteger(HorseDamageMultiplierName, 0.1f, 2.0f, "0%", RequireRestart = false, Order = 2, HintText = HorseDamageMultiplierHint)]
        [SettingPropertyGroup("Advanced settings/Player", GroupOrder = 1)]
        public float PlayerHorseDamageMultiplier { get; set; } = 0.7f;

        [SettingPropertyFloatingInteger(HitPointsMultiplierName, 0.5f, 10.0f, "0%", RequireRestart = false, Order = 3, HintText = HitPointsMultiplierHint)]
        [SettingPropertyGroup("Advanced settings/Player", GroupOrder = 1)]
        public float PlayerHitPointsMultiplier { get; set; } = 1.3f;

        [SettingPropertyFloatingInteger(HorseHitPointsMultiplierName, 0.5f, 10.0f, "0%", RequireRestart = false, Order = 4, HintText = HorseHitPointsMultiplierHint)]
        [SettingPropertyGroup("Advanced settings/Player", GroupOrder = 1)]
        public float PlayerHorseHitPointsMultiplier { get; set; } = 1.0f;

        [SettingPropertyFloatingInteger(DamageMultiplierName, 0.1f, 2.0f, "0%", RequireRestart = false, Order = 1, HintText = DamageMultiplierHint)]
        [SettingPropertyGroup("Advanced settings/Ally Heroes", GroupOrder = 2)]
        public float AllyDamageMultiplier { get; set; } = 0.7f;

        [SettingPropertyFloatingInteger(HorseDamageMultiplierName, 0.1f, 2.0f, "0%", RequireRestart = false, Order = 2, HintText = HorseDamageMultiplierHint)]
        [SettingPropertyGroup("Advanced settings/Ally Heroes", GroupOrder = 2)]
        public float AllyHorseDamageMultiplier { get; set; } = 0.7f;

        [SettingPropertyFloatingInteger(HitPointsMultiplierName, 0.5f, 10.0f, "0%", RequireRestart = false, Order = 3, HintText = HitPointsMultiplierHint)]
        [SettingPropertyGroup("Advanced settings/Ally Heroes", GroupOrder = 2)]
        public float AllyHitPointsMultiplier { get; set; } = 1.3f;

        [SettingPropertyFloatingInteger(HorseHitPointsMultiplierName, 0.5f, 10.0f, "0%", RequireRestart = false, Order = 4, HintText = HorseHitPointsMultiplierHint)]
        [SettingPropertyGroup("Advanced settings/Ally Heroes", GroupOrder = 2)]
        public float AllyHorseHitPointsMultiplier { get; set; } = 1.0f;

        [SettingPropertyFloatingInteger(DamageMultiplierName, 0.1f, 2.0f, "0%", RequireRestart = false, Order = 1, HintText = DamageMultiplierHint)]
        [SettingPropertyGroup("Advanced settings/Enemy Heroes", GroupOrder = 3)]
        public float EnemyDamageMultiplier { get; set; } = 0.7f;

        [SettingPropertyFloatingInteger(HorseDamageMultiplierName, 0.1f, 2.0f, "0%", RequireRestart = false, Order = 2, HintText = HorseDamageMultiplierHint)]
        [SettingPropertyGroup("Advanced settings/Enemy Heroes", GroupOrder = 3)]
        public float EnemyHorseDamageMultiplier { get; set; } = 0.7f;

        [SettingPropertyFloatingInteger(HitPointsMultiplierName, 0.5f, 10.0f, "0%", RequireRestart = false, Order = 3, HintText = HitPointsMultiplierHint)]
        [SettingPropertyGroup("Advanced settings/Enemy Heroes", GroupOrder = 3)]
        public float EnemyHitPointsMultiplier { get; set; } = 1.3f;

        [SettingPropertyFloatingInteger(HorseHitPointsMultiplierName, 0.5f, 10.0f, "0%", RequireRestart = false, Order = 4, HintText = HorseHitPointsMultiplierHint)]
        [SettingPropertyGroup("Advanced settings/Enemy Heroes", GroupOrder = 3)]
        public float EnemyHorseHitPointsMultiplier { get; set; } = 1.0f;

        [SettingPropertyBool("Debug", RequireRestart = true, HintText = "Show debug info")]
        public bool Debug { get; set; } = false;

        public override IEnumerable<ISettingsPreset> GetBuiltInPresets()
        {
            foreach (var preset in base.GetBuiltInPresets())
            {
                yield return preset;
            }

            yield return new MemorySettingsPreset(Id, "native", "Native", () => new Settings
            {
                _Simple = true,
                DamageMultiplier = 1.0f,
                HorseDamageMultiplier = 1.0f,
                HitPointsMultiplier = 1.0f,
                HorseHitPointsMultiplier = 1.0f,
            });
        }

        public Settings()
        {
        }
    }
}
