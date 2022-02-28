using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class itemManager : MonoBehaviour
{
    public Items[] AllItems;

    public int PlayerCoin;

/*    public bool ItemDoubleisUnlocked;
    public bool ItemTripleisUnlocked;
    public bool ItemGetCoinisUnlocked;
    public bool ItemHpUpSmallisUnlocked;
    public bool ItemHpUpBigisUnlocked;
    public bool ItemSpeedUpisUnlocked;*/

    public Text PlayerCoinText;


    public GameObject BeforeDoubleBuyBtn;
    public GameObject AfterDoubleBuyBtn;

    public GameObject BeforeTripleBuyBtn;
    public GameObject AfterTripleBuyBtn;

    public GameObject BeforeGetCoinBuyBtn;
    public GameObject AfterGetCoinBuyBtn;

    public GameObject BeforeHpUpSmallBuyBtn;
    public GameObject AfterHpUpSmallBuyBtn;

    public GameObject BeforeHpUpBigBuyBtn;
    public GameObject AfterHpUpBigBuyBtn;

    public GameObject BeforeSpeedUpBuyBtn;
    public GameObject AfterSpeedUpBuyBtn;

    public GameObject NoCoinAlert;

    private void Awake()
    {  
        var obj = FindObjectsOfType<itemManager>();
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

        //더블 아이템이 해금되었다면
        if (dataManager.I.ItemDoubleisUnlocked == true)
        {
            BeforeDoubleBuyBtn.SetActive(false); //구매버튼 비활성화
            AfterDoubleBuyBtn.SetActive(true); //구매완료 버튼 활성화
        }
        else //해금되지 않았다면
        {
            BeforeDoubleBuyBtn.SetActive(true); //구매버튼 활성화
            AfterDoubleBuyBtn.SetActive(false);  //구매완료 버튼 비활성화
        }

        //트리플 아이템이 해금되었다면
        if (dataManager.I.ItemTripleisUnlocked == true)
        {
            BeforeTripleBuyBtn.SetActive(false); //구매버튼 비활성화
            AfterTripleBuyBtn.SetActive(true); //구매완료 버튼 활성화
        }
        else //해금되지 않았다면
        {
            BeforeTripleBuyBtn.SetActive(true); //구매버튼 활성화
            AfterTripleBuyBtn.SetActive(false);  //구매완료 버튼 비활성화
        }

        //코인 아이템이 해금되었다면
        if (dataManager.I.ItemGetCoinisUnlocked == true)
        {
            BeforeGetCoinBuyBtn.SetActive(false); //구매버튼 비활성화
            AfterGetCoinBuyBtn.SetActive(true); //구매완료 버튼 활성화
        }
        else //해금되지 않았다면
        {
            BeforeGetCoinBuyBtn.SetActive(true); //구매버튼 활성화
            AfterGetCoinBuyBtn.SetActive(false);  //구매완료 버튼 비활성화
        }

        //체력회복(소)아이템이 해금되었다면
        if (dataManager.I.ItemHpUpSmallisUnlocked == true)
        {
            BeforeHpUpSmallBuyBtn.SetActive(false); //구매버튼 비활성화
            AfterHpUpSmallBuyBtn.SetActive(true); //구매완료 버튼 활성화
        }
        else //해금되지 않았다면
        {
            BeforeHpUpSmallBuyBtn.SetActive(true); //구매버튼 활성화
            AfterHpUpSmallBuyBtn.SetActive(false);  //구매완료 버튼 비활성화
        }

        //체력회복(대)아이템이 해금되었다면
        if (dataManager.I.ItemHpUpBigisUnlocked == true)
        {
            BeforeHpUpBigBuyBtn.SetActive(false); //구매버튼 비활성화
            AfterHpUpBigBuyBtn.SetActive(true); //구매완료 버튼 활성화
        }
        else //해금되지 않았다면
        {
            BeforeHpUpBigBuyBtn.SetActive(true); //구매버튼 활성화
            AfterHpUpBigBuyBtn.SetActive(false);  //구매완료 버튼 비활성화
        }


        //스피드 업 아이템이 해금되었다면
        if (dataManager.I.ItemSpeedUpisUnlocked == true)
        {
            BeforeSpeedUpBuyBtn.SetActive(false); //구매버튼 비활성화
            AfterSpeedUpBuyBtn.SetActive(true); //구매완료 버튼 활성화
        }
        else //해금되지 않았다면
        {
            BeforeSpeedUpBuyBtn.SetActive(true); //구매버튼 활성화
            AfterSpeedUpBuyBtn.SetActive(false);  //구매완료 버튼 비활성화
        }


    }

    // Update is called once per frame
    void Update()
    {
        PlayerCoinText.text = dataManager.I.PlayerCoin.ToString();
    }


    public void Double_ItemBuy() //Double 아이템 구매버튼
    {
        int price = 300;//아이템 가격

        if (dataManager.I.PlayerCoin >= price) //소지 금액이 아이템 가격보다 많거나 같다면
        {
            dataManager.I.PlayerCoin -= price; //아이템 가격만큼 PlayerCoin 감소

            Items Item_Double = Resources.Load<Items>("Prefabs/Items/Item[0]_Double"); //아이템 클래스값, 해금 확인용 bool값 변경
            Item_Double.isUnlocked = true;
            dataManager.I.ItemDoubleisUnlocked = true;

            dataManager.I.SaveData(); //데이터 저장
            BeforeDoubleBuyBtn.SetActive(false);
            AfterDoubleBuyBtn.SetActive(true);
            sfxManager.I.PlaySfx("Unlock");
        }
        else if (dataManager.I.PlayerCoin < price)
        {
            Debug.Log("코인이 부족합니다!");
            NoCoinAlert.SetActive(true);
            sfxManager.I.PlaySfx("NoCoin");
        }
    }

    public void Triple_ItemBuy() //Triple 아이템 구매버튼
    {
        int price = 1000;//아이템 가격

        if (dataManager.I.PlayerCoin >= price) //소지 금액이 아이템 가격보다 많거나 같다면
        {
            dataManager.I.PlayerCoin -= price; //아이템 가격만큼 PlayerCoin 감소

            Items Item_Triple = Resources.Load<Items>("Prefabs/Items/Item[1]_Triple"); //아이템 클래스값, 해금 확인용 bool값 변경
            Item_Triple.isUnlocked = true;
            dataManager.I.ItemTripleisUnlocked = true;

            dataManager.I.SaveData(); //데이터 저장
            BeforeTripleBuyBtn.SetActive(false);
            AfterTripleBuyBtn.SetActive(true);
            sfxManager.I.PlaySfx("Unlock");

        }
        else if (dataManager.I.PlayerCoin < price)
        {
            sfxManager.I.PlaySfx("NoCoin");
            Debug.Log("코인이 부족합니다!");
            NoCoinAlert.SetActive(true);
            
        }
    }

    public void GetCoin_ItemBuy() //GetCoin 아이템 구매버튼
    {
        int price = 500;//아이템 가격

        if (dataManager.I.PlayerCoin >= price) //소지 금액이 아이템 가격보다 많거나 같다면
        {
            dataManager.I.PlayerCoin -= price; //아이템 가격만큼 PlayerCoin 감소

            Items Item_GetCoin = Resources.Load<Items>("Prefabs/Items/Item[2]_GetCoin"); //아이템 클래스값, 해금 확인용 bool값 변경
            Item_GetCoin.isUnlocked = true;
            dataManager.I.ItemGetCoinisUnlocked = true;

            dataManager.I.SaveData(); //데이터 저장
            BeforeGetCoinBuyBtn.SetActive(false);
            AfterGetCoinBuyBtn.SetActive(true);
            sfxManager.I.PlaySfx("Unlock");
        }
        else if (dataManager.I.PlayerCoin < price)
        {
            Debug.Log("코인이 부족합니다!");
            NoCoinAlert.SetActive(true);
            sfxManager.I.PlaySfx("NoCoin");
        }
    }


    public void HpUpSmall_ItemBuy() //체력회복(소) 아이템 구매버튼
    {
        int price = 500;//아이템 가격

        if (dataManager.I.PlayerCoin >= price) //소지 금액이 아이템 가격보다 많거나 같다면
        {
            dataManager.I.PlayerCoin -= price; //아이템 가격만큼 PlayerCoin 감소

            Items Item_HpUpSmall = Resources.Load<Items>("Prefabs/Items/Item[3]_HpUpSmall"); //아이템 클래스값, 해금 확인용 bool값 변경
            Item_HpUpSmall.isUnlocked = true;
            dataManager.I.ItemHpUpSmallisUnlocked = true;

            dataManager.I.SaveData(); //데이터 저장
            BeforeHpUpSmallBuyBtn.SetActive(false);
            AfterHpUpSmallBuyBtn.SetActive(true);
            sfxManager.I.PlaySfx("Unlock");
        }
        else if (dataManager.I.PlayerCoin < price)
        {
            Debug.Log("코인이 부족합니다!");
            NoCoinAlert.SetActive(true);
            sfxManager.I.PlaySfx("NoCoin");
        }
    }

    public void HpUpBig_ItemBuy() //체력회복(대) 아이템 구매버튼
    {
        int price = 1000;//아이템 가격

        if (dataManager.I.PlayerCoin >= price) //소지 금액이 아이템 가격보다 많거나 같다면
        {
            dataManager.I.PlayerCoin -= price; //아이템 가격만큼 PlayerCoin 감소

            Items Item_HpUpBig = Resources.Load<Items>("Prefabs/Items/Item[4]_HpUpBig"); //아이템 클래스값, 해금 확인용 bool값 변경
            Item_HpUpBig.isUnlocked = true;
            dataManager.I.ItemHpUpBigisUnlocked = true;

            dataManager.I.SaveData(); //데이터 저장
            BeforeHpUpBigBuyBtn.SetActive(false);
            AfterHpUpBigBuyBtn.SetActive(true);
            sfxManager.I.PlaySfx("Unlock");
        }
        else if (dataManager.I.PlayerCoin < price)
        {
            Debug.Log("코인이 부족합니다!");
            NoCoinAlert.SetActive(true);
            sfxManager.I.PlaySfx("NoCoin");
        }
    }


    public void SpeedUp_ItemBuy() //SpeedUp 아이템 구매버튼
    {
        int price = 300;//아이템 가격

        if (dataManager.I.PlayerCoin >= price) //소지 금액이 아이템 가격보다 많거나 같다면
        {
            dataManager.I.PlayerCoin -= price; //아이템 가격만큼 PlayerCoin 감소

            Items Item_SpeedUp = Resources.Load<Items>("Prefabs/Items/Item[5]_SpeedUp"); //아이템 클래스값, 해금 확인용 bool값 변경
            Item_SpeedUp.isUnlocked = true;
            dataManager.I.ItemSpeedUpisUnlocked = true;

            dataManager.I.SaveData(); //데이터 저장
            BeforeSpeedUpBuyBtn.SetActive(false);
            AfterSpeedUpBuyBtn.SetActive(true);
            sfxManager.I.PlaySfx("Unlock");
        }
        else if (dataManager.I.PlayerCoin < price)
        {
            Debug.Log("코인이 부족합니다!");
            NoCoinAlert.SetActive(true);
            sfxManager.I.PlaySfx("NoCoin");
        }
    }

        public void OnNoCoinAlertBtnClick()
    {
        NoCoinAlert.SetActive(false);
        sfxManager.I.PlaySfx("ButtonClick");
    }

    public void ExitShop()
    {
        sfxManager.I.PlaySfx("ButtonClick");
        SceneManager.LoadScene("IntroScene");
    }

}
