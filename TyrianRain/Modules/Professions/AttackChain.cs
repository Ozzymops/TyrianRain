using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using RoR2;
using R2API;

namespace TyrianRain.Modules.Professions
{
    public class AttackChain : MonoBehaviour
    {
        private RoR2.Skills.SkillDef[] chainSkills;

        private int skillIndex = 0;
        private bool weaponSwap = false;
        private bool loadoutCanChain;
        private float resetTimer = 0.0f;

        private void Awake()
        {
            // Warrior Weapon Swap check
            if (GetComponent<Professions.Warrior.WarriorWeaponSwap>())
            {
                weaponSwap = true;
            }
        }

        private void OnEnable()
        {
            if (weaponSwap)
            {
                Professions.Warrior.WarriorWeaponSwap.OnLoadoutChange += SetChainSkills;
            }          
        }

        private void OnDisable()
        {
            if (weaponSwap)
            {
                Professions.Warrior.WarriorWeaponSwap.OnLoadoutChange -= SetChainSkills;
            }
        }

        private void Update()
        {
            if (resetTimer > 0.0f)
            {
                resetTimer -= 1.0f * Time.deltaTime;

                if (resetTimer < 0.0f)
                {
                    SetChain(-999);
                }
            }
        }

        /// <summary>
        /// Add 1 to chain progression
        /// </summary>
        public void IncrementChain()
        {
            SetChain(1);
        }

        /// <summary>
        /// Set value to add or subtract from chain progression
        /// </summary>
        /// <param name="value">Chain progression</param>
        private void SetChain(int value)
        {
            if (skillIndex + value > 2)
            {
                skillIndex = 0;
                resetTimer = 0.0f;
            }
            else if (skillIndex - value < 0)
            {
                skillIndex = 0;
                resetTimer = 0.0f;
            }
            else
            {
                skillIndex += value;
                resetTimer = 3.0f;
            }
        }

        /// <summary>
        /// Change primary skill loadout
        /// </summary>
        /// <param name="skillDefs">New loadout</param>
        /// <param name="chain">Can this loadout chain?</param>
        public void SetChainSkills(RoR2.Skills.SkillDef[] skillDefs, bool chain)
        {
            SetChain(-999);

            loadoutCanChain = chain;

            if (!loadoutCanChain)
            {
                chainSkills = new RoR2.Skills.SkillDef[] { skillDefs[0] };
                return;
            }

            chainSkills = skillDefs;       
        }

        /// <summary>
        /// Change primary skill based on chain progression
        /// </summary>
        private void UpdatePrimarySkill()
        {
            SkillLocator skillLocator = GetComponent<CharacterBody>().skillLocator;

            if (!loadoutCanChain)
            {
                if (skillLocator.primary.skillDef != chainSkills[0])
                {
                    skillLocator.primary.UnsetSkillOverride(skillLocator.primary, skillLocator.primary.skillDef, GenericSkill.SkillOverridePriority.Default);
                    skillLocator.primary.SetSkillOverride(skillLocator.primary, chainSkills[0], GenericSkill.SkillOverridePriority.Default);
                }

                return;
            }

            if (skillLocator.primary.skillDef != chainSkills[skillIndex])
            {
                skillLocator.primary.UnsetSkillOverride(skillLocator.primary, skillLocator.primary.skillDef, GenericSkill.SkillOverridePriority.Default);
                skillLocator.primary.SetSkillOverride(skillLocator.primary, chainSkills[skillIndex], GenericSkill.SkillOverridePriority.Default);
            }
        }

        /// <summary>
        /// Return chain progression
        /// </summary>
        /// <returns>Chain progression as int</returns>
        public int GetChain()
        {
            return skillIndex;
        }
    }
}
