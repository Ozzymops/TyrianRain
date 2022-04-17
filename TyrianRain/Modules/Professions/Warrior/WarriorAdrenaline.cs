using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using RoR2;

namespace TyrianRain.Modules.Professions.Warrior
{
    public class WarriorAdrenaline : MonoBehaviour
    {
        private enum WarriorEliteSpecialisation { Core, Berserker, Spellbreaker, Bladesworn };
        private WarriorEliteSpecialisation eliteSpecialisation = WarriorEliteSpecialisation.Core;

        private RoR2.Skills.SkillDef _burstAttack;

        private int adrenaline;
        private int maximumAdrenaline;
        private int adrenalineThreshold;

        private void OnEnable()
        {
            WarriorWeaponSwap.OnBurstAttackChange += ChangeBurstAttack;
        }

        private void OnDisable()
        {
            WarriorWeaponSwap.OnBurstAttackChange -= ChangeBurstAttack;
        }

        private void Awake()
        {
            // get elite specialisation from passive
            SetupAdrenaline(30, 10);
            SetAdrenaline(-999);
        }

        private void Update()
        {
            Controls();
        }

        /// <summary>
        /// Handles input
        /// </summary>
        private void Controls()
        {
            if (Input.GetKeyDown(KeyCode.E)) // or F, idk
            {
                // burst attack
            }
        }

        /// <summary>
        /// Set maximum and threshold values
        /// </summary>
        /// <param name="maximumValue">Maximum adrenaline value</param>
        /// <param name="thresholdValue">Threshold value for adrenaline levels</param>
        private void SetupAdrenaline(int maximumValue, int thresholdValue)
        {
            maximumAdrenaline = maximumValue;
            adrenalineThreshold = thresholdValue;

            OnAdrenalineSetup?.Invoke(maximumAdrenaline, adrenalineThreshold);
        }

        /// <summary>
        /// Set value to add or subtract from adrenaline
        /// </summary>
        /// <param name="value">Value to add or subtract</param>
        public void SetAdrenaline(int value)
        {
            if (adrenaline + value > maximumAdrenaline)
            {
                adrenaline = maximumAdrenaline;
            }
            else if (adrenaline - value < 0)
            {
                adrenaline = 0;
            }
            else
            {
                adrenaline += value;
            }

            OnAdrenalineChanged?.Invoke(adrenaline);
        }

        /// <summary>
        /// Change current Burst Attack to selected weapon's Burst Attack
        /// </summary>
        /// <param name="skillDef">Burst Attack</param>
        private void ChangeBurstAttack(RoR2.Skills.SkillDef skillDef)
        {
            _burstAttack = skillDef;
        }

        // Events
        public static event Action<int, int> OnAdrenalineSetup;
        public static event Action<int> OnAdrenalineChanged;
    }
}
