using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using RoR2;

namespace TyrianRain.Modules.Professions.Warrior
{
    public class WarriorAdrenaline
    {
        private CharacterBody warriorCharacterBody;

        private int adrenaline = 0;
        private int maxAdrenaline = 30;
        private int adrenalineThreshold = 10;
        private float warriorDamageDealtCounter = 0;
        private float warriorDamageTakenCounter = 0;

        // 1000% of damage dealth = 1 adrenaline
        public void UpdateWarriorDamageDealtCounter(float damageDealt)
        {
            warriorDamageDealtCounter += damageDealt;

            if (warriorDamageDealtCounter > 1000)
            {
                warriorDamageDealtCounter -= 1000;
                UpdateAdrenaline(1);
            }
        }

        // 30% of max. HP damage taken = 1 adrenaline
        public void UpdateWarriorDamageTakenCounter(float damageTaken)
        {
            warriorDamageTakenCounter += damageTaken;

            if (warriorDamageTakenCounter > (warriorCharacterBody.maxHealth * 0.3f))
            {
                warriorDamageTakenCounter -= (warriorCharacterBody.maxHealth * 0.3f);
                UpdateAdrenaline(1);
            }
        }

        // adrenaline sanity check
        public void UpdateAdrenaline(int addedAdrenaline)
        {
            if (adrenaline < maxAdrenaline)
            {
                adrenaline += addedAdrenaline;
            }
        }

        // reset adrenaline after burst
        public void DrainAdrenaline()
        {
            adrenaline = 0;
        }

        // return adrenaline data
        public int[] GetAdrenalineData()
        {
            return new int[] { adrenaline, maxAdrenaline, adrenalineThreshold };
        }
    }
}
