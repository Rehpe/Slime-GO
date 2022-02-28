using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class soundManager : MonoBehaviour
{

    public static soundManager I;
 
    AudioSource audioSource;

    public float currentBgmVolume = 1f;

    public AudioClip Main;
    public AudioClip Shop;
    public AudioClip Play;

    
    private void Awake()
    {
        if(I == null)
        {
            I = this;
        }
        var obj = FindObjectsOfType<soundManager>();
        if (obj.Length == 1)
        {
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        currentBgmVolume = PlayerPrefs.GetFloat("currentBgmVolume", 1f);
        audioSource.volume = currentBgmVolume;

    }

    // Update is called once per frame
    void Update()
    {
      
    }


    public void PlayBgm(string action)
    {
        switch (action)
        {
            case "Stop":
                audioSource.Stop();
                break;

            case "MainScene":
                audioSource.Stop();
                audioSource.clip = Main;
                audioSource.Play();
                break;

            case "ShopScene":
                audioSource.Stop();
                audioSource.clip = Shop;
                audioSource.Play();
                break;

            case "PlayScene":
                audioSource.Stop();
                audioSource.clip = Play;
                audioSource.Play();
                break;
        }
    }
}

