using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioToggler : MonoBehaviour
{
    public bool isOn;
    private void Start()
    {
        isOn= true;
    }
    public void onOffSounds()
    {
        if (!isOn)
        {
            AudioListener.volume = 1f;
            isOn = true;
        }
        else if (isOn)
        {
            AudioListener.volume =0f;
            isOn = false;   
        }
    }
}
