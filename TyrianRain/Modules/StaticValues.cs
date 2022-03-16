using System;

namespace TyrianRain.Modules
{
    internal static class StaticValues
    {
        internal static string descriptionText = "Henry is a skilled fighter who makes use of a wide arsenal of weaponry to take down his foes.<color=#CCD3E0>" + Environment.NewLine + Environment.NewLine
             + "< ! > Sword is a good all-rounder while Boxing Gloves are better for laying a beatdown on more powerful foes." + Environment.NewLine + Environment.NewLine
             + "< ! > Pistol is a powerful anti air, with its low cooldown and high damage." + Environment.NewLine + Environment.NewLine
             + "< ! > Roll has a lingering armor buff that helps to use it aggressively." + Environment.NewLine + Environment.NewLine
             + "< ! > Bomb can be used to wipe crowds with ease." + Environment.NewLine + Environment.NewLine;

        internal const float swordDamageCoefficient = 2.8f;

        internal const float gunDamageCoefficient = 4.2f;

        internal const float bombDamageCoefficient = 16f;

        #region Warrior
        internal const float greatswordSwingDamageCoefficient = 1.5f;
        internal const float greatswordSliceDamageCoefficient = 2.0f;
        internal const float greatswordBrutalStrikeDamageCoefficient = 3.0f;
        internal const float greatswordBladetrailDamageCoefficient = 2.5f;
        internal const float greatswordWhirlwindAttackDamageCoefficient = 2.0f;
        internal const float greatswordHundredBladesDamageCoefficient = 1.5f;
        internal const float greatswordHundredBladesFinishDamageCoefficient = 5.0f;
        internal const float greatswordArcingSliceDamageCoefficient = 12.5f;

        internal const float hammerSwingDamageCoefficient = 1.0f;
        internal const float hammerBashDamageCoefficient = 1.5f;
        internal const float hammerSmashDamageCoefficient = 2.5f;
        internal const float hammerFierceBlowDamageCoefficient = 3.0f;
        internal const float hammerFierceBlowMultiplier = 1.0f;
        internal const float hammerStaggeringBlowDamageCoefficient = 3.0f;
        internal const float hammerBackbreakerDamageCoefficient = 4.0f;
        internal const float hammerEarthshakerDamageCoefficient = 7.0f;

        internal const float rifleFierceShotDamageCoefficient = 2.5f;
        internal const float rifleVolleyDamageCoefficient = 2.5f;
        internal const float rifleBrutalShotDamageCoefficient = 3.0f;
        internal const float rifleExplosiveShellDamageCoefficient = 8.0f;
        internal const float rifleKillShotLevel1DamageCoefficient = 10.0f;
        internal const float rifleKillShotLevel2DamageCoefficient = 15.0f;
        internal const float rifleKillShotLevel3DamageCoefficient = 20.0f;
        #endregion

        #region Necromancer
        internal const float scepterBloodCurseDamageCoefficient = 0.5f;
        internal const float scepterRendingCurseDamageCoefficient = 0.75f;
        internal const float scepterPutridCurseDamageCoefficient = 1.0f;
        internal const float scepterDeathlySwarmDamageCoefficient = 1.0f;
        internal const float scepterLifeSiphonDamageCoefficient = 0.5f;
        internal const float scepterFeastOfCorruptionDamageCoefficient = 2.0f;
        #endregion
    }
}