using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class IngameSettingPanel : MonoBehaviour
{

    public GameObject ingameSettingPanel;

    public GameObject bgmOnBtn;
    public GameObject bgmOffBtn;
    public GameObject sfxOnBtn;
    public GameObject sfxOffBtn;




    // Start is called before the first frame update
    void Start()
    {
        if (soundManager.I.GetComponent<AudioSource>().mute == false)
        {

        }



    }

    // Update is called once per frame
    void Update()
    {

    }

    public void KeepPlaying()
    {
        Time.timeScale = 1;
        ingameSettingPanel.SetActive(false);
    }

    public void retry()
    {
        GameObject.Find("ElementSpawner").GetComponent<ElementSpawner>().StopSpawning();
        Time.timeScale = 1;
        adsManager.I.adCounts += 1;
        adsManager.I.ShowInterstitialAd();
        SceneManager.LoadScene("MainScene");
    }

    public void toMain()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("IntroScene");
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

  

