using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainVolumeSetting : MonoBehaviour
{

    public Slider bgmVolumeSlider;
    public Slider sfxVolumeSlider;

    
    public AudioSource BGMaudioSource;
    public AudioSource SFXaudioSource;




    void Start()
    {
        BGMaudioSource = soundManager.I.GetComponent<AudioSource>();
        SFXaudioSource = sfxManager.I.GetComponent<AudioSource>();

        bgmVolumeSlider.value = soundManager.I.currentBgmVolume;
        BGMaudioSource.volume = bgmVolumeSlider.value;
       
        sfxVolumeSlider.value = sfxManager.I.currentSfxVolume;
        SFXaudioSource.volume = sfxVolumeSlider.value;

    }

    // Update is called once per frame
    void Update()
    {
        bgmSlider();
        sfxSlider();
    }

    public void bgmSlider()
    {
        BGMaudioSource.volume = bgmVolumeSlider.value;

        soundManager.I.currentBgmVolume = bgmVolumeSlider.value;
        PlayerPrefs.SetFloat("currentBgmVolume", soundManager.I.currentBgmVolume);

    }

    public void sfxSlider()
    {
        SFXaudioSource.volume = sfxVolumeSlider.value;

        sfxManager.I.currentSfxVolume = sfxVolumeSlider.value;
        PlayerPrefs.SetFloat("currentSfxVolume", sfxManager.I.currentSfxVolume);

    }

    public void BGMBtnClick()
    {
        if (soundManager.I.GetComponent<AudioSource>().mute == false)
        {
            soundManager.I.GetComponent<AudioSource>().mute = true;
        }
        else
            soundManager.I.GetComponent<AudioSource>().mute = false;
    }

    public void SFXBtnClick()
    {
        if (sfxManager.I.GetComponent<AudioSource>().mute == false)
        {
            sfxManager.I.GetComponent<AudioSource>().mute = true;
        }
        else
            sfxManager.I.GetComponent<AudioSource>().mute = false;
    }
}
