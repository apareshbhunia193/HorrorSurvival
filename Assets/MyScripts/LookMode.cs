using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class LookMode : MonoBehaviour
{
    [SerializeField] PostProcessVolume vol;
    [SerializeField] PostProcessProfile standard;
    [SerializeField] PostProcessProfile nightVision;
    [SerializeField] GameObject nightVisionOverlay;
    [SerializeField] NightVisionScript nightVisionScript;
    [SerializeField] GameObject flashLight;
    [SerializeField] FlashLightScript flashLightScript;
    [SerializeField] GameObject flashLightOverlay;

    private bool nightVisionOn = false;
    private bool flashLightOn = false;

    public bool IsNightVisionOn { get { return nightVisionOn; } }
    public bool IsFlashLightIsOn { get { return flashLightOn; } }

    // Start is called before the first frame update
    void Start()
    {
        vol = GetComponent<PostProcessVolume>();
        nightVisionOverlay.SetActive(false);
        vol.profile = standard;
        flashLight.SetActive(false);
        flashLightOverlay.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.N))
        {
            if (!nightVisionOn)
            {
                nightVisionOverlay.SetActive(true);
                vol.profile = nightVision;
                nightVisionOn = true;
                ChangeToStandardLookMode();

            }
            else if (nightVisionOn)
            {
                this.gameObject.GetComponent<Camera>().fieldOfView = 60;
                nightVisionOverlay.SetActive(false);
                vol.profile = standard;
                nightVisionOn = false;
            }
        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            if (!flashLightOn)
            {
                flashLight.SetActive(true);
                flashLightOverlay.SetActive(true);
                flashLightOn = true;
            }
            else
            {
                flashLight.SetActive(false);
                flashLightOverlay.SetActive(false);
                flashLightOn = false;
            }
        }

        if (nightVisionOn)
        {
            ChangeToStandardLookMode();
        }
        if (flashLightOn)
        {
            CheckFlashLightPower();
        }
    }

    void ChangeToStandardLookMode()
    {
        if (nightVisionScript.BatteryPower <= 0)
        {
            gameObject.GetComponent<Camera>().fieldOfView = 60;
            nightVisionOverlay.SetActive(false);
            vol.profile = standard;
            nightVisionOn = false;
        }
    }

    void CheckFlashLightPower()
    {
        if (flashLightScript.BatteryPower <= 0)
        {
            flashLight.SetActive(false);
            flashLightOverlay.SetActive(false);
            flashLightOn = false;
        }
    }
}
