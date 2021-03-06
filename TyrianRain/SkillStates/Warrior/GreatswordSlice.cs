using TyrianRain.SkillStates.BaseStates;
using RoR2;
using UnityEngine;
using UnityEngine.Networking;

namespace TyrianRain.SkillStates.Warrior
{
    public class GreatswordSlice : BaseMeleeAttack
    {
        public override void OnEnter()
        {
            this.hitboxName = "Forward";

            this.damageType = DamageType.Generic;
            this.damageCoefficient = Modules.StaticValues.greatswordSliceDamageCoefficient;
            this.procCoefficient = 1f;
            this.pushForce = 300f;
            this.bonusForce = Vector3.zero;
            this.baseDuration = 1f;
            this.attackStartTime = 0.2f;
            this.attackEndTime = 0.4f;
            this.baseEarlyExitTime = 0.4f;
            this.hitStopDuration = 0.012f;
            this.attackRecoil = 0.5f;
            this.hitHopVelocity = 4f;

            this.swingSoundString = "HenrySwordSwing";
            this.hitSoundString = "";
            this.muzzleString = "SwingRight";
            this.swingEffectPrefab = Modules.Assets.swordSwingEffect;
            this.hitEffectPrefab = Modules.Assets.swordHitImpactEffect;

            this.impactSound = Modules.Assets.swordHitSoundEvent.index;

            base.OnEnter();
        }

        protected override void PlayAttackAnimation()
        {
            base.PlayAttackAnimation();
        }

        protected override void PlaySwingEffect()
        {
            base.PlaySwingEffect();
        }

        protected override void SetNextState()
        {
            // redundant, but kinda necessary for auto-attack stuff
            switch (characterBody.GetComponent<Modules.Professions.AttackChain>().GetChain())
            {
                case 0:
                    this.outer.SetNextState(new GreatswordSwing());
                    break;

                case 1:
                    this.outer.SetNextState(new GreatswordSlice());
                    break;

                case 2:
                    this.outer.SetNextState(new GreatswordBrutalStrike());
                    break;
            }
        }

        protected override void OnHitEnemyAuthority()
        {
            base.OnHitEnemyAuthority();

            if (NetworkServer.active)
            {
                characterBody.GetComponent<Modules.Professions.AttackChain>().IncrementChain();
            }
        }

        public override void OnExit()
        {
            base.OnExit();
        }
    }
}