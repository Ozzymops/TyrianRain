using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using RoR2;

namespace TyrianRain.Modules.Professions.Warrior
{
    enum WarriorWeapons { Greatsword, Hammer, DualAxe, MaceShield, SwordTorch, DualDagger, Longbow, Rifle }

    public class WarriorWeaponSwap
    {
        private CharacterBody warriorCharacterBody;
        private WarriorAdrenaline adrenalineScript;

        private WarriorWeapons weaponLoadout;
        private int equippedWeapon = 0;

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
            int[] adrenalineData = adrenalineScript.GetAdrenalineData();

            if (adrenalineData[0] >= adrenalineData[2])
            {
                // get adrenaline level
                int adrenalineLevel = Mathf.FloorToInt(adrenalineData[0] % adrenalineData[2]);
                
                // execute skill code
            }
        }
    }
}
