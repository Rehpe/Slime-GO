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
        Debug.Log("�ε� �Ϸ�");

        //���� �������� �رݵǾ��ٸ�
        if (dataManager.I.ItemDoubleisUnlocked == true)
        {
            BeforeDoubleBuyBtn.SetActive(false); //���Ź�ư ��Ȱ��ȭ
            AfterDoubleBuyBtn.SetActive(true); //���ſϷ� ��ư Ȱ��ȭ
        }
        else //�رݵ��� �ʾҴٸ�
        {
            BeforeDoubleBuyBtn.SetActive(true); //���Ź�ư Ȱ��ȭ
            AfterDoubleBuyBtn.SetActive(false);  //���ſϷ� ��ư ��Ȱ��ȭ
        }

        //Ʈ���� �������� �رݵǾ��ٸ�
        if (dataManager.I.ItemTripleisUnlocked == true)
        {
            BeforeTripleBuyBtn.SetActive(false); //���Ź�ư ��Ȱ��ȭ
            AfterTripleBuyBtn.SetActive(true); //���ſϷ� ��ư Ȱ��ȭ
        }
        else //�رݵ��� �ʾҴٸ�
        {
            BeforeTripleBuyBtn.SetActive(true); //���Ź�ư Ȱ��ȭ
            AfterTripleBuyBtn.SetActive(false);  //���ſϷ� ��ư ��Ȱ��ȭ
        }

        //���� �������� �رݵǾ��ٸ�
        if (dataManager.I.ItemGetCoinisUnlocked == true)
        {
            BeforeGetCoinBuyBtn.SetActive(false); //���Ź�ư ��Ȱ��ȭ
            AfterGetCoinBuyBtn.SetActive(true); //���ſϷ� ��ư Ȱ��ȭ
        }
        else //�رݵ��� �ʾҴٸ�
        {
            BeforeGetCoinBuyBtn.SetActive(true); //���Ź�ư Ȱ��ȭ
            AfterGetCoinBuyBtn.SetActive(false);  //���ſϷ� ��ư ��Ȱ��ȭ
        }

        //ü��ȸ��(��)�������� �رݵǾ��ٸ�
        if (dataManager.I.ItemHpUpSmallisUnlocked == true)
        {
            BeforeHpUpSmallBuyBtn.SetActive(false); //���Ź�ư ��Ȱ��ȭ
            AfterHpUpSmallBuyBtn.SetActive(true); //���ſϷ� ��ư Ȱ��ȭ
        }
        else //�رݵ��� �ʾҴٸ�
        {
            BeforeHpUpSmallBuyBtn.SetActive(true); //���Ź�ư Ȱ��ȭ
            AfterHpUpSmallBuyBtn.SetActive(false);  //���ſϷ� ��ư ��Ȱ��ȭ
        }

        //ü��ȸ��(��)�������� �رݵǾ��ٸ�
        if (dataManager.I.ItemHpUpBigisUnlocked == true)
        {
            BeforeHpUpBigBuyBtn.SetActive(false); //���Ź�ư ��Ȱ��ȭ
            AfterHpUpBigBuyBtn.SetActive(true); //���ſϷ� ��ư Ȱ��ȭ
        }
        else //�رݵ��� �ʾҴٸ�
        {
            BeforeHpUpBigBuyBtn.SetActive(true); //���Ź�ư Ȱ��ȭ
            AfterHpUpBigBuyBtn.SetActive(false);  //���ſϷ� ��ư ��Ȱ��ȭ
        }


        //���ǵ� �� �������� �رݵǾ��ٸ�
        if (dataManager.I.ItemSpeedUpisUnlocked == true)
        {
            BeforeSpeedUpBuyBtn.SetActive(false); //���Ź�ư ��Ȱ��ȭ
            AfterSpeedUpBuyBtn.SetActive(true); //���ſϷ� ��ư Ȱ��ȭ
        }
        else //�رݵ��� �ʾҴٸ�
        {
            BeforeSpeedUpBuyBtn.SetActive(true); //���Ź�ư Ȱ��ȭ
            AfterSpeedUpBuyBtn.SetActive(false);  //���ſϷ� ��ư ��Ȱ��ȭ
        }


    }

    // Update is called once per frame
    void Update()
    {
        PlayerCoinText.text = dataManager.I.PlayerCoin.ToString();
    }


    public void Double_ItemBuy() //Double ������ ���Ź�ư
    {
        int price = 300;//������ ����

        if (dataManager.I.PlayerCoin >= price) //���� �ݾ��� ������ ���ݺ��� ���ų� ���ٸ�
        {
            dataManager.I.PlayerCoin -= price; //������ ���ݸ�ŭ PlayerCoin ����

            Items Item_Double = Resources.Load<Items>("Prefabs/Items/Item[0]_Double"); //������ Ŭ������, �ر� Ȯ�ο� bool�� ����
            Item_Double.isUnlocked = true;
            dataManager.I.ItemDoubleisUnlocked = true;

            dataManager.I.SaveData(); //������ ����
            BeforeDoubleBuyBtn.SetActive(false);
            AfterDoubleBuyBtn.SetActive(true);
            sfxManager.I.PlaySfx("Unlock");
        }
        else if (dataManager.I.PlayerCoin < price)
        {
            Debug.Log("������ �����մϴ�!");
            NoCoinAlert.SetActive(true);
            sfxManager.I.PlaySfx("NoCoin");
        }
    }

    public void Triple_ItemBuy() //Triple ������ ���Ź�ư
    {
        int price = 1000;//������ ����

        if (dataManager.I.PlayerCoin >= price) //���� �ݾ��� ������ ���ݺ��� ���ų� ���ٸ�
        {
            dataManager.I.PlayerCoin -= price; //������ ���ݸ�ŭ PlayerCoin ����

            Items Item_Triple = Resources.Load<Items>("Prefabs/Items/Item[1]_Triple"); //������ Ŭ������, �ر� Ȯ�ο� bool�� ����
            Item_Triple.isUnlocked = true;
            dataManager.I.ItemTripleisUnlocked = true;

            dataManager.I.SaveData(); //������ ����
            BeforeTripleBuyBtn.SetActive(false);
            AfterTripleBuyBtn.SetActive(true);
            sfxManager.I.PlaySfx("Unlock");

        }
        else if (dataManager.I.PlayerCoin < price)
        {
            sfxManager.I.PlaySfx("NoCoin");
            Debug.Log("������ �����մϴ�!");
            NoCoinAlert.SetActive(true);
            
        }
    }

    public void GetCoin_ItemBuy() //GetCoin ������ ���Ź�ư
    {
        int price = 500;//������ ����

        if (dataManager.I.PlayerCoin >= price) //���� �ݾ��� ������ ���ݺ��� ���ų� ���ٸ�
        {
            dataManager.I.PlayerCoin -= price; //������ ���ݸ�ŭ PlayerCoin ����

            Items Item_GetCoin = Resources.Load<Items>("Prefabs/Items/Item[2]_GetCoin"); //������ Ŭ������, �ر� Ȯ�ο� bool�� ����
            Item_GetCoin.isUnlocked = true;
            dataManager.I.ItemGetCoinisUnlocked = true;

            dataManager.I.SaveData(); //������ ����
            BeforeGetCoinBuyBtn.SetActive(false);
            AfterGetCoinBuyBtn.SetActive(true);
            sfxManager.I.PlaySfx("Unlock");
        }
        else if (dataManager.I.PlayerCoin < price)
        {
            Debug.Log("������ �����մϴ�!");
            NoCoinAlert.SetActive(true);
            sfxManager.I.PlaySfx("NoCoin");
        }
    }


    public void HpUpSmall_ItemBuy() //ü��ȸ��(��) ������ ���Ź�ư
    {
        int price = 500;//������ ����

        if (dataManager.I.PlayerCoin >= price) //���� �ݾ��� ������ ���ݺ��� ���ų� ���ٸ�
        {
            dataManager.I.PlayerCoin -= price; //������ ���ݸ�ŭ PlayerCoin ����

            Items Item_HpUpSmall = Resources.Load<Items>("Prefabs/Items/Item[3]_HpUpSmall"); //������ Ŭ������, �ر� Ȯ�ο� bool�� ����
            Item_HpUpSmall.isUnlocked = true;
            dataManager.I.ItemHpUpSmallisUnlocked = true;

            dataManager.I.SaveData(); //������ ����
            BeforeHpUpSmallBuyBtn.SetActive(false);
            AfterHpUpSmallBuyBtn.SetActive(true);
            sfxManager.I.PlaySfx("Unlock");
        }
        else if (dataManager.I.PlayerCoin < price)
        {
            Debug.Log("������ �����մϴ�!");
            NoCoinAlert.SetActive(true);
            sfxManager.I.PlaySfx("NoCoin");
        }
    }

    public void HpUpBig_ItemBuy() //ü��ȸ��(��) ������ ���Ź�ư
    {
        int price = 1000;//������ ����

        if (dataManager.I.PlayerCoin >= price) //���� �ݾ��� ������ ���ݺ��� ���ų� ���ٸ�
        {
            dataManager.I.PlayerCoin -= price; //������ ���ݸ�ŭ PlayerCoin ����

            Items Item_HpUpBig = Resources.Load<Items>("Prefabs/Items/Item[4]_HpUpBig"); //������ Ŭ������, �ر� Ȯ�ο� bool�� ����
            Item_HpUpBig.isUnlocked = true;
            dataManager.I.ItemHpUpBigisUnlocked = true;

            dataManager.I.SaveData(); //������ ����
            BeforeHpUpBigBuyBtn.SetActive(false);
            AfterHpUpBigBuyBtn.SetActive(true);
            sfxManager.I.PlaySfx("Unlock");
        }
        else if (dataManager.I.PlayerCoin < price)
        {
            Debug.Log("������ �����մϴ�!");
            NoCoinAlert.SetActive(true);
            sfxManager.I.PlaySfx("NoCoin");
        }
    }


    public void SpeedUp_ItemBuy() //SpeedUp ������ ���Ź�ư
    {
        int price = 300;//������ ����

        if (dataManager.I.PlayerCoin >= price) //���� �ݾ��� ������ ���ݺ��� ���ų� ���ٸ�
        {
            dataManager.I.PlayerCoin -= price; //������ ���ݸ�ŭ PlayerCoin ����

            Items Item_SpeedUp = Resources.Load<Items>("Prefabs/Items/Item[5]_SpeedUp"); //������ Ŭ������, �ر� Ȯ�ο� bool�� ����
            Item_SpeedUp.isUnlocked = true;
            dataManager.I.ItemSpeedUpisUnlocked = true;

            dataManager.I.SaveData(); //������ ����
            BeforeSpeedUpBuyBtn.SetActive(false);
            AfterSpeedUpBuyBtn.SetActive(true);
            sfxManager.I.PlaySfx("Unlock");
        }
        else if (dataManager.I.PlayerCoin < price)
        {
            Debug.Log("������ �����մϴ�!");
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
