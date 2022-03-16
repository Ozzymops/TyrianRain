using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using RoR2;

namespace TyrianRain.Modules.Professions.Warrior
{
    public class WarriorAdrenaline : MonoBehaviour
    {
        private CharacterBody warriorCharacterBody;

        private int adrenaline = 0;
        private int maxAdrenaline = 30;
        private int adrenalineThreshold = 10;
        private float warriorDamageDealtCounter = 0;
        private float warriorDamageTakenCounter = 0;

        private void Awake()
        {
            DrainAdrenaline();
        }

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

                if (OnAdrenalineUpdated != null)
                {
                    OnAdrenalineUpdated(adrenaline, maxAdrenaline, adrenalineThreshold);
                }
            }
        }

        // reset adrenaline after burst
        public void DrainAdrenaline()
        {
            adrenaline = 0;

            if (OnAdrenalineUpdated != null)
            {
                OnAdrenalineUpdated(adrenaline, maxAdrenaline, adrenalineThreshold);
            }
        }

        // event stuff
        public delegate void OnAdrenalineUpdatedDelegate(int adrenaline, int maxAdrenaline, int adrenalineThreshold);
        public event OnAdrenalineUpdatedDelegate OnAdrenalineUpdated;
    }
}
