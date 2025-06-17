using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FlashLightScript : MonoBehaviour
{
    [SerializeField] Image flashLightBatteryChunks;

    [SerializeField] float batteryPower = 1.0f;
    [SerializeField] float drainTime = 2.0f;
    [SerializeField] LookMode lookMode;

    public float BatteryPower { get { return batteryPower; } }

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating(nameof(FLBatteryDrain), drainTime, drainTime);
    }

    // Update is called once per frame
    void Update()
    {
        flashLightBatteryChunks.fillAmount = batteryPower ;
    }
    
    private void FLBatteryDrain()
    {
        if (lookMode.IsFlashLightIsOn)
        {
            if (batteryPower > 0)
            {
                batteryPower -= 0.25f;
            }
        }
    }
}
