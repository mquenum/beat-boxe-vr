using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UIElements;

public class MixerController : MonoBehaviour
{
    [SerializeField] private AudioMixerGroup myAudioMixer;

    public void SetVolumeMaster(float sliderValue)
    {
        // valeur logarythmique de base 10 pour les DB
        myAudioMixer.audioMixer.SetFloat("MasterVolume", Mathf.Log10(sliderValue) * 20);
    }

    public void SetVolumeBGM(float sliderValue) 
    {
        // valeur logarythmique de base 10 pour les DB
        myAudioMixer.audioMixer.SetFloat("BGMVolume", Mathf.Log10(sliderValue) * 20);
    }

    public void SetVolumeSFX(float sliderValue)
    {
        // valeur logarythmique de base 10 pour les DB
        myAudioMixer.audioMixer.SetFloat("SFXVolume", Mathf.Log10(sliderValue) * 20);
    }
}
