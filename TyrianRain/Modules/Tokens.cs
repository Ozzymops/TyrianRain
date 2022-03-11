using R2API;
using System;

namespace TyrianRain.Modules
{
    internal static class Tokens
    {
        internal static void AddTokens()
        {
            #region Warrior
            string prefix = TyrianRain.developerPrefix + "_HENRY_BODY_";

            string desc = "The Warrior is a powerful combatant that becomes more dangerous the longer the battle rages on.<color=#CCD3E0>" + Environment.NewLine + Environment.NewLine;
            desc = desc + "< ! > Adrenaline and Burst Attacks allow for powerful attacks with greater effects the more Adrenaline is spent." + Environment.NewLine + Environment.NewLine;
            desc = desc + "< ! > Weapon Swap allows for the Warrior to adapt to any situation. Equip your preferred sets in the Loadout screen." + Environment.NewLine + Environment.NewLine;

            string outro = "...and so he left, in search of a new arena to prove his valor in.";
            string outroFailure = "...and so he vanished, gone in a blaze of glory.";

            LanguageAPI.Add(prefix + "NAME", "Warrior");
            LanguageAPI.Add(prefix + "DESCRIPTION", desc);
            LanguageAPI.Add(prefix + "SUBTITLE", "Master-At-Arms");
            LanguageAPI.Add(prefix + "LORE", "sample lore");
            LanguageAPI.Add(prefix + "OUTRO_FLAVOR", outro);
            LanguageAPI.Add(prefix + "OUTRO_FAILURE", outroFailure);

            #region Skins
            LanguageAPI.Add(prefix + "DEFAULT_SKIN_NAME", "Default");
            LanguageAPI.Add(prefix + "MASTERY_SKIN_NAME", "Alternate");
            #endregion

            #region Passive
            LanguageAPI.Add(prefix + "PASSIVE_NAME", "Adrenaline & Weapon Swap");
            LanguageAPI.Add(prefix + "PASSIVE_DESCRIPTION", "Adrenaline: Gain and spend Strikes of Adrenaline to execute Burst Attacks. Weapon Swap: Swap between three weapons at will, selecting the same weapon will execute a Burst Attack.");
            #endregion

            #region Primary
            LanguageAPI.Add(prefix + "PRIMARY_GREATSWORD_CHAIN_NAME", "Greatsword Chain");
            LanguageAPI.Add(prefix + "PRIMARY_GREATSWORD_CHAIN_DESCRIPTION", $"<style=cIsUtility>Attack Chain</style>. Slash, Slice and Brutal Strike.");

            LanguageAPI.Add(prefix + "PRIMARY_GREATSWORD_SWING_NAME", "Swing");
            LanguageAPI.Add(prefix + "PRIMARY_GREATSWORD_SWING_DESCRIPTION", $"<style=cIsUtility>Attack Chain</style>. Slash your foe for <style=cIsDamage>{100f * StaticValues.greatswordSwingDamageCoefficient}% damage</style>. <style=cIsUtility>Chains into Slice</style>.");

            LanguageAPI.Add(prefix + "PRIMARY_GREATSWORD_SLICE_NAME", "Slice");
            LanguageAPI.Add(prefix + "PRIMARY_GREATSWORD_SLICE_DESCRIPTION", $"<style=cIsUtility>Attack Chain</style>. Slice your foe for <style=cIsDamage>{100f * StaticValues.greatswordSliceDamageCoefficient}% damage</style>. <style=cIsUtility>Chains into Brutal Strike</style>.");

            LanguageAPI.Add(prefix + "PRIMARY_GREATSWORD_BRUTALSTRIKE_NAME", "Brutal Strike");
            LanguageAPI.Add(prefix + "PRIMARY_GREATSWORD_BRUTALSTRIKE_DESCRIPTION", $"<style=cIsUtility>Attack Chain Ender</style>. Hit your foe with a final brutal strike for <style=cIsDamage>{100f * StaticValues.greatswordBrutalStrikeDamageCoefficient}% damage</style>. <style=cIsUtility>Gain one Strike of Adrenaline</style>. <style=cIsUtility>Resets Attack Chain</style>.");
            #endregion

            #region Secondary
            LanguageAPI.Add(prefix + "SECONDARY_GREATSWORD_BLADETRAIL_NAME", "Bladetrail");
            LanguageAPI.Add(prefix + "SECONDARY_GREATSWORD_BLADETRAIL_DESCRIPTION", $"Throw your greatsword at your foe so that it returns to you, dealing <style=cIsDamage>{100f * StaticValues.greatswordBladetrailDamageCoefficient}% damage</style> and inflicting <style=cIsDamage>Crippled</style>. <style=cIsUtility>Gain one Strike of Adrenaline</style>.");
            #endregion

            #region Utility
            LanguageAPI.Add(prefix + "UTILITY_GREATSWORD_WHIRLWINDATTACK_NAME", "Whirlwind Attack");
            LanguageAPI.Add(prefix + "UTILITY_GREATSWORD_WHIRLWINDATTACK_DESCRIPTION", $"Whirl forward, slashing foes for <style=cIsDamage>3x{100f * StaticValues.greatswordWhirlwindAttackDamageCoefficient}% damage</style> along your path. <style=cIsUtility>You are invulnerable during this skill</style>. <style=cIsUtility>Gain two Strikes of Adrenaline</style>.");
            #endregion

            #region Special
            LanguageAPI.Add(prefix + "SPECIAL_GREATSWORD_HUNDREDBLADES_NAME", "Hundred Blades");
            LanguageAPI.Add(prefix + "SPECIAL_GREATSWORD_HUNDREDBLADES_DESCRIPTION", $"<style=cIsUtility>Root yourself in place, gaining 100 Armor</style>, repeatedly striking foes in front of you for <style=cIsDamage>8x{100f * StaticValues.greatswordHundredBladesDamageCoefficient}% damage</style>, finishing with a final strike that deals <style=cIsDamage>{100f * StaticValues.greatswordHundredBladesFinishDamageCoefficient}% damage</style>. <style=cIsUtility>Gain three Strikes of Adrenaline</style>.");
            #endregion

            #region Burst
            LanguageAPI.Add(prefix + "SPECIAL_GREATSWORD_ARCINGSLICE_NAME", "Arcing Slice");
            LanguageAPI.Add(prefix + "SPECIAL_GREATSWORD_ARCINGSLICE_DESCRIPTION", $"<style=cIsUtility>Burst Attack</style>. Deliver a circular attack to foes around you, dealing <style=cIsDamage>{100f * StaticValues.greatswordArcingSliceDamageCoefficient}% damage</style>, executing low-health foes. <style=cIsUtility>Gain Fury for 8/12/16 seconds</style>. <style=cIsUtility>Gain 3/6/9 stacks of Might for 10 seconds</style>.");
            #endregion

            #region Achievements
            LanguageAPI.Add(prefix + "MASTERYUNLOCKABLE_ACHIEVEMENT_NAME", "Henry: Mastery");
            LanguageAPI.Add(prefix + "MASTERYUNLOCKABLE_ACHIEVEMENT_DESC", "As Henry, beat the game or obliterate on Monsoon.");
            LanguageAPI.Add(prefix + "MASTERYUNLOCKABLE_UNLOCKABLE_NAME", "Henry: Mastery");
            #endregion
            #endregion
        }
    }
}