using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;
using RoR2;
using RoR2.UI;
using R2API;

namespace TyrianRain.Modules.Professions.Warrior
{
    public class WarriorHUD : MonoBehaviour
    {
        string prefabName = "WarriorHUD";

        private HUD hud;
        private GameObject customHud;

        private int adrenaline;
        private int maxAdrenaline;
        private int adrenalineThreshold;

        private void Awake()
        {
            On.RoR2.UI.HUD.Awake += AddHudPrefab;
            this.gameObject.GetComponent<WarriorAdrenaline>().OnAdrenalineUpdated += UpdateAdrenaline;
        }

        private void AddHudPrefab(On.RoR2.UI.HUD.orig_Awake orig, RoR2.UI.HUD self)
        {
            orig(self);
            hud = self;

            // elite spec checks

            customHud = GameObject.Instantiate(Modules.Assets.mainAssetBundle.LoadAsset<GameObject>(prefabName), hud.mainContainer.transform);
            customHud.transform.GetChild(0).GetChild(0).GetComponent<Image>().fillAmount = 0;
            customHud.transform.GetChild(0).GetChild(2).GetComponent<Text>().text = "0/0";
        }

        private void Update()
        {
            if (maxAdrenaline != 0)
            {
                customHud.transform.GetChild(0).GetChild(0).GetComponent<Image>().fillAmount = adrenaline / maxAdrenaline;
                customHud.transform.GetChild(0).GetChild(2).GetComponent<Text>().text = (adrenaline + "/" + maxAdrenaline);
            }
        }

        public void UpdateAdrenaline(int adrenaline, int maxAdrenaline, int adrenalineThreshold)
        {
            this.adrenaline = adrenaline;
            this.maxAdrenaline = maxAdrenaline;
            this.adrenalineThreshold = adrenalineThreshold;
        }
    }
}
