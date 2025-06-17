using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NightVisionScript : MonoBehaviour
{

    [SerializeField] Image zoomBar;
    [SerializeField] Camera cam;
    [SerializeField] Image batteryChunks;

    [SerializeField] float batteryPower = 1.0f;
    [SerializeField] float drainTime = 2.0f;

    [SerializeField] LookMode lookMode;

    public float BatteryPower { get { return batteryPower; } }
    // Start is called before the first frame update
    void Start()
    {
        //we also can do 
        //zoomBar = GameObject.Find("ZoomBar").GetComponent<Image>(); 

        InvokeRepeating(nameof(BatteryDrain), drainTime, drainTime);
    }

    void OnEnable()
    {
        zoomBar.fillAmount = 0.6f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            if (cam.fieldOfView > 10)
            {
                cam.fieldOfView -= 5;
                zoomBar.fillAmount = cam.fieldOfView / 100;
            }
        }
        else if (Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            if (cam.fieldOfView < 60)
            {
                cam.fieldOfView += 5;
                zoomBar.fillAmount = cam.fieldOfView / 100;
            }
        }
        batteryChunks.fillAmount = batteryPower ;

    }

    private void BatteryDrain()
    {
        if (lookMode.IsNightVisionOn)
        {
            if (batteryPower > 0)
            {
                batteryPower -= 0.25f;
            }
        }
    }
}
