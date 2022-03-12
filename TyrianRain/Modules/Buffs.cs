using RoR2;
using System.Collections.Generic;
using UnityEngine;

namespace TyrianRain.Modules
{
    public static class Buffs
    {
        // boons
        internal static BuffDef boonAegis;
        internal static BuffDef boonAlacrity;
        internal static BuffDef boonFury;
        internal static BuffDef boonMight;
        internal static BuffDef boonProtection;
        internal static BuffDef boonQuickness;
        internal static BuffDef boonRegeneration;
        internal static BuffDef boonResistance;
        internal static BuffDef boonResolution;
        internal static BuffDef boonStability;
        internal static BuffDef boonSwiftness;
        internal static BuffDef boonVigor;

        internal static List<BuffDef> buffDefs = new List<BuffDef>();

        internal static void RegisterBuffs()
        {
            // boons
            boonAegis = AddNewBuff("TyrianRainBoonAegis", Assets.mainAssetBundle.LoadAsset<Sprite>("Boon_Aegis"), Color.white, false, false);
            boonAlacrity = AddNewBuff("TyrianRainBoonAlacrity", Assets.mainAssetBundle.LoadAsset<Sprite>("Boon_Alacrity"), Color.white, false, false);
            boonFury = AddNewBuff("TyrianRainBoonFury", Assets.mainAssetBundle.LoadAsset<Sprite>("Boon_Fury"), Color.white, false, false);
            boonMight = AddNewBuff("TyrianRainBoonMight", Assets.mainAssetBundle.LoadAsset<Sprite>("Boon_Might"), Color.white, true, false);
            boonProtection = AddNewBuff("TyrianRainBoonProtection", Assets.mainAssetBundle.LoadAsset<Sprite>("Boon_Protection"), Color.white, false, false);
            boonQuickness = AddNewBuff("TyrianRainBoonQuickness", Assets.mainAssetBundle.LoadAsset<Sprite>("Boon_Quickness"), Color.white, false, false);
            boonRegeneration = AddNewBuff("TyrianRainBoonRegeneration", Assets.mainAssetBundle.LoadAsset<Sprite>("Boon_Regeneration"), Color.white, false, false);
            boonResistance = AddNewBuff("TyrianRainBoonResistance", Assets.mainAssetBundle.LoadAsset<Sprite>("Boon_Resistance"), Color.white, false, false);
            boonResolution = AddNewBuff("TyrianRainBoonResolution", Assets.mainAssetBundle.LoadAsset<Sprite>("Boon_Resolution"), Color.white, false, false);
        }

        internal static BuffDef AddNewBuff(string buffName, Sprite buffIcon, Color buffColor, bool canStack, bool isDebuff)
        {
            BuffDef buffDef = ScriptableObject.CreateInstance<BuffDef>();
            buffDef.name = buffName;
            buffDef.buffColor = buffColor;
            buffDef.canStack = canStack;
            buffDef.isDebuff = isDebuff;
            buffDef.eliteDef = null;
            buffDef.iconSprite = buffIcon;

            buffDefs.Add(buffDef);

            return buffDef;
        }

        public static void HandleTimedBuff(BuffDef buffDef, CharacterBody body, int maxStacks)
        {
            int buffCount = 0;
            float buffTimer = 0f;

            foreach (CharacterBody.TimedBuff buff in body.timedBuffs)
            {
                if (buff.buffIndex == buffDef.buffIndex)
                {
                    if (buffTimer > buff.timer || buffTimer == 0f)
                    {
                        buffTimer = buff.timer;
                    }

                    buffCount++;
                }
            }

            body.ClearTimedBuffs(buffDef);

            for (int i = 1; i < buffCount; i++)
            {
                body.AddTimedBuff(buffDef, buffTimer, maxStacks);
            }
        }
    }
}