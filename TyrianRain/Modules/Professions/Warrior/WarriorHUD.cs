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
        private HUD baseHUD;
        private GameObject customHUD;

        #region HUD components
        private Image _adrenalineBar;
        private Text _adrenalineCounter;

        private Image _weaponSwap;
        private Text _weaponSwapCounter;
        #endregion

        private int _adrenaline;
        private int _maxAdrenaline;
        private int _adrenalineThreshold;

        private int _weaponIndex;
        private float _weaponSwapTimer;

        private string prefabName = "WarriorHUD";

        private void OnEnable()
        {
            WarriorAdrenaline.OnAdrenalineSetup += SetupAdrenaline;
            WarriorAdrenaline.OnAdrenalineChanged += UpdateAdrenaline;
            WarriorWeaponSwap.OnWeaponSwap += UpdateWeaponSwap;

            On.RoR2.UI.HUD.Awake += BuildHUD;
        }

        private void OnDisable()
        {
            WarriorAdrenaline.OnAdrenalineSetup -= SetupAdrenaline;
            WarriorAdrenaline.OnAdrenalineChanged -= UpdateAdrenaline;
            WarriorWeaponSwap.OnWeaponSwap -= UpdateWeaponSwap;

            On.RoR2.UI.HUD.Awake -= BuildHUD;
        }

        /// <summary>
        /// Instantiate HUD prefab and setup appropriate images/values
        /// </summary>
        /// <param name="orig"></param>
        /// <param name="self"></param>
        private void BuildHUD(On.RoR2.UI.HUD.orig_Awake orig, RoR2.UI.HUD self)
        {
            orig(self);
            baseHUD = self;

            customHUD = GameObject.Instantiate(Modules.Assets.mainAssetBundle.LoadAsset<GameObject>(prefabName), baseHUD.mainContainer.transform);

            // get components
            _adrenalineBar = customHUD.transform.GetChild(0).GetChild(1).GetComponent<Image>();
            _adrenalineCounter = customHUD.transform.GetChild(0).GetChild(3).GetComponent<Text>();

            _weaponSwap = customHUD.transform.GetChild(1).GetChild(0).GetChild(1).GetComponent<Image>();
            _weaponSwapCounter= customHUD.transform.GetChild(1).GetChild(0).GetChild(2).GetComponent<Text>();

            // todo: get weapon images, cooldown image          
        }

        private void Update()
        {
            if (_weaponSwapTimer > 0.0f)
            {
                _weaponSwapTimer -= 1.0f * Time.deltaTime;

                _weaponSwap.fillAmount = Mathf.Lerp(_weaponSwap.fillAmount, 1.0f - _weaponSwapTimer / 10.0f, 1.0f);
                _weaponSwapCounter.text = FloatHelper(_weaponSwapTimer);
            }
            else
            {
                _weaponSwap.fillAmount = 1.0f;
                _weaponSwapCounter.text = "";
            }
            
            _adrenalineBar.fillAmount = Mathf.Lerp(_adrenalineBar.fillAmount, _adrenaline / _maxAdrenaline, 1.0f);
            _adrenalineCounter.text = _adrenaline + "/" + _maxAdrenaline;            
        }

        /// <summary>
        /// Set maximum adrenaline and threshold bars for adrenaline levels
        /// </summary>
        /// <param name="maximumAdrenaline">Maximum adrenaline value</param>
        /// <param name="adrenalineThreshold">Adrenaline threshold for levels (basically maximum divided by 3)</param>
        private void SetupAdrenaline(int maximumAdrenaline, int adrenalineThreshold)
        {
            _maxAdrenaline = maximumAdrenaline;
            _adrenalineThreshold = adrenalineThreshold;

            // todo: set adrenaline threshold bars
        }

        /// <summary>
        /// Set adrenaline value
        /// </summary>
        /// <param name="adrenaline">Current adrenaline value</param>
        private void UpdateAdrenaline(int adrenaline)
        {
            _adrenaline = adrenaline;
        }

        /// <summary>
        /// Activate weapon cooldown timer and change selected weapon
        /// </summary>
        /// <param name="index">Weapon index</param>
        /// <param name="timer">Weapon Swap cooldown timer</param>
        private void UpdateWeaponSwap(int index, float timer)
        {
            _weaponIndex = index;
            _weaponSwapTimer = timer;
        }

        /// <summary>
        /// Return a float above 3.0 as single digit, otherwise as double digits
        /// </summary>
        /// <param name="f">Float to handle</param>
        /// <returns></returns>
        private string FloatHelper(float f)
        {
            if (f > 3.0f)
            {
                return f.ToString("0");
            }
            else
            {
                return f.ToString("0.0");
            }
        }
    }
}
