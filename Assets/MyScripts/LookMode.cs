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

    private bool nightVisionOn = false;


    // Start is called before the first frame update
    void Start()
    {
        vol = GetComponent<PostProcessVolume>();
        nightVisionOverlay.SetActive(false);
        vol.profile = standard;
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
        if (nightVision)
        {
            ChangeToStandardLookMode();
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
}
