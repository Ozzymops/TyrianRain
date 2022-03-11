using BepInEx;
using TyrianRain.Modules.Survivors;
using R2API.Utils;
using RoR2;
using System.Collections.Generic;
using System.Security;
using System.Security.Permissions;

[module: UnverifiableCode]
[assembly: SecurityPermission(SecurityAction.RequestMinimum, SkipVerification = true)]

namespace TyrianRain
{
    [BepInDependency("com.bepis.r2api", BepInDependency.DependencyFlags.HardDependency)]
    [NetworkCompatibility(CompatibilityLevel.EveryoneMustHaveMod, VersionStrictness.EveryoneNeedSameModVersion)]
    [BepInPlugin(MODUID, MODNAME, MODVERSION)]
    [R2APISubmoduleDependency(new string[]
    {
        "PrefabAPI",
        "LanguageAPI",
        "SoundAPI",
    })]

    public class TyrianRain : BaseUnityPlugin
    {
        public const string MODUID = "com.Ozzymops.TyrianRain";
        public const string MODNAME = "TyrianRain";
        public const string MODVERSION = "1.0.0";
        public const string developerPrefix = "ROB"; // change later!

        internal List<SurvivorBase> Survivors = new List<SurvivorBase>();

        public static TyrianRain instance;

        private void Awake()
        {
            instance = this;

            Modules.Assets.Initialize();
            Modules.Config.ReadConfig();
            Modules.States.RegisterStates();
            Modules.Buffs.RegisterBuffs();
            Modules.Tokens.AddTokens();

            // fix later!
            Modules.Projectiles.RegisterProjectiles();
            // Modules.ItemDisplays.PopulateDisplays();

            new Warrior().Initialize();
            new Modules.ContentPacks().Initialize();
            RoR2.ContentManagement.ContentManager.onContentPacksAssigned += LateSetup;

            Hook();
        }

        private void LateSetup(HG.ReadOnlyArray<RoR2.ContentManagement.ReadOnlyContentPack> obj)
        {
            // fix later!
            // Modules.Survivors.Warrior.instance.SetItemDisplays();
        }

        private void Hook()
        {
            On.RoR2.CharacterBody.RecalculateStats += CharacterBody_RecalculateStats;
        }

        private void CharacterBody_RecalculateStats(On.RoR2.CharacterBody.orig_RecalculateStats orig, CharacterBody self)
        {
            orig(self);

            if (self)
            {
                if (self.HasBuff(Modules.Buffs.armorBuff))
                {
                    self.armor += 300f;
                }
            }
        }
    }
}