using R2API;
using System;

namespace TyrianRain.Modules
{
    internal static class Tokens
    {
        internal static void AddTokens()
        {
            #region WARRIOR
            string warriorPrefix = TyrianRain.developerPrefix + "_WARRIOR_BODY_";

            LanguageAPI.Add(warriorPrefix + "NAME", "Warrior");

            string warriorDesc = "The Warrior is a powerful combatant that becomes more dangerous the longer the battle rages on.<color=#CCD3E0>" + Environment.NewLine + Environment.NewLine;
            warriorDesc = warriorDesc + "< ! > Adrenaline and Burst Attacks allow for powerful attacks with greater effects the more Adrenaline is spent." + Environment.NewLine + Environment.NewLine;
            warriorDesc = warriorDesc + "< ! > Weapon Swap allows for the Warrior to adapt to any situation. Equip your preferred sets in the Loadout screen." + Environment.NewLine + Environment.NewLine;

            LanguageAPI.Add(warriorPrefix + "DESCRIPTION", warriorDesc);
            LanguageAPI.Add(warriorPrefix + "SUBTITLE", "Master-At-Arms");
            LanguageAPI.Add(warriorPrefix + "LORE", "sample lore");

            string warriorOutro = "...and so he left, in search of a new arena to prove his valor in.";
            string warriorOutroFailure = "...and so he vanished, gone in a blaze of glory.";
            LanguageAPI.Add(warriorPrefix + "OUTRO_FLAVOR", warriorOutro);
            LanguageAPI.Add(warriorPrefix + "OUTRO_FAILURE", warriorOutroFailure);

            #region Passives
            LanguageAPI.Add(warriorPrefix + "PASSIVE_WARRIOR_NAME", "Warrior");
            LanguageAPI.Add(warriorPrefix + "PASSIVE_WARRIOR_DESCRIPTION", "Gain and spend Strikes of Adrenaline to execute Burst Attacks. Swap between three weapons at will, selecting the same weapon will execute a Burst Attack.");

            LanguageAPI.Add(warriorPrefix + "PASSIVE_BERSERKER_NAME", "Berserker");
            LanguageAPI.Add(warriorPrefix + "PASSIVE_BERSERKER_DESCRIPTION", "Gain and spend Strikes of Adrenaline to enter Berserk Mode, gaining buffs and access to Primal Burst Attacks with a reduced cost. Swap between two weapons at will, selecting the same weapon will enter Berserk Mode or execute a Primal Burst Attack.");
            #endregion

            #region Weapon Select
            LanguageAPI.Add(warriorPrefix + "WEAPONSELECT_GREATSWORD_NAME", "Greatsword");
            LanguageAPI.Add(warriorPrefix + "WEAPONSELECT_GREATSWORD_DESCRIPTION", $"A versatile weapon. Execute your foes with Burst Attack <style=cIsUtility>Arcing Slice</style>. Cripple stragglers with <style=cIsUtility>Bladetrail</style> and chase after them with <style=cIsUtility>Whirlwind Attack</style>. Decimate groups of foes with <style=cIsUtility>Hundred Blades</style>.");

            LanguageAPI.Add(warriorPrefix + "WEAPONSELECT_HAMMER_NAME", "Hammer");
            LanguageAPI.Add(warriorPrefix + "WEAPONSELECT_HAMMER_DESCRIPTION", $"A weapon with a focus on crowd control. Immobilize entire swarms with Burst Attack <style=cIsUtility>Earthshaker</style>. Weaken your foes with <style=cIsUtility>Fierce Blow</style>, reducing their damage output. Control your foes with <style=cIsUtility>Staggering Blow</style> and <style=cIsUtility>Backbreaker</style>, making them vulnerable to other attacks.");

            LanguageAPI.Add(warriorPrefix + "WEAPONSELECT_RIFLE_NAME", "Rifle");
            LanguageAPI.Add(warriorPrefix + "WEAPONSELECT_RIFLE_DESCRIPTION", $"A ranged weapon with a focus on single-target damage. Finish your foes with Burst Attack <style=cIsUtility>Kill Shot</style>. Make your targets vulnerable with <style=cIsUtility>Volley</style>. Evade and retreat to a better position with <style=cIsUtility>Brutal Shot</style>. Destroy small-packed groups of foes with <style=cIsUtility>Explosive Shell</style>.");
            #endregion

            #region Greatsword
            LanguageAPI.Add(warriorPrefix + "PRIMARY_GREATSWORD_CHAIN_NAME", "Greatsword Chain");
            LanguageAPI.Add(warriorPrefix + "PRIMARY_GREATSWORD_CHAIN_DESCRIPTION", $"<style=cIsUtility>Attack Chain</style>. Swing, Slice and Brutal Strike.");

            LanguageAPI.Add(warriorPrefix + "PRIMARY_GREATSWORD_SWING_NAME", "Swing");
            LanguageAPI.Add(warriorPrefix + "PRIMARY_GREATSWORD_SWING_DESCRIPTION", $"<style=cIsUtility>Attack Chain</style>. Slash your foe for <style=cIsDamage>{100f * StaticValues.greatswordSwingDamageCoefficient}% damage</style>. <style=cIsUtility>Chains into Slice</style>.");

            LanguageAPI.Add(warriorPrefix + "PRIMARY_GREATSWORD_SLICE_NAME", "Slice");
            LanguageAPI.Add(warriorPrefix + "PRIMARY_GREATSWORD_SLICE_DESCRIPTION", $"<style=cIsUtility>Attack Chain</style>. Slice your foe for <style=cIsDamage>{100f * StaticValues.greatswordSliceDamageCoefficient}% damage</style>. <style=cIsUtility>Chains into Brutal Strike</style>.");

            LanguageAPI.Add(warriorPrefix + "PRIMARY_GREATSWORD_BRUTALSTRIKE_NAME", "Brutal Strike");
            LanguageAPI.Add(warriorPrefix + "PRIMARY_GREATSWORD_BRUTALSTRIKE_DESCRIPTION", $"<style=cIsUtility>Attack Chain Ender</style>. Hit your foe with a final brutal strike for <style=cIsDamage>{100f * StaticValues.greatswordBrutalStrikeDamageCoefficient}% damage</style>. <style=cIsUtility>Gain one Strike of Adrenaline</style>. <style=cIsUtility>Resets Attack Chain</style>.");

            LanguageAPI.Add(warriorPrefix + "SECONDARY_GREATSWORD_BLADETRAIL_NAME", "Bladetrail");
            LanguageAPI.Add(warriorPrefix + "SECONDARY_GREATSWORD_BLADETRAIL_DESCRIPTION", $"Throw your greatsword at your foe so that it returns to you, dealing <style=cIsDamage>{100f * StaticValues.greatswordBladetrailDamageCoefficient}% damage</style> and inflicting <style=cIsDamage>Crippled</style>. <style=cIsUtility>Gain one Strike of Adrenaline</style>.");

            LanguageAPI.Add(warriorPrefix + "UTILITY_GREATSWORD_WHIRLWINDATTACK_NAME", "Whirlwind Attack");
            LanguageAPI.Add(warriorPrefix + "UTILITY_GREATSWORD_WHIRLWINDATTACK_DESCRIPTION", $"Whirl forward, slashing foes for <style=cIsDamage>3x{100f * StaticValues.greatswordWhirlwindAttackDamageCoefficient}% damage</style> along your path. <style=cIsUtility>You are invulnerable during this skill</style>. <style=cIsUtility>Gain two Strikes of Adrenaline</style>.");

            LanguageAPI.Add(warriorPrefix + "SPECIAL_GREATSWORD_HUNDREDBLADES_NAME", "Hundred Blades");
            LanguageAPI.Add(warriorPrefix + "SPECIAL_GREATSWORD_HUNDREDBLADES_DESCRIPTION", $"<style=cIsUtility>Root yourself in place, gaining 100 Armor</style>, repeatedly striking foes in front of you for <style=cIsDamage>8x{100f * StaticValues.greatswordHundredBladesDamageCoefficient}% damage</style>, finishing with a final strike that deals <style=cIsDamage>{100f * StaticValues.greatswordHundredBladesFinishDamageCoefficient}% damage</style>. <style=cIsUtility>Gain three Strikes of Adrenaline</style>.");

            LanguageAPI.Add(warriorPrefix + "BURST_GREATSWORD_ARCINGSLICE_NAME", "Arcing Slice");
            LanguageAPI.Add(warriorPrefix + "BURST_GREATSWORD_ARCINGSLICE_DESCRIPTION", $"<style=cIsUtility>Burst Attack</style>. Deliver a circular attack to foes around you, dealing <style=cIsDamage>{100f * StaticValues.greatswordArcingSliceDamageCoefficient}% damage</style>, executing low-health foes. <style=cIsUtility>Gain Fury for 8/12/16 seconds</style>. <style=cIsUtility>Gain 3/6/9 stacks of Might for 10 seconds</style>.");
            #endregion

            #region Hammer
            LanguageAPI.Add(warriorPrefix + "PRIMARY_HAMMER_CHAIN_NAME", "Hammer Chain");
            LanguageAPI.Add(warriorPrefix + "PRIMARY_HAMMER_CHAIN_DESCRIPTION", $"<style=cIsUtility>Attack Chain</style>. Swing, Bash and Smash.");

            LanguageAPI.Add(warriorPrefix + "PRIMARY_HAMMER_SWING_NAME", "Swing");
            LanguageAPI.Add(warriorPrefix + "PRIMARY_HAMMER_SWING_DESCRIPTION", $"<style=cIsUtility>Attack Chain</style>. Bash your foe for <style=cIsDamage>{100f * StaticValues.hammerSwingDamageCoefficient}% damage</style>. <style=cIsUtility>Chains into Bash</style>.");

            LanguageAPI.Add(warriorPrefix + "PRIMARY_HAMMER_BASH_NAME", "Bash");
            LanguageAPI.Add(warriorPrefix + "PRIMARY_HAMMER_BASH_DESCRIPTION", $"<style=cIsUtility>Attack Chain</style>. Bash your foe again for <style=cIsDamage>{100f * StaticValues.hammerBashDamageCoefficient}% damage</style>. <style=cIsUtility>Chains into Smash</style>.");

            LanguageAPI.Add(warriorPrefix + "PRIMARY_HAMMER_SMASH_NAME", "Smash");
            LanguageAPI.Add(warriorPrefix + "PRIMARY_HAMMER_SMASH_DESCRIPTION", $"<style=cIsUtility>Attack Chain Ender</style>. Smash the ground and damage nearby foes for <style=cIsDamage>{100f * StaticValues.hammerSmashDamageCoefficient}% damage</style>. <style=cIsUtility>Gain one Strike of Adrenaline</style>. <style=cIsUtility>Resets Attack Chain</style>.");

            LanguageAPI.Add(warriorPrefix + "SECONDARY_HAMMER_FIERCEBLOW_NAME", "Fierce Blow");
            LanguageAPI.Add(warriorPrefix + "SECONDARY_HAMMER_FIERCEBLOW_DESCRIPTION", $"<style=cIsUtility>Weaken</style> your foe with a fierce blow, dealing <style=cIsDamage>{100f * StaticValues.hammerFierceBlowDamageCoefficient}% damage</style>. <style=cIsDamage>Deal {100f * StaticValues.hammerFierceBlowMultiplier}% increased damaged to</style> <style=cIsUtility>controlled</style> <style=cIsDamage>targets</style>. <style=cIsUtility>Gain one Strike of Adrenaline</style>.");

            LanguageAPI.Add(warriorPrefix + "UTILITY_HAMMER_STAGGERINGBLOW_NAME", "Staggering Blow");
            LanguageAPI.Add(warriorPrefix + "UTILITY_HAMMER_STAGGERINGBLOW_DESCRIPTION", $"<style=cIsUtility>Push back</style> and <style=cIsUtility>stun</style> nearby foes with a staggering blow, dealing <style=cIsDamage>{100f * StaticValues.hammerStaggeringBlowDamageCoefficient}% damage</style>. <style=cIsUtility>Gain two Strikes of Adrenaline</style>.");

            LanguageAPI.Add(warriorPrefix + "SPECIAL_HAMMER_BACKBREAKER_NAME", "Backbreaker");
            LanguageAPI.Add(warriorPrefix + "SPECIAL_HAMMER_BACKBREAKER_DESCRIPTION", $"<style=cIsUtility>Stun</style> your foe for a long time, dealing <style=cIsDamage>{100f * StaticValues.hammerBackbreakerDamageCoefficient}% damage</style>. <style=cIsUtility>Weakened</style> foes are <style=cIsUtility>stunned</style> for longer. <style=cIsUtility>Recharges Fierce Blow on hit</style>. <style=cIsUtility>Gain three Strikes of Adrenaline</style>.");

            LanguageAPI.Add(warriorPrefix + "BURST_HAMMER_EARTHSHAKER_NAME", "Earthshaker");
            LanguageAPI.Add(warriorPrefix + "BURST_HAMMER_EARTHSHAKER_DESCRIPTION", $"<style=cIsUtility>Burst Attack</style>. <style=cIsUtility>Leap forward</style> and slam your hammer down, dealing <style=cIsDamage>{100f * StaticValues.hammerEarthshakerDamageCoefficient}% damage</style> and <style=cIsUtility>stunning</style> nearby foes. <style=cIsUtility>You gain 100 Armor during your leap</style>. <style=cIsUtility>Gain 3/6/9 stacks of Might for 10 seconds</style>.");
            #endregion

            #region Rifle
            LanguageAPI.Add(warriorPrefix + "PRIMARY_RIFLE_FIERCESHOT_NAME", "Fierce Shot");
            LanguageAPI.Add(warriorPrefix + "PRIMARY_RIFLE_FIERCESHOT_DESCRIPTION", $"Fire a shot at your target, dealing <style=cIsDamage>{100f * StaticValues.rifleFierceShotDamageCoefficient}% damage</style>. Gain one stack of <style=cIsUtility>Might</style> for 10 seconds and one <style=cIsUtility>Strike of Adrenaline</style> on hitting a <style=cIsUtility>Vulnerable</style> target, stripping one stack of <style=cIsUtility>Vulnerability</style>.");

            LanguageAPI.Add(warriorPrefix + "SECONDARY_RIFLE_VOLLEY_NAME", "Volley");
            LanguageAPI.Add(warriorPrefix + "SECONDARY_RIFLE_VOLLEY_DESCRIPTION", $"Fire a volley of shots at your target, dealing <style=cIsDamage>6x{100f * StaticValues.rifleVolleyDamageCoefficient}% damage</style>. <style=cIsUtility>Inflict one stack of Vulnerability per shot</style>. <style=cIsUtility>Gain one Strike of Adrenaline</style>.");

            LanguageAPI.Add(warriorPrefix + "UTILITY_RIFLE_BRUTALSHOT_NAME", "Brutal Shot");
            LanguageAPI.Add(warriorPrefix + "UTILITY_RIFLE_BRUTALSHOT_DESCRIPTION", $"<style=cIsUtility>Leap backward</style> while shooting your target, dealing <style=cIsDamage>{100f * StaticValues.rifleBrutalShotDamageCoefficient}% damage</style> and <style=cIsUtility>immobilizing</style> them for a short period. <style=cIsUtility>You are invulnerable during this skill</style>. <style=cIsUtility>Gain two Strikes of Adrenaline</style>.");

            LanguageAPI.Add(warriorPrefix + "SPECIAL_RIFLE_EXPLOSIVESHELL_NAME", "Explosive Shell");
            LanguageAPI.Add(warriorPrefix + "SPECIAL_RIFLE_EXPLOSIVESHELL_DESCRIPTION", $"Shoot an explosive round that explodes when it hits, dealing <style=cIsDamage>{100f * StaticValues.rifleExplosiveShellDamageCoefficient}% damage</style> in a small area. <style=cIsUtility>Inflict ten stacks of Vulnerability</style>. <style=cIsUtility>Gain three Strikes of Adrenaline</style>.");

            LanguageAPI.Add(warriorPrefix + "BURST_RIFLE_KILLSHOT_NAME", "Kill Shot");
            LanguageAPI.Add(warriorPrefix + "BURST_RIFLE_KILLSHOT_DESCRIPTION", $"<style=cIsUtility>Burst Attack</style>. Fire a powerful shot for <style=cIsDamage>{100f * StaticValues.rifleKillShotLevel1DamageCoefficient}%/{100f * StaticValues.rifleKillShotLevel2DamageCoefficient}%/{100f * StaticValues.rifleKillShotLevel3DamageCoefficient}% damage</style>. <style=cIsUtility>Gain 3/6/9 stacks of Might for 10 seconds</style>.");
            #endregion

            #region Achievements
            LanguageAPI.Add(warriorPrefix + "MASTERYUNLOCKABLE_ACHIEVEMENT_NAME", "Warrior: Mastery");
            LanguageAPI.Add(warriorPrefix + "MASTERYUNLOCKABLE_ACHIEVEMENT_DESC", "As Warrior, beat the game or obliterate on Monsoon.");
            LanguageAPI.Add(warriorPrefix + "MASTERYUNLOCKABLE_UNLOCKABLE_NAME", "Warrior: Mastery");
            #endregion

            #region Skins
            LanguageAPI.Add(warriorPrefix + "DEFAULT_SKIN_NAME", "Default");
            LanguageAPI.Add(warriorPrefix + "MASTERY_SKIN_NAME", "Alternate");
            #endregion

            #endregion

            #region NECROMANCER
            string necromancerPrefix = TyrianRain.developerPrefix + "_NECROMANCER_BODY_";

            LanguageAPI.Add(necromancerPrefix + "NAME", "Necromancer");

            string necromancerDesc = "The Necromancer spreads putrid death magic across the battlefield, corrupting all and harvesting Life Force.<color=#CCD3E0>" + Environment.NewLine + Environment.NewLine;
            necromancerDesc = necromancerDesc + "< ! > Gain Life Force from deaths that occur around you, using it as fuel for Shroud." + Environment.NewLine + Environment.NewLine;
            necromancerDesc = necromancerDesc + "< ! > Shroud replaces your health bar with Life Force, giving you essentially a second health bar. You also gain access to new skills." + Environment.NewLine + Environment.NewLine;
            necromancerDesc = necromancerDesc + "< ! > Allied deaths leave behind a Soul, which can be interacted with to sacrifice 50% of your Life Force to resurrect them." + Environment.NewLine + Environment.NewLine;

            LanguageAPI.Add(necromancerPrefix + "DESCRIPTION", necromancerDesc);
            LanguageAPI.Add(necromancerPrefix + "SUBTITLE", "The Undying");
            LanguageAPI.Add(necromancerPrefix + "LORE", "sample lore");

            string necromancerOutro = "...and so he left, in search of more bodies to add to his army.";
            string necromancerOutroFailure = "...and so he left, the souls in his possession finally freed.";
            LanguageAPI.Add(necromancerPrefix + "OUTRO_FLAVOR", necromancerOutro);
            LanguageAPI.Add(necromancerPrefix + "OUTRO_FAILURE", necromancerOutroFailure);

            #region Passives
            LanguageAPI.Add(necromancerPrefix + "PASSIVE_NECROMANCER_NAME", "Necromancer");
            LanguageAPI.Add(necromancerPrefix + "PASSIVE_NECROMANCER_DESCRIPTION", "Gain Life Force from deaths around you, using it as fuel for the Death Shroud - a powerful spectral form with the ability to inflict many deadly debuffs.");
            
            LanguageAPI.Add(necromancerPrefix + "PASSIVE_REAPER_NAME", "Reaper");
            LanguageAPI.Add(necromancerPrefix + "PASSIVE_REAPER_DESCRIPTION", "Gain Life Force from deaths around you, using it as fuel for the Reaper Shroud - a transformation giving access to a reaping scythe, cleaving all before you.");
            #endregion

            #region Scepter
            LanguageAPI.Add(necromancerPrefix + "PRIMARY_SCEPTER_CHAIN_NAME", "Scepter Chain");
            LanguageAPI.Add(necromancerPrefix + "PRIMARY_SCEPTER_CHAIN_DESCRIPTION", $"<style=cIsUtility>Attack Chain</style>. Blood Curse, Rending Curse and Putrid Curse.");

            LanguageAPI.Add(necromancerPrefix + "PRIMARY_SCEPTER_BLOODCURSE_NAME", "Blood Curse");
            LanguageAPI.Add(necromancerPrefix + "PRIMARY_SCEPTER_BLOODCURSE_DESCRIPTION", $"<style=cIsUtility>Attack Chain</style>. Strike your foe from afar for <style=cIsDamage>{100f * StaticValues.scepterBloodCurseDamageCoefficient}% damage</style>, inflicting <style=cIsDamage>Bleeding</style>. <style=cIsUtility>Chains into Rending Curse</style>.");

            LanguageAPI.Add(necromancerPrefix + "PRIMARY_SCEPTER_RENDINGCURSE_NAME", "Rending Curse");
            LanguageAPI.Add(necromancerPrefix + "PRIMARY_SCEPTER_RENDINGCURSE_DESCRIPTION", $"<style=cIsUtility>Attack Chain</style>. Strike your foe from afar again for <style=cIsDamage>{100f * StaticValues.scepterRendingCurseDamageCoefficient}% damage</style>, inflicting <style=cIsDamage>Bleeding</style>. <style=cIsUtility>Chains into Putrid Curse</style>.");

            LanguageAPI.Add(necromancerPrefix + "PRIMARY_SCEPTER_PUTRIDCURSE_NAME", "Putrid Curse");
            LanguageAPI.Add(necromancerPrefix + "PRIMARY_SCEPTER_PUTRIDCURSE_DESCRIPTION", $"<style=cIsUtility>Attack Chain Ender</style>. Strike your foe from afar one last time for <style=cIsDamage>{100f * StaticValues.scepterPutridCurseDamageCoefficient}% damage</style>, inflicting <style=cIsDamage>Bleeding</style> and <style=cIsDamage>Poison</style>. <style=cIsUtility>Resets Attack Chain</style>.");

            LanguageAPI.Add(necromancerPrefix + "SECONDARY_SCEPTER_DEATHLYSWARM_NAME", "Deathly Swarm");
            LanguageAPI.Add(necromancerPrefix + "SECONDARY_SCEPTER_DEATHLYSWARM_DESCRIPTION", $"Unleash an insect swarm to <style=cIsUtility>blind</style> foes and <style=cIsUtility>transfer debuffs</style> to them, dealing <style=cIsDamage>{100f * StaticValues.scepterDeathlySwarmDamageCoefficient}% damage</style>. <style=cIsHealing>Gain 5% Life Force</style> and <style=cIsHealing>5% Life Force extra</style> per debuff transfered.");

            LanguageAPI.Add(necromancerPrefix + "UTILITY_SCEPTER_LIFESIPHON_NAME", "Life Siphon");
            LanguageAPI.Add(necromancerPrefix + "UTILITY_SCEPTER_LIFESIPHON_DESCRIPTION", $"Siphon health from your target, dealing <style=cIsDamage>10x{100f * StaticValues.scepterLifeSiphonDamageCoefficient}% damage</style> and <style=cIsHealing>healing yourself for 10x5% maximum health</style>. <style=cIsHealing>Gain 10% Life Force</style>.");

            LanguageAPI.Add(necromancerPrefix + "SPECIAL_SCEPTER_FEASTOFCORRUPTION_NAME", "Feast of Corruption");
            LanguageAPI.Add(necromancerPrefix + "SPECIAL_SCEPTER_FEASTOFCORRUPTION_DESCRIPTION", $"Strike your target and all around it for <style=cIsDamage>{100f * StaticValues.scepterFeastOfCorruptionDamageCoefficient}% damage</style>, <style=cIsUtility>corrupting buffs</style> on struck foes. For each <style=cIsUtility>corrupted buff</style>, <style=cIsHealing>gain 10% Life Force</style> and inflict either <style=cIsDamage>Bleeding</style>, <style=cIsDamage>Poison</style> or <style=cIsDamage>Torment</style>. <style=cIsHealing>Gain 15% Life Force</style>.");

            LanguageAPI.Add(necromancerPrefix + "SHROUD_SCEPTER_DEATHSHROUD_NAME", "Death Shroud");
            LanguageAPI.Add(necromancerPrefix + "SHROUD_SCEPTER_DEATHSHROUD_DESCRIPTION", $"<style=cIsUtility>Shroud Attack</style>. Assume a spectral form and <style=cIsUtility>gain new skills</style>, <style=cIsHealing>turning your Life Force into health</style>. <style=cIsUtility>Consume all current debuffs</style> on you for <style=cIsHealing>5% Life Force</style> each.");
            #endregion

            #region Achievements
            LanguageAPI.Add(necromancerPrefix + "MASTERYUNLOCKABLE_ACHIEVEMENT_NAME", "Necromancer: Mastery");
            LanguageAPI.Add(necromancerPrefix + "MASTERYUNLOCKABLE_ACHIEVEMENT_DESC", "As Necromancer, beat the game or obliterate on Monsoon.");
            LanguageAPI.Add(necromancerPrefix + "MASTERYUNLOCKABLE_UNLOCKABLE_NAME", "Necromancer: Mastery");
            #endregion

            #region Skins
            LanguageAPI.Add(necromancerPrefix + "DEFAULT_SKIN_NAME", "Default");
            LanguageAPI.Add(necromancerPrefix + "MASTERY_SKIN_NAME", "Alternate");
            #endregion

            #endregion
        }
    }
}