using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class sfxManager : MonoBehaviour
{
    public static sfxManager I;

    AudioSource audioSource;

    public float currentSfxVolume = 1f;

    public AudioClip PlayerTouch;
    public AudioClip EatElement;
    public AudioClip EatMinusElement;
    public AudioClip EatItem;
    public AudioClip GameOver;
    public AudioClip ButtonClick;
    public AudioClip Unlock;
    public AudioClip Purchase;
    public AudioClip ExitCancle;
    public AudioClip Evolving;
    public AudioClip AfterEvolve;
    public AudioClip NoCoin;
    public AudioClip Combo;


    // Start is called before the first frame update
    private void Awake()
    {
   
        if (I == null)
        {
            I = this;
        }
        var obj = FindObjectsOfType<sfxManager>();
        if (obj.Length == 1)
        {
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }


    private void Start()
    {
        audioSource = GetComponent<AudioSource>();

        currentSfxVolume = PlayerPrefs.GetFloat("currentSfxVolume", 1f);
        audioSource.volume = currentSfxVolume;

    }
    // Update is called once per frame
    void Update()
    {
        
    }


    public void PlaySfx(string action)
    {
        switch (action)
        {
            case "ButtonClick":
                audioSource.PlayOneShot(ButtonClick);
                break;

            case "PlayerTouch":
                audioSource.PlayOneShot(PlayerTouch);
                break;

            case "EatElement":
                audioSource.PlayOneShot(EatElement);
                break;

            case "EatItem":
                audioSource.PlayOneShot(EatItem);
                break;

            case "EatMinusElement":
                audioSource.PlayOneShot(EatMinusElement);
                break;

            case "GameOver":
                audioSource.PlayOneShot(GameOver);
                break;

            case "Evolving":
                audioSource.PlayOneShot(Evolving);
                break;

            case "AfterEvolve":
                audioSource.PlayOneShot(AfterEvolve);
                break;

            case "ExitCancle":
                audioSource.PlayOneShot(ExitCancle);
                break;

            case "NoCoin":
                audioSource.PlayOneShot(NoCoin);
                break;

            case "Combo":
                audioSource.PlayOneShot(Combo);
                break;

            case "Unlock":
                audioSource.PlayOneShot(Unlock);
                break;




        }
    }
}
