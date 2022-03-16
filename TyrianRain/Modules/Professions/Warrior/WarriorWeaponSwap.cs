using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using RoR2;

namespace TyrianRain.Modules.Professions.Warrior
{
    enum WarriorWeapons { Greatsword, Hammer, DualAxe, MaceShield, SwordTorch, DualDagger, Longbow, Rifle }

    public class WarriorWeaponSwap : MonoBehaviour
    {
        #region Skill definitions
        public static RoR2.Skills.SkillDef[] WarriorGreatsword = {
            Skills.CreatePrimarySkillDef(new EntityStates.SerializableEntityStateType(typeof(SkillStates.Warrior.GreatswordSwing)), "Weapon", Survivors.Warrior.warriorPrefix + "PRIMARY_GREATSWORD_SWING_NAME", Survivors.Warrior.warriorPrefix + "PRIMARY_GREATSWORD_SWING_DESCRIPTION", Modules.Assets.mainAssetBundle.LoadAsset<Sprite>("Icon_Attack_Greatsword_Swing"), true),
            Skills.CreatePrimarySkillDef(new EntityStates.SerializableEntityStateType(typeof(SkillStates.Warrior.GreatswordSlice)), "Weapon", Survivors.Warrior.warriorPrefix + "PRIMARY_GREATSWORD_SLICE_NAME", Survivors.Warrior.warriorPrefix + "PRIMARY_GREATSWORD_SLICE_DESCRIPTION", Modules.Assets.mainAssetBundle.LoadAsset<Sprite>("Icon_Attack_Greatsword_Slice"), true),
            Skills.CreatePrimarySkillDef(new EntityStates.SerializableEntityStateType(typeof(SkillStates.Warrior.GreatswordBrutalStrike)), "Weapon", Survivors.Warrior.warriorPrefix + "PRIMARY_GREATSWORD_BRUTALSTRIKE_NAME", Survivors.Warrior.warriorPrefix + "PRIMARY_GREATSWORD_BRUTALSTRIKE_DESCRIPTION", Modules.Assets.mainAssetBundle.LoadAsset<Sprite>("Icon_Attack_Greatsword_BrutalStrike"), true),
        };
        #endregion

        private CharacterBody warriorCharacterBody;

        private WarriorWeapons weaponLoadout;
        private int equippedWeapon = 0;
        private int adrenaline = 0;
        private int maxAdrenaline = 30;
        private int adrenalineThreshold = 10;

        private void Awake()
        {
            this.gameObject.GetComponent<WarriorAdrenaline>().OnAdrenalineUpdated += UpdateAdrenaline;
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

            // skill override code
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
            }
        }

        public void UpdateAdrenaline(int newAdrenaline, int newMaxAdrenaline, int newAdrenalineThreshold)
        {
            adrenaline = newAdrenaline;
            maxAdrenaline = newMaxAdrenaline;
            adrenalineThreshold = newAdrenalineThreshold;
        }
    }
}
