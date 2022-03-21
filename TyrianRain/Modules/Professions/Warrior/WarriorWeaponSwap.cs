using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using RoR2;
using R2API;

namespace TyrianRain.Modules.Professions.Warrior
{
    enum WarriorWeapons { Greatsword, Hammer, DualAxe, MaceShield, SwordTorch, DualDagger, Longbow, Rifle }

    public class WeaponReturn
    {
        public RoR2.Skills.SkillDef[] skillDefs { get; set; }
        public bool chains { get; set; }
    }

    public class WarriorWeaponSwap : MonoBehaviour
    {
        #region Skill definitions
        public static RoR2.Skills.SkillDef[] WarriorGreatsword = {
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

        private CharacterBody warriorCharacterBody;

        private WarriorWeapons[] weaponLoadout = new WarriorWeapons[3];
        private RoR2.Skills.SkillDef burstAttack;

        private int equippedWeapon = 0;
        private int adrenaline = 0;
        private int maxAdrenaline = 30;
        private int adrenalineThreshold = 10;

        private void Awake()
        {
            warriorCharacterBody = this.GetComponent<CharacterBody>();
            this.GetComponent<WarriorAdrenaline>().OnAdrenalineUpdated += UpdateAdrenaline;

            // testing
            weaponLoadout = new WarriorWeapons[] { WarriorWeapons.Greatsword, WarriorWeapons.Hammer, WarriorWeapons.Rifle };
        }

        private void Update()
        {
            // input
            if (Input.GetKeyDown(KeyCode.Alpha1)) // 1
            {
                if (equippedWeapon == 0)
                {
                    ExecuteBurst();
                }
                else
                {
                    SwapWeapon(0);
                }               
            }

            if (Input.GetKeyDown(KeyCode.Alpha2)) // 2
            {
                if (equippedWeapon == 1)
                {
                    ExecuteBurst();
                }
                else
                {
                    SwapWeapon(1);
                }
            }

            if (Input.GetKeyDown(KeyCode.Alpha3)) // 3
            {
                if (equippedWeapon == 2)
                {
                    ExecuteBurst();
                }
                else
                {
                    SwapWeapon(2);
                }
            }
        }

        // swap weapon index
        public void SwapWeapon(int weapon)
        {
            equippedWeapon = weapon;

            RoR2.SkillLocator skillLocator = warriorCharacterBody.skillLocator;

            switch (weaponLoadout[equippedWeapon])
            {
                case WarriorWeapons.Greatsword:
                    warriorCharacterBody.GetComponent<AttackChain>().SetChainSkills(WarriorGreatsword, true);
                    
                    skillLocator.secondary.UnsetSkillOverride(skillLocator.secondary, skillLocator.secondary.skillDef, GenericSkill.SkillOverridePriority.Default);
                    skillLocator.secondary.SetSkillOverride(skillLocator.secondary, WarriorGreatsword[3], GenericSkill.SkillOverridePriority.Default);
                    
                    skillLocator.utility.UnsetSkillOverride(skillLocator.utility, skillLocator.utility.skillDef, GenericSkill.SkillOverridePriority.Default);
                    skillLocator.utility.SetSkillOverride(skillLocator.utility, WarriorGreatsword[4], GenericSkill.SkillOverridePriority.Default);
                    
                    skillLocator.special.UnsetSkillOverride(skillLocator.special, skillLocator.special.skillDef, GenericSkill.SkillOverridePriority.Default);
                    skillLocator.special.SetSkillOverride(skillLocator.special, WarriorGreatsword[5], GenericSkill.SkillOverridePriority.Default);
                    
                    burstAttack = WarriorGreatsword[6];
                    break;

                case WarriorWeapons.Hammer:
                    warriorCharacterBody.GetComponent<AttackChain>().SetChainSkills(WarriorHammer, true);

                    skillLocator.secondary.UnsetSkillOverride(skillLocator.secondary, skillLocator.secondary.skillDef, GenericSkill.SkillOverridePriority.Default);
                    skillLocator.secondary.SetSkillOverride(skillLocator.secondary, WarriorHammer[3], GenericSkill.SkillOverridePriority.Default);

                    skillLocator.utility.UnsetSkillOverride(skillLocator.utility, skillLocator.utility.skillDef, GenericSkill.SkillOverridePriority.Default);
                    skillLocator.utility.SetSkillOverride(skillLocator.utility, WarriorHammer[4], GenericSkill.SkillOverridePriority.Default);

                    skillLocator.special.UnsetSkillOverride(skillLocator.special, skillLocator.special.skillDef, GenericSkill.SkillOverridePriority.Default);
                    skillLocator.special.SetSkillOverride(skillLocator.special, WarriorHammer[5], GenericSkill.SkillOverridePriority.Default);

                    burstAttack = WarriorHammer[6];
                    break;

                case WarriorWeapons.Rifle:
                    warriorCharacterBody.GetComponent<AttackChain>().SetChainSkills(WarriorRifle, false);

                    skillLocator.secondary.UnsetSkillOverride(skillLocator.secondary, skillLocator.secondary.skillDef, GenericSkill.SkillOverridePriority.Default);
                    skillLocator.secondary.SetSkillOverride(skillLocator.secondary, WarriorRifle[1], GenericSkill.SkillOverridePriority.Default);

                    skillLocator.utility.UnsetSkillOverride(skillLocator.utility, skillLocator.utility.skillDef, GenericSkill.SkillOverridePriority.Default);
                    skillLocator.utility.SetSkillOverride(skillLocator.utility, WarriorRifle[2], GenericSkill.SkillOverridePriority.Default);

                    skillLocator.special.UnsetSkillOverride(skillLocator.special, skillLocator.special.skillDef, GenericSkill.SkillOverridePriority.Default);
                    skillLocator.special.SetSkillOverride(skillLocator.special, WarriorRifle[3], GenericSkill.SkillOverridePriority.Default);

                    burstAttack = WarriorRifle[4];
                    break;

                default:
                    Debug.Log("Which is... shitty code");
                    break;
            }                     
        }

        // perform burst attack
        public void ExecuteBurst()
        {
            if (adrenaline >= adrenalineThreshold)
            {
                // get adrenaline level
                int adrenalineLevel = Mathf.FloorToInt(adrenaline % adrenalineThreshold);

                // execute skill code
                gameObject.GetComponent<Modules.Professions.Warrior.WarriorAdrenaline>().DrainAdrenaline();
                // do skilldef
            }
        }

        public void UpdateAdrenaline(int newAdrenaline, int newMaxAdrenaline, int newAdrenalineThreshold)
        {
            adrenaline = newAdrenaline;
            maxAdrenaline = newMaxAdrenaline;
            adrenalineThreshold = newAdrenalineThreshold;
        }

        public WeaponReturn GetWeapon()
        {
            switch (weaponLoadout[equippedWeapon])
            {
                case WarriorWeapons.Greatsword:
                    return new WeaponReturn() { skillDefs = WarriorGreatsword, chains = true };

                case WarriorWeapons.Hammer:
                    return new WeaponReturn() { skillDefs = WarriorHammer, chains = true };

                case WarriorWeapons.Rifle:
                    return new WeaponReturn() { skillDefs = WarriorRifle, chains = false };

                default:
                    return null;
            }
        }
    }
}
