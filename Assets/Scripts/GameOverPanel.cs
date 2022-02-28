using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class GameOverPanel : MonoBehaviour
{
    public GameObject GamePlayScene;
    public GameObject ShopScene;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
     

   
    public void retry()
    {
        adsManager.I.adCounts += 1;
        adsManager.I.ShowInterstitialAd();
        gameManager.I.retry();
    }

    public void toShop()
    {
        adsManager.I.adCounts += 1;
        adsManager.I.ShowInterstitialAd();
        Time.timeScale = 1;
        gameManager.I.toShop();
    }

    public void toMain()
    {
        adsManager.I.adCounts += 1;
        adsManager.I.ShowInterstitialAd();
        Time.timeScale = 1;
        gameManager.I.toMain();
    }
    
    public void WatchAdAndGetCoinX2()
    {
        adsManager.I.ShowRewardAd();
        dataManager.I.PlayerCoin += gameManager.I.totalCoin;
        gameManager.I.totalCoin *= 2;
        gameManager.I.coinText.text = gameManager.I.totalCoin.ToString();
        dataManager.I.SaveData();


        /*gameManager.I.retry();*/
    }
}

