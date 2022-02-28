using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class evolveManager : MonoBehaviour
{

 /*   public bool Fire2ndisUnlocked;
    public bool Water2ndisUnlocked;
    public bool Elec2ndisUnlocked;
    public bool Fire3rdisUnlocked;
    public bool Water3rdisUnlocked;
    public bool Elec3rdisUnlocked;*/

    public GameObject Fire2ndLockImg;
    public GameObject Fire3rdLockImg;
    public GameObject Water2ndLockImg;
    public GameObject Water3rdLockImg;
    public GameObject Elec2ndLockImg;
    public GameObject Elec3rdLockImg;

    public GameObject Fire2ndBuyPanel;
    public GameObject Water2ndBuyPanel;
    public GameObject Elec2ndBuyPanel;
    public GameObject Fire3rdBuyPanel;
    public GameObject Water3rdBuyPanel;
    public GameObject Elec3rdBuyPanel;

    public GameObject Fire1stUnlockedPanel;
    public GameObject Water1stUnlockedPanel;
    public GameObject Elec1stUnlockedPanel;
    public GameObject Fire2ndUnlockedPanel;
    public GameObject Water2ndUnlockedPanel;
    public GameObject Elec2ndUnlockedPanel;
    public GameObject Fire3rdUnlockedPanel;
    public GameObject Water3rdUnlockedPanel;
    public GameObject Elec3rdUnlockedPanel;

    public GameObject NoCoinAlert;
    public GameObject PreBuyAlert;

    private void Awake()
    {
        var obj = FindObjectsOfType<evolveManager>();
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
        dataManager.I.LoadData();
        Debug.Log("로드 완료");

        if (dataManager.I.Fire2ndisUnlocked == true) //불 원소 2차 진화 해금시
        {
            Fire2ndLockImg.SetActive(false);

        }
        else //해금되지 않았다면
        {
            Fire2ndLockImg.SetActive(true);
        }
            
        if (dataManager.I.Water2ndisUnlocked == true) //물 원소 2차 진화 해금시
        {
            Water2ndLockImg.SetActive(false);

        }
        else //해금되지 않았다면
        {
            Water2ndLockImg.SetActive(true);
        }

        if (dataManager.I.Elec2ndisUnlocked == true) //전기 원소 2차 진화 해금시
        {
            Elec2ndLockImg.SetActive(false);
        }
        else //해금되지 않았다면
        {
            Elec2ndLockImg.SetActive(true);

        }

        if (dataManager.I.Fire3rdisUnlocked == true) //불 원소 3차 진화 해금시
        {
            Fire3rdLockImg.SetActive(false);

        }
        else //해금되지 않았다면
        {
            Fire3rdLockImg.SetActive(true);
        }

        if (dataManager.I.Water3rdisUnlocked == true) // 물 원소 3차 진화 해금시
        {
            Water3rdLockImg.SetActive(false);
        }
        else //해금되지 않았다면
        {
            Water3rdLockImg.SetActive(true);
        }

        if (dataManager.I.Elec3rdisUnlocked == true) //전기 원소 3차 진화 해금시
        {
            Elec3rdLockImg.SetActive(false);
        }
        else //해금되지 않았다면
        {
            Elec3rdLockImg.SetActive(true);
        }

    } 
        
    // Update is called once per frame
    void Update()
    {

    }

    public void Fire2nd_EvolveBuy() //불 2차 진화 구매버튼
        {
            int price = 500; // 가격

            if (dataManager.I.PlayerCoin >= price) //소지 금액이 진화체 가격보다 많거나 같다면
            {
                dataManager.I.PlayerCoin -= price; //아이템 가격만큼 PlayerCoin 감소

                dataManager.I.Fire2ndisUnlocked = true; //해금 정보 바꾸고

                dataManager.I.SaveData(); //데이터 저장
                
                Fire2ndLockImg.SetActive(false); //잠금표시 사라짐

                Fire2ndUnlockedPanel.SetActive(true); //언락창 활성화
                Fire2ndBuyPanel.SetActive(false); //구매창 닫기
                sfxManager.I.PlaySfx("Unlock");
        }
            else if (dataManager.I.PlayerCoin < price)
            {
                sfxManager.I.PlaySfx("NoCoin");
                Debug.Log("코인이 부족합니다!");
                NoCoinAlert.SetActive(true);
                
        }
        }

    public void Water2nd_EvolveBuy() //물 2차 진화 구매버튼
    {
        int price = 500; // 가격

        if (dataManager.I.PlayerCoin >= price) //소지 금액이 진화체 가격보다 많거나 같다면
        {
            dataManager.I.PlayerCoin -= price; //아이템 가격만큼 PlayerCoin 감소

            dataManager.I.Water2ndisUnlocked = true; //해금 정보 바꾸고

            dataManager.I.SaveData(); //데이터 저장

            Water2ndLockImg.SetActive(false); //잠금표시 사라짐
            Water2ndUnlockedPanel.SetActive(true);
            Water2ndBuyPanel.SetActive(false);
            sfxManager.I.PlaySfx("Unlock");

        }
        else if (dataManager.I.PlayerCoin < price)
        {
            sfxManager.I.PlaySfx("NoCoin");
            Debug.Log("코인이 부족합니다!");
            NoCoinAlert.SetActive(true);
            
        }
    }

    public void Elec2nd_EvolveBuy() //전기 2차 진화 구매버튼
    {
        int price = 500; // 가격

        if (dataManager.I.PlayerCoin >= price) //소지 금액이 진화체 가격보다 많거나 같다면
        {
            dataManager.I.PlayerCoin -= price; //아이템 가격만큼 PlayerCoin 감소

            dataManager.I.Elec2ndisUnlocked = true; //해금 정보 바꾸고

            dataManager.I.SaveData(); //데이터 저장

            Elec2ndLockImg.SetActive(false); //잠금표시 사라짐
            Elec2ndUnlockedPanel.SetActive(true);
            Elec2ndBuyPanel.SetActive(false);
            sfxManager.I.PlaySfx("Unlock");

        }
        else if (dataManager.I.PlayerCoin < price)
        {
            sfxManager.I.PlaySfx("NoCoin");
            Debug.Log("코인이 부족합니다!");
            NoCoinAlert.SetActive(true);
            
        }
    }

    public void Fire3rd_EvolveBuy() //불 3차 진화 구매버튼
    {
        int price = 1500; // 가격

        if (dataManager.I.Fire2ndisUnlocked == false) // 불 2차 진화체를 구매하지 않았다면
        {
            PreBuyAlert.SetActive(true);
        }
        else
        {
            if (dataManager.I.PlayerCoin >= price) //소지 금액이 진화체 가격보다 많거나 같다면
            {
                dataManager.I.PlayerCoin -= price; //아이템 가격만큼 PlayerCoin 감소

                dataManager.I.Fire3rdisUnlocked = true; //해금 정보 바꾸고

                dataManager.I.SaveData(); //데이터 저장

                Fire3rdLockImg.SetActive(false); //잠금표시 사라짐
                Fire3rdUnlockedPanel.SetActive(true);
                Fire3rdBuyPanel.SetActive(false);
                sfxManager.I.PlaySfx("Unlock");
            }
            else if (dataManager.I.PlayerCoin < price)
            {
                sfxManager.I.PlaySfx("NoCoin");
                Debug.Log("코인이 부족합니다!");
                NoCoinAlert.SetActive(true);
                
            }
        }
    }

    public void Water3rd_EvolveBuy() //물 3차 진화 구매버튼
    {
        int price = 1500; // 가격

        if (dataManager.I.Water2ndisUnlocked == false) // 물 2차 진화체를 구매하지 않았다면
        {
            PreBuyAlert.SetActive(true);
        }
        else
        {

            if (dataManager.I.PlayerCoin >= price) //소지 금액이 진화체 가격보다 많거나 같다면
            {
                dataManager.I.PlayerCoin -= price; //아이템 가격만큼 PlayerCoin 감소

                dataManager.I.Water3rdisUnlocked = true; //해금 정보 바꾸고

                dataManager.I.SaveData(); //데이터 저장

                Water3rdLockImg.SetActive(false); //잠금표시 사라짐
                Water3rdUnlockedPanel.SetActive(true);
                Water3rdBuyPanel.SetActive(false);
                sfxManager.I.PlaySfx("Unlock");

            }
            else if (dataManager.I.PlayerCoin < price)
            {
                sfxManager.I.PlaySfx("NoCoin");
                Debug.Log("코인이 부족합니다!");
                NoCoinAlert.SetActive(true);
                
            }
        }
    }

    public void Elec3rd_EvolveBuy() //전기 3차 진화 구매버튼
    {
        int price = 1500; // 가격


        if (dataManager.I.Elec2ndisUnlocked == false) // 전기 2차 진화체를 구매하지 않았다면
        {
            PreBuyAlert.SetActive(true);
        }
        else
        {
            if (dataManager.I.PlayerCoin >= price) //소지 금액이 진화체 가격보다 많거나 같다면
            {
                dataManager.I.PlayerCoin -= price; //아이템 가격만큼 PlayerCoin 감소

                dataManager.I.Elec3rdisUnlocked = true; //해금 정보 바꾸고

                dataManager.I.SaveData(); //데이터 저장

                Elec3rdLockImg.SetActive(false); //잠금표시 사라짐
                Elec3rdUnlockedPanel.SetActive(true);
                Elec3rdBuyPanel.SetActive(false);
                sfxManager.I.PlaySfx("Unlock");

            }
            else if (dataManager.I.PlayerCoin < price)
            {
                sfxManager.I.PlaySfx("NoCoin");
                Debug.Log("코인이 부족합니다!");
                NoCoinAlert.SetActive(true);
                
            }
        }
    }


    public void clickFire1stPanel()
    {
        sfxManager.I.PlaySfx("Unlock");
        Fire1stUnlockedPanel.SetActive(true);
        
    }
    public void clickWater1stPanel()
    {
        sfxManager.I.PlaySfx("Unlock");
        Water1stUnlockedPanel.SetActive(true);
        
    }
    public void clickElec1stPanel()
    {
        sfxManager.I.PlaySfx("Unlock");
        Elec1stUnlockedPanel.SetActive(true);
       
    }
    public void clickFire2ndPanel()
    {
        if (dataManager.I.Fire2ndisUnlocked == false) // 불 2차 해금 안됐다면
        {
            Fire2ndBuyPanel.SetActive(true); //불 2차 구매패널 열기
        }
        else //해금됐다면
        {
            sfxManager.I.PlaySfx("Unlock");
            Fire2ndUnlockedPanel.SetActive(true); //불 2차 해금 패널 열기
        }
    }
    public void clickWater2ndPanel()
    {
        if (dataManager.I.Water2ndisUnlocked == false) // 물 2차 해금됐다면
        {
            Water2ndBuyPanel.SetActive(true); //물 2차 구매패널 열기
        }
        else
        {
            sfxManager.I.PlaySfx("Unlock");
            Water2ndUnlockedPanel.SetActive(true); //물 2차 해금 패널 열기
           
        }
    }
        
    public void clickElec2ndPanel()
    {
        if (dataManager.I.Elec2ndisUnlocked == false) // 전기 2차 해금됐다면
        {
            Elec2ndBuyPanel.SetActive(true); //전기 2차 구매패널 열기
        }
        else
        {
            sfxManager.I.PlaySfx("Unlock");
            Elec2ndUnlockedPanel.SetActive(true); //전기 2차 해금 패널 열기
            
        }
    }
    public void clickFire3rdPanel()
    {
        if (dataManager.I.Fire3rdisUnlocked == false) // 불 3차 해금됐다면
        {
            Fire3rdBuyPanel.SetActive(true); //불 3차 구매패널 열기
        }
        else
        {
            Fire3rdUnlockedPanel.SetActive(true); //불 3차 해금 패널 열기
            sfxManager.I.PlaySfx("Unlock");
        }
    }
    public void clickWater3rdPanel()
    {
        if (dataManager.I.Water3rdisUnlocked == false) // 물 3차 해금됐다면
        {
            Water3rdBuyPanel.SetActive(true); //물 3차 구매패널 열기
        }
        else
        {
            Water3rdUnlockedPanel.SetActive(true); //물 3차 해금 패널 열기
            sfxManager.I.PlaySfx("Unlock");
        }
    }
    public void clickElec3rdPanel()
    {
        if (dataManager.I.Elec3rdisUnlocked == false) // 전기 3차 해금됐다면
        {
            Elec3rdBuyPanel.SetActive(true); //전기 3차 구매패널 열기
        }
        else
        {
            Elec3rdUnlockedPanel.SetActive(true); //전기 3차 해금 패널 열기
            sfxManager.I.PlaySfx("Unlock");
        }
    }










}

