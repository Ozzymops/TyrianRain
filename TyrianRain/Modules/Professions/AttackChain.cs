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
        private SkillLocator skillLocator;
        private RoR2.Skills.SkillDef[] chainSkills;
        private bool canChain = true;
        private int currentSkill = 0;
        private float timer = 0.0f;

        public void Awake()
        {
            skillLocator = this.GetComponent<CharacterBody>().skillLocator;

            Professions.Warrior.WeaponReturn returnedWeapon = this.GetComponent<Warrior.WarriorWeaponSwap>().GetWeapon();
            SetChainSkills(returnedWeapon.skillDefs, returnedWeapon.chains);
        }

        private void Update()
        {
            // heresy check?

            // change primary based on chain state
            if (canChain)
            {
                if (skillLocator && chainSkills.Length != 0)
                {
                    if (skillLocator.primary.skillDef != chainSkills[currentSkill])
                    {
                        skillLocator.primary.UnsetSkillOverride(skillLocator.primary, skillLocator.primary.skillDef, GenericSkill.SkillOverridePriority.Default);
                        skillLocator.primary.SetSkillOverride(skillLocator.primary, chainSkills[currentSkill], GenericSkill.SkillOverridePriority.Default);
                    }
                }

                // chain reset timer
                if (currentSkill != 0)
                {
                    timer -= 1.0f * Time.deltaTime;

                    if (timer <= 0.0f)
                    {
                        ResetChain();
                    }
                }
            }  
            else
            {
                if (skillLocator.primary.skillDef != chainSkills[0])
                {
                    skillLocator.primary.UnsetSkillOverride(skillLocator.primary, skillLocator.primary.skillDef, GenericSkill.SkillOverridePriority.Default);
                    skillLocator.primary.SetSkillOverride(skillLocator.primary, chainSkills[0], GenericSkill.SkillOverridePriority.Default);
                }
            }
        }

        public void IncrementChain()
        {
            currentSkill++;
            timer = 3.0f;     
        }

        public void ResetChain()
        {
            currentSkill = 0;
            timer = 3.0f;
        }

        public void SetChainSkills(RoR2.Skills.SkillDef[] skillDefs, bool chain)
        {
            if (chain)
            {
                chainSkills = skillDefs;
                Debug.Log("Set primary chain skills to " + chainSkills[0].name + ", " + chainSkills[1].name + " & " + chainSkills[2].name);
            }
            else
            {
                chainSkills = new RoR2.Skills.SkillDef[] { skillDefs[0] };
                Debug.Log("Set primary skill to " + chainSkills[0].name);
            }

            ResetChain();
        }

        public int GetCurrentSkillCount()
        {
            return currentSkill;
        }
    }
}
