using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneMoveManager : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        soundManager.I.PlayBgm("MainScene");

    }

    // Update is called once per frame
    void Update()
    {
        if (Application.platform == RuntimePlatform.Android)

        {

            if (Input.GetKey(KeyCode.Escape))

            {

                 Application.Quit();

            }

        }
    }

    public void gameStart()
    {
        Debug.Log("to the main scene");
        SceneManager.LoadScene("MainScene");
    }

    public void toShop()
    {
        SceneManager.LoadScene("ShopScene");
    }

   }
