using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundController : MonoBehaviour
{    
    public AudioSource bgSource, jumpSource;
    private static readonly string firstPlay = "FirstPlay";
    private static readonly string bgPref = "BackGroundPref";
    private static readonly string effectPref = "EffectPref";

    private int firstPlayInt;
    public Slider bgSlider, effectSlider;
    private float bgFloat, effectFloat;

    void Start() {
        firstPlayInt = PlayerPrefs.GetInt(firstPlay);
        if(firstPlayInt == 0)
        {
            bgFloat = .5f;
            effectFloat = .1f;
            bgSlider.value = bgFloat;
            effectSlider.value = effectFloat;
            PlayerPrefs.SetFloat(bgPref,bgFloat);
            PlayerPrefs.SetFloat(effectPref,effectFloat);
            PlayerPrefs.SetInt(firstPlay,-1);
        }
        else
        {
            bgFloat = PlayerPrefs.GetFloat(bgPref);
            bgSlider.value = bgFloat;
            effectFloat = PlayerPrefs.GetFloat(effectPref);
            effectSlider.value = effectFloat;
        }
    }

    public void SaveSoundSettings()
    {
        PlayerPrefs.SetFloat(bgPref,bgSlider.value);
        PlayerPrefs.SetFloat(effectPref,effectSlider.value);
    }

    void OnApplicationFocus(bool inFocus) {
        if(!inFocus)
        {
            SaveSoundSettings();
        }    
    }

    public void updateEffectVolume(float volume)
    {
        jumpSource.volume = effectSlider.value;
    }

     public void updateBgVolume(float volume)
    {
        bgSource.volume = bgSlider.value;
    }

}
