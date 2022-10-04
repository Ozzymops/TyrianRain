using R2API;
using System;

namespace TyrianRain.Modules
{
    internal static class Tokens
    {
        internal static void AddTokens()
        {
            #region Guardian
            string guardianPrefix = TyrianRain.DEVELOPER_PREFIX + "_GUARDIAN_BODY_";

            string guardianDesc = "Guardians are devoted fighters who protect their allies and smite their enemies by drawing from the power of their Virtues.";
            guardianDesc += Environment.NewLine + Environment.NewLine + "<color=#CCD3E0>< ! > Virtue of Justice allows you and your allies to inflict additional damage by inflicting burning every few attacks.";
            guardianDesc += Environment.NewLine + Environment.NewLine + "<color=#CCD3E0>< ! > Virtue of Resolve regenerates you and your allies' health over time.";
            guardianDesc += Environment.NewLine + Environment.NewLine + "<color=#CCD3E0>< ! > Virtue of Courage increases you and your allies' survivability by periodically granting Aegis–a buff granting a one-time immunity to any direct attack.";
            guardianDesc += Environment.NewLine + Environment.NewLine + "<color=#CCD3E0>< ! > Choose between the support-focused Staff, or the more selfish and damage dealing Greatsword.";

            string guardianOutro = "...and so he left, in search for a higher purpose.";
            string guardianOutroFailure = "...and so he vanished, unable to protect his allies any longer.";

            LanguageAPI.Add(guardianPrefix + "GUARDIAN_NAME", "Guardian");
            LanguageAPI.Add(guardianPrefix + "GUARDIAN_DESCRIPTION", guardianDesc);
            LanguageAPI.Add(guardianPrefix + "GUARDIAN_SUBTITLE", "The Virtuous");
            LanguageAPI.Add(guardianPrefix + "GUARDIAN_LORE", "sample lore");
            LanguageAPI.Add(guardianPrefix + "GUARDIAN_OUTRO_FLAVOR", guardianOutro);
            LanguageAPI.Add(guardianPrefix + "GUARDIAN_OUTRO_FAILURE", guardianOutroFailure);

            #region Skins
            LanguageAPI.Add(guardianPrefix + "DEFAULT_SKIN_NAME", "Default");
            LanguageAPI.Add(guardianPrefix + "MASTERY_SKIN_NAME", "Virtuous");
            #endregion

            #region Passive
            LanguageAPI.Add(guardianPrefix + "PASSIVE_NAME", "Virtues");
            LanguageAPI.Add(guardianPrefix + "PASSIVE_DESCRIPTION", "Justice, courage, resolve!");
            #endregion

            #region Primary
            LanguageAPI.Add(guardianPrefix + "PRIMARY_STAFF_CHAIN1_NAME", "Bolt of Wrath");
            LanguageAPI.Add(guardianPrefix + "PRIMARY_STAFF_CHAIN1_DESCRIPTION", Helpers.chainPrefix + $"Fire a bolt for <style=cIsDamage>{100f * StaticValues.boltOfWrathDC}% damage</style>. <style=cIsUtility>Chains into Searing Light.</style>");
            LanguageAPI.Add(guardianPrefix + "PRIMARY_STAFF_CHAIN2_NAME", "Searing Light");
            LanguageAPI.Add(guardianPrefix + "PRIMARY_STAFF_CHAIN2_DESCRIPTION", Helpers.chainPrefix + $"Fire a projectile that explodes upon impact for <style=cIsDamage>{100f * StaticValues.searingLightDC}% damage</style>. <style=cIsUtility>Chains into Seeking Judgment.</style>");
            LanguageAPI.Add(guardianPrefix + "PRIMARY_STAFF_CHAIN3_NAME", "Seeking Judgment");
            LanguageAPI.Add(guardianPrefix + "PRIMARY_STAFF_CHAIN3_DESCRIPTION", Helpers.chainEnderPrefix + $"Fire a seeking projectile that explodes upon contact for <style=cIsDamage>{100f * StaticValues.seekingJudgmentDC}% damage</style>.");

            LanguageAPI.Add(guardianPrefix + "PRIMARY_GREATSWORD_CHAIN1_NAME", "Strike");
            LanguageAPI.Add(guardianPrefix + "PRIMARY_GREATSWORD_CHAIN1_DESCRIPTION", Helpers.chainPrefix + $"Strike your foe, dealing <style=cIsDamage>{100f * StaticValues.strikeDC}% damage</style>. <style=cIsUtility>Chains into Vengeful Strike.</style>");
            LanguageAPI.Add(guardianPrefix + "PRIMARY_GREATSWORD_CHAIN2_NAME", "Vengeful Strike");
            LanguageAPI.Add(guardianPrefix + "PRIMARY_GREATSWORD_CHAIN2_DESCRIPTION", Helpers.chainPrefix + $"Strike your foe again, dealing <style=cIsDamage>{100f * StaticValues.vengefulStrikeDC}% damage</style>. <style=cIsUtility>Chains into Wrathful Strike.</style>");
            LanguageAPI.Add(guardianPrefix + "PRIMARY_GREATSWORD_CHAIN3_NAME", "Wrathful Strike");
            LanguageAPI.Add(guardianPrefix + "PRIMARY_GREATSWORD_CHAIN3_DESCRIPTION", Helpers.chainEnderPrefix + $"Attack with a final, powerful strike that grants <style=cIsUtility>Might</style> for each foe struck, dealing <style=cIsDamage>{100f * StaticValues.wrathfulStrikeDC}% damage</style>.");
            #endregion

            #region Secondary
            LanguageAPI.Add(guardianPrefix + "SECONDARY_STAFF_NAME", "Holy Strike");
            LanguageAPI.Add(guardianPrefix + "SECONDARY_STAFF_DESCRIPTION", $"Mark an area for judgment, <style=cIsHealing>rapidly healing allies for {100f * StaticValues.holyStrikeHC}% of maximum health</style> and then blasting foes in the area for <style=cIsDamage>{100f * StaticValues.holyStrikeDC}% damage</style>.");

            LanguageAPI.Add(guardianPrefix + "SECONDARY_GREATSWORD_NAME", "Whirling Wrath");
            LanguageAPI.Add(guardianPrefix + "SECONDARY_GREATSWORD_DESCRIPTION", $"Spin in place and swing your greatsword while hurling six projectiles, hitting three times for a total of <style=cIsDamage>{100f * StaticValues.whirlingWrathDC}% damage and {100f * StaticValues.whirlingWrathProjectileDC}% damage per projectile</style>.");
            #endregion

            #region Utility
            LanguageAPI.Add(guardianPrefix + "UTILITY_STAFF_NAME", "Line of Warding");
            LanguageAPI.Add(guardianPrefix + "UTILITY_STAFF_DESCRIPTION", "Create a line in front of you that <style=cIsUtility>blocks projectiles</style> and <style=cIsUtility>blocks foes from crossing.</style>");

            LanguageAPI.Add(guardianPrefix + "UTILITY_GREATSWORD_NAME", "Leap of Faith");
            LanguageAPI.Add(guardianPrefix + "UTILITY_GREATSWORD_DESCRIPTION", $"Leap forward, <style=cIsUtility>blinding</style> foes on landing and <style=cIsHealing>healing {100f * StaticValues.leapOfFaithHC}% of maximum health for each foe hit</style>, dealing <style=cIsDamage>{100f * StaticValues.leapOfFaithDC}% damage</style>.");
            #endregion

            #region Special
            LanguageAPI.Add(guardianPrefix + "SPECIAL_STAFF_NAME", "Empower");
            LanguageAPI.Add(guardianPrefix + "SPECIAL_STAFF_DESCRIPTION", $"<style=cIsHealing>Heal yourself and allies for {100f * StaticValues.empowerHC}% of maximum health</style>, granting <style=cIsUtility>Might, Stability and Protection.</style>");

            LanguageAPI.Add(guardianPrefix + "SPECIAL_GREATSWORD_CHAIN1_NAME", "Binding Blade");
            LanguageAPI.Add(guardianPrefix + "SPECIAL_GREATSWORD_CHAIN1_DESCRIPTION", $"Throw five blades at nearby foes, initially hitting for <style=cIsDamage>{100f * StaticValues.bindingBladeDC}% damage</style> and then inflicting <style=cIsDamage>{100f * StaticValues.bindingBladeDotC}% damage</style> over ten seconds. <style=cIsUtility>Chains into Pull.</style>");
            LanguageAPI.Add(guardianPrefix + "SPECIAL_GREATSWORD_CHAIN2_NAME", "Pull");
            LanguageAPI.Add(guardianPrefix + "SPECIAL_GREATSWORD_CHAIN2_DESCRIPTION", $"<style=cIsUtility>Pull</style> bound foes towards you, <style=cIsUtility>stunning them for three seconds</style> and dealing <style=cIsDamage>{100f * StaticValues.pullDC}% damage</style>.");
            #endregion

            #region Traits
            LanguageAPI.Add(guardianPrefix + "TRAIT_ADEPT_NAME", "Renewed Wrath");
            LanguageAPI.Add(guardianPrefix + "TRAIT_ADEPT_DESCRIPTION", "Virtue of Justice's cooldown is reduced by 100% upon killing a foe. Burning an Elite enemy with Virtue of Justice will instead inflict five stacks of burning with doubled duration.");

            LanguageAPI.Add(guardianPrefix + "TRAIT_MASTER_NAME", "Shared Resolve");
            LanguageAPI.Add(guardianPrefix + "TRAIT_MASTER_DESCRIPTION", "Nearby allies are also healed by Virtue of Resolve's passive effect. Grant Protection to yourself and nearby allies every ten seconds.");

            LanguageAPI.Add(guardianPrefix + "TRAIT_GRANDMASTER_NAME", "Aggressive Aegis");
            LanguageAPI.Add(guardianPrefix + "TRAIT_GRANDMASTER_DESCRIPTION", $"Base damage is doubled when under the effect of Aegis. Blocking an attack with Aegis will cause an explosion around you, dealing {100f * StaticValues.aggressiveAegisDC}% damage, which cannot critically hit.");

            #region Achievements
            LanguageAPI.Add(guardianPrefix + "MASTERYUNLOCKABLE_ACHIEVEMENT_NAME", "Guardian: Mastery");
            LanguageAPI.Add(guardianPrefix + "MASTERYUNLOCKABLE_ACHIEVEMENT_DESC", "As Guardian, beat the game or obliterate on Monsoon.");
            LanguageAPI.Add(guardianPrefix + "MASTERYUNLOCKABLE_UNLOCKABLE_NAME", "Guardian: Mastery");
            #endregion

            #endregion

            #endregion

            #region Revenant
            #endregion

            #region Warrior
            #endregion

            #region Henry
            string prefix = TyrianRain.DEVELOPER_PREFIX + "_HENRY_BODY_";

            string desc = "Henry is a skilled fighter who makes use of a wide arsenal of weaponry to take down his foes.<color=#CCD3E0>" + Environment.NewLine + Environment.NewLine;
            desc = desc + "< ! > Sword is a good all-rounder while Boxing Gloves are better for laying a beatdown on more powerful foes." + Environment.NewLine + Environment.NewLine;
            desc = desc + "< ! > Pistol is a powerful anti air, with its low cooldown and high damage." + Environment.NewLine + Environment.NewLine;
            desc = desc + "< ! > Roll has a lingering armor buff that helps to use it aggressively." + Environment.NewLine + Environment.NewLine;
            desc = desc + "< ! > Bomb can be used to wipe crowds with ease." + Environment.NewLine + Environment.NewLine;

            string outro = "..and so he left, searching for a new identity.";
            string outroFailure = "..and so he vanished, forever a blank slate.";

            LanguageAPI.Add(prefix + "NAME", "Henry");
            LanguageAPI.Add(prefix + "DESCRIPTION", desc);
            LanguageAPI.Add(prefix + "SUBTITLE", "The Chosen One");
            LanguageAPI.Add(prefix + "LORE", "sample lore");
            LanguageAPI.Add(prefix + "OUTRO_FLAVOR", outro);
            LanguageAPI.Add(prefix + "OUTRO_FAILURE", outroFailure);

            #region Skins
            LanguageAPI.Add(prefix + "DEFAULT_SKIN_NAME", "Default");
            LanguageAPI.Add(prefix + "MASTERY_SKIN_NAME", "Alternate");
            #endregion

            #region Passive
            LanguageAPI.Add(prefix + "PASSIVE_NAME", "Henry passive");
            LanguageAPI.Add(prefix + "PASSIVE_DESCRIPTION", "Sample text.");
            #endregion

            #region Primary
            LanguageAPI.Add(prefix + "PRIMARY_SLASH_NAME", "Sword");
            LanguageAPI.Add(prefix + "PRIMARY_SLASH_DESCRIPTION", Helpers.agilePrefix + $"Swing forward for <style=cIsDamage>{100f * StaticValues.swordDamageCoefficient}% damage</style>.");
            #endregion

            #region Secondary
            LanguageAPI.Add(prefix + "SECONDARY_GUN_NAME", "Handgun");
            LanguageAPI.Add(prefix + "SECONDARY_GUN_DESCRIPTION", Helpers.agilePrefix + $"Fire a handgun for <style=cIsDamage>{100f * StaticValues.gunDamageCoefficient}% damage</style>.");
            #endregion

            #region Utility
            LanguageAPI.Add(prefix + "UTILITY_ROLL_NAME", "Roll");
            LanguageAPI.Add(prefix + "UTILITY_ROLL_DESCRIPTION", "Roll a short distance, gaining <style=cIsUtility>300 armor</style>. <style=cIsUtility>You cannot be hit during the roll.</style>");
            #endregion

            #region Special
            LanguageAPI.Add(prefix + "SPECIAL_BOMB_NAME", "Bomb");
            LanguageAPI.Add(prefix + "SPECIAL_BOMB_DESCRIPTION", $"Throw a bomb for <style=cIsDamage>{100f * StaticValues.bombDamageCoefficient}% damage</style>.");
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