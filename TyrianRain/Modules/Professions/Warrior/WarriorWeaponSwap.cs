using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using RoR2;
using R2API;

namespace TyrianRain.Modules.Professions.Warrior
{
    public class WarriorWeaponSwap : MonoBehaviour
    {
        private enum WarriorWeapons { Greatsword, Hammer, Rifle, Longbow, DualAxe, DualDagger, MaceShield, SwordTorch };
        private WarriorWeapons[] equippedWeapons = { WarriorWeapons.Greatsword, WarriorWeapons.Hammer, WarriorWeapons.Rifle };

        #region SkillDefs
        // Greatsword
        public static RoR2.Skills.SkillDef[] WarriorGreatsword =
        {
            // primary
            Skills.CreatePrimarySkillDef(new EntityStates.SerializableEntityStateType(typeof(SkillStates.Warrior.GreatswordSwing)), "Weapon", Survivors.Warrior.warriorPrefix + "PRIMARY_GREATSWORD_SWING_NAME", Survivors.Warrior.warriorPrefix + "PRIMARY_GREATSWORD_SWING_DESCRIPTION", Modules.Assets.mainAssetBundle.LoadAsset<Sprite>("Icon_Attack_Greatsword_Swing"), true),
            Skills.CreatePrimarySkillDef(new EntityStates.SerializableEntityStateType(typeof(SkillStates.Warrior.GreatswordSlice)), "Weapon", Survivors.Warrior.warriorPrefix + "PRIMARY_GREATSWORD_SLICE_NAME", Survivors.Warrior.warriorPrefix + "PRIMARY_GREATSWORD_SLICE_DESCRIPTION", Modules.Assets.mainAssetBundle.LoadAsset<Sprite>("Icon_Attack_Greatsword_Slice"), true),
            Skills.CreatePrimarySkillDef(new EntityStates.SerializableEntityStateType(typeof(SkillStates.Warrior.GreatswordBrutalStrike)), "Weapon", Survivors.Warrior.warriorPrefix + "PRIMARY_GREATSWORD_BRUTALSTRIKE_NAME", Survivors.Warrior.warriorPrefix + "PRIMARY_GREATSWORD_BRUTALSTRIKE_DESCRIPTION", Modules.Assets.mainAssetBundle.LoadAsset<Sprite>("Icon_Attack_Greatsword_BrutalStrike"), true),
            // secondary
            Skills.CreateSkillDef((new SkillDefInfo
            {
                skillName = Survivors.Warrior.warriorPrefix + "SECONDARY_GREATSWORD_BLADETRAIL_NAME",
                skillNameToken = Survivors.Warrior.warriorPrefix + "SECONDARY_GREATSWORD_BLADETRAIL_NAME",
                skillDescriptionToken = Survivors.Warrior.warriorPrefix + "SECONDARY_GREATSWORD_BLADETRAIL_DESCRIPTION",
                skillIcon = Modules.Assets.mainAssetBundle.LoadAsset<Sprite>("Icon_Attack_Greatsword_Bladetrail"),
                activationState = new EntityStates.SerializableEntityStateType(typeof(SkillStates.Warrior.GreatswordBladetrail)),
                activationStateMachineName = "Slide",
                baseMaxStock = 1,
                baseRechargeInterval = 3f,
                beginSkillCooldownOnSkillEnd = false,
                canceledFromSprinting = false,
                forceSprintDuringState = false,
                fullRestockOnAssign = true,
                interruptPriority = EntityStates.InterruptPriority.Skill,
                resetCooldownTimerOnUse = false,
                isCombatSkill = true,
                mustKeyPress = false,
                cancelSprintingOnActivation = true,
                rechargeStock = 1,
                requiredStock = 1,
                stockToConsume = 1,
                keywordTokens = null
            })),
            // utility
            Skills.CreateSkillDef((new SkillDefInfo
            {
                skillName = Survivors.Warrior.warriorPrefix + "UTILITY_GREATSWORD_WHIRLWINDATTACK_NAME",
                skillNameToken = Survivors.Warrior.warriorPrefix + "UTILITY_GREATSWORD_WHIRLWINDATTACK_NAME",
                skillDescriptionToken = Survivors.Warrior.warriorPrefix + "UTILITY_GREATSWORD_WHIRLWINDATTACK_DESCRIPTION",
                skillIcon = Modules.Assets.mainAssetBundle.LoadAsset<Sprite>("Icon_Attack_Greatsword_WhirlwindAttack"),
                activationState = new EntityStates.SerializableEntityStateType(typeof(SkillStates.Warrior.GreatswordWhirlwindAttack)),
                activationStateMachineName = "Body",
                baseMaxStock = 1,
                baseRechargeInterval = 6f,
                beginSkillCooldownOnSkillEnd = false,
                canceledFromSprinting = false,
                forceSprintDuringState = true,
                fullRestockOnAssign = true,
                interruptPriority = EntityStates.InterruptPriority.PrioritySkill,
                resetCooldownTimerOnUse = false,
                isCombatSkill = false,
                mustKeyPress = false,
                cancelSprintingOnActivation = false,
                rechargeStock = 1,
                requiredStock = 1,
                stockToConsume = 1
            })),
            // special
            Skills.CreateSkillDef((new SkillDefInfo
            {
                skillName = Survivors.Warrior.warriorPrefix + "SPECIAL_GREATSWORD_HUNDREDBLADES_NAME",
                skillNameToken = Survivors.Warrior.warriorPrefix + "SPECIAL_GREATSWORD_HUNDREDBLADES_NAME",
                skillDescriptionToken = Survivors.Warrior.warriorPrefix + "SPECIAL_GREATSWORD_HUNDREDBLADES_DESCRIPTION",
                skillIcon = Modules.Assets.mainAssetBundle.LoadAsset<Sprite>("Icon_Attack_Greatsword_HundredBlades"),
                activationState = new EntityStates.SerializableEntityStateType(typeof(SkillStates.Warrior.GreatswordHundredBlades)),
                activationStateMachineName = "Slide",
                baseMaxStock = 1,
                baseRechargeInterval = 10f,
                beginSkillCooldownOnSkillEnd = false,
                canceledFromSprinting = false,
                forceSprintDuringState = false,
                fullRestockOnAssign = true,
                interruptPriority = EntityStates.InterruptPriority.Skill,
                resetCooldownTimerOnUse = false,
                isCombatSkill = true,
                mustKeyPress = false,
                cancelSprintingOnActivation = true,
                rechargeStock = 1,
                requiredStock = 1,
                stockToConsume = 1
            })),
            // burst
            Skills.CreateSkillDef((new SkillDefInfo
            {
                skillName = Survivors.Warrior.warriorPrefix + "BURST_GREATSWORD_ARCINGSLICE_NAME",
                skillNameToken = Survivors.Warrior.warriorPrefix + "BURST_GREATSWORD_ARCINGSLICE_NAME",
                skillDescriptionToken = Survivors.Warrior.warriorPrefix + "BURST_GREATSWORD_ARCINGSLICE_DESCRIPTION",
                skillIcon = Modules.Assets.mainAssetBundle.LoadAsset<Sprite>("Icon_Attack_Greatsword_ArcingSlice"),
                activationState = new EntityStates.SerializableEntityStateType(typeof(SkillStates.Warrior.GreatswordArcingSlice)),
                activationStateMachineName = "Slide",
                baseMaxStock = 1,
                baseRechargeInterval = 10f,
                beginSkillCooldownOnSkillEnd = false,
                canceledFromSprinting = false,
                forceSprintDuringState = false,
                fullRestockOnAssign = true,
                interruptPriority = EntityStates.InterruptPriority.Skill,
                resetCooldownTimerOnUse = false,
                isCombatSkill = true,
                mustKeyPress = false,
                cancelSprintingOnActivation = true,
                rechargeStock = 1,
                requiredStock = 1,
                stockToConsume = 1
            }))
        };

        // Hammer
        public static RoR2.Skills.SkillDef[] WarriorHammer = {
            // primary
            Skills.CreatePrimarySkillDef(new EntityStates.SerializableEntityStateType(typeof(SkillStates.Warrior.HammerSwing)), "Weapon", Survivors.Warrior.warriorPrefix + "PRIMARY_HAMMER_SWING_NAME", Survivors.Warrior.warriorPrefix + "PRIMARY_HAMMER_SWING_DESCRIPTION", Modules.Assets.mainAssetBundle.LoadAsset<Sprite>("Icon_Attack_Hammer_Swing"), true),
            Skills.CreatePrimarySkillDef(new EntityStates.SerializableEntityStateType(typeof(SkillStates.Warrior.HammerBash)), "Weapon", Survivors.Warrior.warriorPrefix + "PRIMARY_HAMMER_BASH_NAME", Survivors.Warrior.warriorPrefix + "PRIMARY_HAMMER_BASH_DESCRIPTION", Modules.Assets.mainAssetBundle.LoadAsset<Sprite>("Icon_Attack_Hammer_Bash"), true),
            Skills.CreatePrimarySkillDef(new EntityStates.SerializableEntityStateType(typeof(SkillStates.Warrior.HammerSmash)), "Weapon", Survivors.Warrior.warriorPrefix + "PRIMARY_HAMMER_SMASH_NAME", Survivors.Warrior.warriorPrefix + "PRIMARY_HAMMER_SMASH_DESCRIPTION", Modules.Assets.mainAssetBundle.LoadAsset<Sprite>("Icon_Attack_Hammer_Smash"), true),
            // secondary
            Skills.CreateSkillDef((new SkillDefInfo
            {
                skillName = Survivors.Warrior.warriorPrefix + "SECONDARY_HAMMER_FIERCEBLOW_NAME",
                skillNameToken = Survivors.Warrior.warriorPrefix + "SECONDARY_HAMMER_FIERCEBLOW_NAME",
                skillDescriptionToken = Survivors.Warrior.warriorPrefix + "SECONDARY_HAMMER_FIERCEBLOW_DESCRIPTION",
                skillIcon = Modules.Assets.mainAssetBundle.LoadAsset<Sprite>("Icon_Attack_Hammer_FierceBlow"),
                activationState = new EntityStates.SerializableEntityStateType(typeof(SkillStates.Warrior.HammerFierceBlow)),
                activationStateMachineName = "Slide",
                baseMaxStock = 1,
                baseRechargeInterval = 4f,
                beginSkillCooldownOnSkillEnd = false,
                canceledFromSprinting = false,
                forceSprintDuringState = false,
                fullRestockOnAssign = true,
                interruptPriority = EntityStates.InterruptPriority.Skill,
                resetCooldownTimerOnUse = false,
                isCombatSkill = true,
                mustKeyPress = false,
                cancelSprintingOnActivation = true,
                rechargeStock = 1,
                requiredStock = 1,
                stockToConsume = 1,
                keywordTokens = null
            })),
            // utility
            Skills.CreateSkillDef((new SkillDefInfo
            {
                skillName = Survivors.Warrior.warriorPrefix + "UTILITY_HAMMER_STAGGERINGBLOW_NAME",
                skillNameToken = Survivors.Warrior.warriorPrefix + "UTILITY_HAMMER_STAGGERINGBLOW_NAME",
                skillDescriptionToken = Survivors.Warrior.warriorPrefix + "UTILITY_HAMMER_STAGGERINGBLOW_DESCRIPTION",
                skillIcon = Modules.Assets.mainAssetBundle.LoadAsset<Sprite>("Icon_Attack_Hammer_StaggeringBlow"),
                activationState = new EntityStates.SerializableEntityStateType(typeof(SkillStates.Warrior.HammerStaggeringBlow)),
                activationStateMachineName = "Body",
                baseMaxStock = 1,
                baseRechargeInterval = 6f,
                beginSkillCooldownOnSkillEnd = false,
                canceledFromSprinting = false,
                forceSprintDuringState = true,
                fullRestockOnAssign = true,
                interruptPriority = EntityStates.InterruptPriority.PrioritySkill,
                resetCooldownTimerOnUse = false,
                isCombatSkill = false,
                mustKeyPress = false,
                cancelSprintingOnActivation = false,
                rechargeStock = 1,
                requiredStock = 1,
                stockToConsume = 1
            })),
            // special
            Skills.CreateSkillDef((new SkillDefInfo
            {
                skillName = Survivors.Warrior.warriorPrefix + "SPECIAL_HAMMER_BACKBREAKER_NAME",
                skillNameToken = Survivors.Warrior.warriorPrefix + "SPECIAL_HAMMER_BACKBREAKER_NAME",
                skillDescriptionToken = Survivors.Warrior.warriorPrefix + "SPECIAL_HAMMER_BACKBREAKER_DESCRIPTION",
                skillIcon = Modules.Assets.mainAssetBundle.LoadAsset<Sprite>("Icon_Attack_Hammer_Backbreaker"),
                activationState = new EntityStates.SerializableEntityStateType(typeof(SkillStates.Warrior.HammerBackbreaker)),
                activationStateMachineName = "Slide",
                baseMaxStock = 1,
                baseRechargeInterval = 10f,
                beginSkillCooldownOnSkillEnd = false,
                canceledFromSprinting = false,
                forceSprintDuringState = false,
                fullRestockOnAssign = true,
                interruptPriority = EntityStates.InterruptPriority.Skill,
                resetCooldownTimerOnUse = false,
                isCombatSkill = true,
                mustKeyPress = false,
                cancelSprintingOnActivation = true,
                rechargeStock = 1,
                requiredStock = 1,
                stockToConsume = 1
            })),
            // burst
            Skills.CreateSkillDef((new SkillDefInfo
            {
                skillName = Survivors.Warrior.warriorPrefix + "BURST_HAMMER_EARTHSHAKER_NAME",
                skillNameToken = Survivors.Warrior.warriorPrefix + "BURST_HAMMER_EARTHSHAKER_NAME",
                skillDescriptionToken = Survivors.Warrior.warriorPrefix + "BURST_HAMMER_EARTHSHAKER_DESCRIPTION",
                skillIcon = Modules.Assets.mainAssetBundle.LoadAsset<Sprite>("Icon_Attack_Hammer_Earthshaker"),
                activationState = new EntityStates.SerializableEntityStateType(typeof(SkillStates.Warrior.HammerEarthshaker)),
                activationStateMachineName = "Slide",
                baseMaxStock = 1,
                baseRechargeInterval = 10f,
                beginSkillCooldownOnSkillEnd = false,
                canceledFromSprinting = false,
                forceSprintDuringState = false,
                fullRestockOnAssign = true,
                interruptPriority = EntityStates.InterruptPriority.Skill,
                resetCooldownTimerOnUse = false,
                isCombatSkill = true,
                mustKeyPress = false,
                cancelSprintingOnActivation = true,
                rechargeStock = 1,
                requiredStock = 1,
                stockToConsume = 1
            }))
        };

        // Rifle
        public static RoR2.Skills.SkillDef[] WarriorRifle = {
            // primary
            Skills.CreatePrimarySkillDef(new EntityStates.SerializableEntityStateType(typeof(SkillStates.Warrior.RifleFierceShot)), "Weapon", Survivors.Warrior.warriorPrefix + "PRIMARY_RIFLE_FIERCESHOT_NAME", Survivors.Warrior.warriorPrefix + "PRIMARY_RIFLE_FIERCESHOT_DESCRIPTION", Modules.Assets.mainAssetBundle.LoadAsset<Sprite>("Icon_Attack_Rifle_FierceShot"), true),
            // secondary
            Skills.CreateSkillDef((new SkillDefInfo
            {
                skillName = Survivors.Warrior.warriorPrefix + "SECONDARY_RIFLE_VOLLEY_NAME",
                skillNameToken = Survivors.Warrior.warriorPrefix + "SECONDARY_RIFLE_VOLLEY_NAME",
                skillDescriptionToken = Survivors.Warrior.warriorPrefix + "SECONDARY_RIFLE_VOLLEY_DESCRIPTION",
                skillIcon = Modules.Assets.mainAssetBundle.LoadAsset<Sprite>("Icon_Attack_Rifle_Volley"),
                activationState = new EntityStates.SerializableEntityStateType(typeof(SkillStates.Warrior.RifleVolley)),
                activationStateMachineName = "Slide",
                baseMaxStock = 1,
                baseRechargeInterval = 5f,
                beginSkillCooldownOnSkillEnd = false,
                canceledFromSprinting = false,
                forceSprintDuringState = false,
                fullRestockOnAssign = true,
                interruptPriority = EntityStates.InterruptPriority.Skill,
                resetCooldownTimerOnUse = false,
                isCombatSkill = true,
                mustKeyPress = false,
                cancelSprintingOnActivation = true,
                rechargeStock = 1,
                requiredStock = 1,
                stockToConsume = 1,
                keywordTokens = null
            })),
            // utility
            Skills.CreateSkillDef((new SkillDefInfo
            {
                skillName = Survivors.Warrior.warriorPrefix + "UTILITY_RIFLE_BRUTALSHOT_NAME",
                skillNameToken = Survivors.Warrior.warriorPrefix + "UTILITY_RIFLE_BRUTALSHOT_NAME",
                skillDescriptionToken = Survivors.Warrior.warriorPrefix + "UTILITY_RIFLE_BRUTALSHOT_DESCRIPTION",
                skillIcon = Modules.Assets.mainAssetBundle.LoadAsset<Sprite>("Icon_Attack_Rifle_BrutalShot"),
                activationState = new EntityStates.SerializableEntityStateType(typeof(SkillStates.Warrior.RifleBrutalShot)),
                activationStateMachineName = "Body",
                baseMaxStock = 2,
                baseRechargeInterval = 6f,
                beginSkillCooldownOnSkillEnd = false,
                canceledFromSprinting = false,
                forceSprintDuringState = true,
                fullRestockOnAssign = true,
                interruptPriority = EntityStates.InterruptPriority.PrioritySkill,
                resetCooldownTimerOnUse = false,
                isCombatSkill = false,
                mustKeyPress = false,
                cancelSprintingOnActivation = false,
                rechargeStock = 1,
                requiredStock = 1,
                stockToConsume = 1
            })),
            // special
            Skills.CreateSkillDef((new SkillDefInfo
            {
                skillName = Survivors.Warrior.warriorPrefix + "SPECIAL_RIFLE_EXPLOSIVESHELL_NAME",
                skillNameToken = Survivors.Warrior.warriorPrefix + "SPECIAL_RIFLE_EXPLOSIVESHELL_NAME",
                skillDescriptionToken = Survivors.Warrior.warriorPrefix + "SPECIAL_RIFLE_EXPLOSIVESHELL_DESCRIPTION",
                skillIcon = Modules.Assets.mainAssetBundle.LoadAsset<Sprite>("Icon_Attack_Rifle_ExplosiveShell"),
                activationState = new EntityStates.SerializableEntityStateType(typeof(SkillStates.Warrior.RifleExplosiveShell)),
                activationStateMachineName = "Slide",
                baseMaxStock = 1,
                baseRechargeInterval = 8f,
                beginSkillCooldownOnSkillEnd = false,
                canceledFromSprinting = false,
                forceSprintDuringState = false,
                fullRestockOnAssign = true,
                interruptPriority = EntityStates.InterruptPriority.Skill,
                resetCooldownTimerOnUse = false,
                isCombatSkill = true,
                mustKeyPress = false,
                cancelSprintingOnActivation = true,
                rechargeStock = 1,
                requiredStock = 1,
                stockToConsume = 1
            })),
            // burst
            Skills.CreateSkillDef((new SkillDefInfo
            {
                skillName = Survivors.Warrior.warriorPrefix + "BURST_RIFLE_KILLSHOT_NAME",
                skillNameToken = Survivors.Warrior.warriorPrefix + "BURST_RIFLE_KILLSHOT_NAME",
                skillDescriptionToken = Survivors.Warrior.warriorPrefix + "BURST_RIFLE_KILLSHOT_DESCRIPTION",
                skillIcon = Modules.Assets.mainAssetBundle.LoadAsset<Sprite>("Icon_Attack_Rifle_KillShot"),
                activationState = new EntityStates.SerializableEntityStateType(typeof(SkillStates.Warrior.RifleKillShot)),
                activationStateMachineName = "Slide",
                baseMaxStock = 1,
                baseRechargeInterval = 10f,
                beginSkillCooldownOnSkillEnd = false,
                canceledFromSprinting = false,
                forceSprintDuringState = false,
                fullRestockOnAssign = true,
                interruptPriority = EntityStates.InterruptPriority.Skill,
                resetCooldownTimerOnUse = false,
                isCombatSkill = true,
                mustKeyPress = false,
                cancelSprintingOnActivation = true,
                rechargeStock = 1,
                requiredStock = 1,
                stockToConsume = 1
            }))
        };
        #endregion

        private int currentWeaponIndex = 0;

        private float weaponSwapCooldown = 5.0f; // will eventually be 10.0f, changed by trait
        private float weaponSwapCooldownTimer;
        
        private void Update()
        {
            Controls();

            if (weaponSwapCooldown > 0.0f)
            {
                weaponSwapCooldownTimer -= 1.0f * Time.deltaTime;
            }
        }

        /// <summary>
        /// Handles input
        /// </summary>
        private void Controls()
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                WeaponSwap(0);
            }

            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                WeaponSwap(1);
            }

            if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                WeaponSwap(2);
            }
        }

        /// <summary>
        /// Swap weapon loadout to selected weapon
        /// </summary>
        /// <param name="index">Selected weapon index</param>
        private void WeaponSwap(int index)
        {
            if (weaponSwapCooldownTimer > 0.0f) return;
            if (currentWeaponIndex == index) return;

            currentWeaponIndex = index;

            // swap skills
            RoR2.SkillLocator skillLocator = GetComponent<CharacterBody>().skillLocator;

            switch (equippedWeapons[currentWeaponIndex])
            {
                case WarriorWeapons.Greatsword:
                    OnLoadoutChange?.Invoke(WarriorGreatsword, true);

                    skillLocator.secondary.UnsetSkillOverride(skillLocator.secondary, skillLocator.secondary.skillDef, GenericSkill.SkillOverridePriority.Default);
                    skillLocator.secondary.SetSkillOverride(skillLocator.secondary, WarriorGreatsword[3], GenericSkill.SkillOverridePriority.Default);

                    skillLocator.utility.UnsetSkillOverride(skillLocator.utility, skillLocator.utility.skillDef, GenericSkill.SkillOverridePriority.Default);
                    skillLocator.utility.SetSkillOverride(skillLocator.utility, WarriorGreatsword[4], GenericSkill.SkillOverridePriority.Default);

                    skillLocator.special.UnsetSkillOverride(skillLocator.special, skillLocator.special.skillDef, GenericSkill.SkillOverridePriority.Default);
                    skillLocator.special.SetSkillOverride(skillLocator.special, WarriorGreatsword[5], GenericSkill.SkillOverridePriority.Default);

                    OnBurstAttackChange?.Invoke(WarriorGreatsword[6]);
                    break;

                case WarriorWeapons.Hammer:
                    OnLoadoutChange?.Invoke(WarriorHammer, true);

                    skillLocator.secondary.UnsetSkillOverride(skillLocator.secondary, skillLocator.secondary.skillDef, GenericSkill.SkillOverridePriority.Default);
                    skillLocator.secondary.SetSkillOverride(skillLocator.secondary, WarriorHammer[3], GenericSkill.SkillOverridePriority.Default);

                    skillLocator.utility.UnsetSkillOverride(skillLocator.utility, skillLocator.utility.skillDef, GenericSkill.SkillOverridePriority.Default);
                    skillLocator.utility.SetSkillOverride(skillLocator.utility, WarriorHammer[4], GenericSkill.SkillOverridePriority.Default);

                    skillLocator.special.UnsetSkillOverride(skillLocator.special, skillLocator.special.skillDef, GenericSkill.SkillOverridePriority.Default);
                    skillLocator.special.SetSkillOverride(skillLocator.special, WarriorHammer[5], GenericSkill.SkillOverridePriority.Default);

                    OnBurstAttackChange?.Invoke(WarriorHammer[6]);
                    break;

                case WarriorWeapons.Rifle:
                    OnLoadoutChange?.Invoke(WarriorRifle, false);

                    skillLocator.secondary.UnsetSkillOverride(skillLocator.secondary, skillLocator.secondary.skillDef, GenericSkill.SkillOverridePriority.Default);
                    skillLocator.secondary.SetSkillOverride(skillLocator.secondary, WarriorRifle[1], GenericSkill.SkillOverridePriority.Default);

                    skillLocator.utility.UnsetSkillOverride(skillLocator.utility, skillLocator.utility.skillDef, GenericSkill.SkillOverridePriority.Default);
                    skillLocator.utility.SetSkillOverride(skillLocator.utility, WarriorRifle[2], GenericSkill.SkillOverridePriority.Default);

                    skillLocator.special.UnsetSkillOverride(skillLocator.special, skillLocator.special.skillDef, GenericSkill.SkillOverridePriority.Default);
                    skillLocator.special.SetSkillOverride(skillLocator.special, WarriorRifle[3], GenericSkill.SkillOverridePriority.Default);

                    OnBurstAttackChange?.Invoke(WarriorRifle[4]);
                    break;

                default:
                    break;
            }

            // cooldown timer
            weaponSwapCooldownTimer = weaponSwapCooldown;
            OnWeaponSwap?.Invoke(currentWeaponIndex, weaponSwapCooldown);
        }

        // Events
        public static event Action<int, float> OnWeaponSwap;
        public static event Action<RoR2.Skills.SkillDef[], bool> OnLoadoutChange;
        public static event Action<RoR2.Skills.SkillDef> OnBurstAttackChange;
    }
}
