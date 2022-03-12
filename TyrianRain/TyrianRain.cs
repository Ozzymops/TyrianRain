using BepInEx;
using TyrianRain.Modules.Survivors;
using R2API.Utils;
using RoR2;
using UnityEngine;
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
            On.RoR2.HealthComponent.TakeDamage += HealthComponent_TakeDamage;
        }

        private void CharacterBody_RecalculateStats(On.RoR2.CharacterBody.orig_RecalculateStats orig, CharacterBody self)
        {
            orig(self);

            if (self)
            {
                // fury
                if (self.HasBuff(Modules.Buffs.boonFury))
                {
                    self.crit += 20;
                    self.critMultiplier += 0.2f;
                }

                // alacrity
                if (self.HasBuff(Modules.Buffs.boonAlacrity))
                {
                    self.skillLocator.primary.cooldownScale = 0.75f;
                    self.skillLocator.secondary.cooldownScale = 0.75f;
                    self.skillLocator.utility.cooldownScale = 0.75f;
                    self.skillLocator.special.cooldownScale = 0.75f;
                }

                // might
                if (self.HasBuff(Modules.Buffs.boonMight))
                {
                    self.damage *= 1 + 0.02f * self.GetBuffCount(Modules.Buffs.boonMight);
                }
            }
        }

        private void HealthComponent_TakeDamage(On.RoR2.HealthComponent.orig_TakeDamage orig, HealthComponent self, DamageInfo damageInfo)
        {
            if (self)
            {
                // aegis
                if (self.body.HasBuff(Modules.Buffs.boonAegis))
                {
                    if (damageInfo.damageType != DamageType.DoT && damageInfo.damageType != DamageType.VoidDeath)
                    {
                        EffectData effectData = new EffectData { origin = damageInfo.position, rotation = Util.QuaternionSafeLookRotation((damageInfo.force != Vector3.zero ? damageInfo.force : UnityEngine.Random.onUnitSphere)) };
                        EffectManager.SpawnEffect(LegacyResourcesAPI.Load<GameObject>("prefabs/effects/BearProc"), effectData, true);

                        damageInfo.rejected = true;

                        Modules.Buffs.HandleTimedBuff(Modules.Buffs.boonAegis, self.body, 1);
                    }
                }
            }

            if (damageInfo.attacker)
            {
                CharacterBody attackerBody = damageInfo.attacker.GetComponent<CharacterBody>();  
            }

            orig(self, damageInfo);
        }
    }
}