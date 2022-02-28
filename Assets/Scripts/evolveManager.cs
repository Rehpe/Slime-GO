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
        Debug.Log("�ε� �Ϸ�");

        if (dataManager.I.Fire2ndisUnlocked == true) //�� ���� 2�� ��ȭ �رݽ�
        {
            Fire2ndLockImg.SetActive(false);

        }
        else //�رݵ��� �ʾҴٸ�
        {
            Fire2ndLockImg.SetActive(true);
        }
            
        if (dataManager.I.Water2ndisUnlocked == true) //�� ���� 2�� ��ȭ �رݽ�
        {
            Water2ndLockImg.SetActive(false);

        }
        else //�رݵ��� �ʾҴٸ�
        {
            Water2ndLockImg.SetActive(true);
        }

        if (dataManager.I.Elec2ndisUnlocked == true) //���� ���� 2�� ��ȭ �رݽ�
        {
            Elec2ndLockImg.SetActive(false);
        }
        else //�رݵ��� �ʾҴٸ�
        {
            Elec2ndLockImg.SetActive(true);

        }

        if (dataManager.I.Fire3rdisUnlocked == true) //�� ���� 3�� ��ȭ �رݽ�
        {
            Fire3rdLockImg.SetActive(false);

        }
        else //�رݵ��� �ʾҴٸ�
        {
            Fire3rdLockImg.SetActive(true);
        }

        if (dataManager.I.Water3rdisUnlocked == true) // �� ���� 3�� ��ȭ �رݽ�
        {
            Water3rdLockImg.SetActive(false);
        }
        else //�رݵ��� �ʾҴٸ�
        {
            Water3rdLockImg.SetActive(true);
        }

        if (dataManager.I.Elec3rdisUnlocked == true) //���� ���� 3�� ��ȭ �رݽ�
        {
            Elec3rdLockImg.SetActive(false);
        }
        else //�رݵ��� �ʾҴٸ�
        {
            Elec3rdLockImg.SetActive(true);
        }

    } 
        
    // Update is called once per frame
    void Update()
    {

    }

    public void Fire2nd_EvolveBuy() //�� 2�� ��ȭ ���Ź�ư
        {
            int price = 500; // ����

            if (dataManager.I.PlayerCoin >= price) //���� �ݾ��� ��ȭü ���ݺ��� ���ų� ���ٸ�
            {
                dataManager.I.PlayerCoin -= price; //������ ���ݸ�ŭ PlayerCoin ����

                dataManager.I.Fire2ndisUnlocked = true; //�ر� ���� �ٲٰ�

                dataManager.I.SaveData(); //������ ����
                
                Fire2ndLockImg.SetActive(false); //���ǥ�� �����

                Fire2ndUnlockedPanel.SetActive(true); //���â Ȱ��ȭ
                Fire2ndBuyPanel.SetActive(false); //����â �ݱ�
                sfxManager.I.PlaySfx("Unlock");
        }
            else if (dataManager.I.PlayerCoin < price)
            {
                sfxManager.I.PlaySfx("NoCoin");
                Debug.Log("������ �����մϴ�!");
                NoCoinAlert.SetActive(true);
                
        }
        }

    public void Water2nd_EvolveBuy() //�� 2�� ��ȭ ���Ź�ư
    {
        int price = 500; // ����

        if (dataManager.I.PlayerCoin >= price) //���� �ݾ��� ��ȭü ���ݺ��� ���ų� ���ٸ�
        {
            dataManager.I.PlayerCoin -= price; //������ ���ݸ�ŭ PlayerCoin ����

            dataManager.I.Water2ndisUnlocked = true; //�ر� ���� �ٲٰ�

            dataManager.I.SaveData(); //������ ����

            Water2ndLockImg.SetActive(false); //���ǥ�� �����
            Water2ndUnlockedPanel.SetActive(true);
            Water2ndBuyPanel.SetActive(false);
            sfxManager.I.PlaySfx("Unlock");

        }
        else if (dataManager.I.PlayerCoin < price)
        {
            sfxManager.I.PlaySfx("NoCoin");
            Debug.Log("������ �����մϴ�!");
            NoCoinAlert.SetActive(true);
            
        }
    }

    public void Elec2nd_EvolveBuy() //���� 2�� ��ȭ ���Ź�ư
    {
        int price = 500; // ����

        if (dataManager.I.PlayerCoin >= price) //���� �ݾ��� ��ȭü ���ݺ��� ���ų� ���ٸ�
        {
            dataManager.I.PlayerCoin -= price; //������ ���ݸ�ŭ PlayerCoin ����

            dataManager.I.Elec2ndisUnlocked = true; //�ر� ���� �ٲٰ�

            dataManager.I.SaveData(); //������ ����

            Elec2ndLockImg.SetActive(false); //���ǥ�� �����
            Elec2ndUnlockedPanel.SetActive(true);
            Elec2ndBuyPanel.SetActive(false);
            sfxManager.I.PlaySfx("Unlock");

        }
        else if (dataManager.I.PlayerCoin < price)
        {
            sfxManager.I.PlaySfx("NoCoin");
            Debug.Log("������ �����մϴ�!");
            NoCoinAlert.SetActive(true);
            
        }
    }

    public void Fire3rd_EvolveBuy() //�� 3�� ��ȭ ���Ź�ư
    {
        int price = 1500; // ����

        if (dataManager.I.Fire2ndisUnlocked == false) // �� 2�� ��ȭü�� �������� �ʾҴٸ�
        {
            PreBuyAlert.SetActive(true);
        }
        else
        {
            if (dataManager.I.PlayerCoin >= price) //���� �ݾ��� ��ȭü ���ݺ��� ���ų� ���ٸ�
            {
                dataManager.I.PlayerCoin -= price; //������ ���ݸ�ŭ PlayerCoin ����

                dataManager.I.Fire3rdisUnlocked = true; //�ر� ���� �ٲٰ�

                dataManager.I.SaveData(); //������ ����

                Fire3rdLockImg.SetActive(false); //���ǥ�� �����
                Fire3rdUnlockedPanel.SetActive(true);
                Fire3rdBuyPanel.SetActive(false);
                sfxManager.I.PlaySfx("Unlock");
            }
            else if (dataManager.I.PlayerCoin < price)
            {
                sfxManager.I.PlaySfx("NoCoin");
                Debug.Log("������ �����մϴ�!");
                NoCoinAlert.SetActive(true);
                
            }
        }
    }

    public void Water3rd_EvolveBuy() //�� 3�� ��ȭ ���Ź�ư
    {
        int price = 1500; // ����

        if (dataManager.I.Water2ndisUnlocked == false) // �� 2�� ��ȭü�� �������� �ʾҴٸ�
        {
            PreBuyAlert.SetActive(true);
        }
        else
        {

            if (dataManager.I.PlayerCoin >= price) //���� �ݾ��� ��ȭü ���ݺ��� ���ų� ���ٸ�
            {
                dataManager.I.PlayerCoin -= price; //������ ���ݸ�ŭ PlayerCoin ����

                dataManager.I.Water3rdisUnlocked = true; //�ر� ���� �ٲٰ�

                dataManager.I.SaveData(); //������ ����

                Water3rdLockImg.SetActive(false); //���ǥ�� �����
                Water3rdUnlockedPanel.SetActive(true);
                Water3rdBuyPanel.SetActive(false);
                sfxManager.I.PlaySfx("Unlock");

            }
            else if (dataManager.I.PlayerCoin < price)
            {
                sfxManager.I.PlaySfx("NoCoin");
                Debug.Log("������ �����մϴ�!");
                NoCoinAlert.SetActive(true);
                
            }
        }
    }

    public void Elec3rd_EvolveBuy() //���� 3�� ��ȭ ���Ź�ư
    {
        int price = 1500; // ����


        if (dataManager.I.Elec2ndisUnlocked == false) // ���� 2�� ��ȭü�� �������� �ʾҴٸ�
        {
            PreBuyAlert.SetActive(true);
        }
        else
        {
            if (dataManager.I.PlayerCoin >= price) //���� �ݾ��� ��ȭü ���ݺ��� ���ų� ���ٸ�
            {
                dataManager.I.PlayerCoin -= price; //������ ���ݸ�ŭ PlayerCoin ����

                dataManager.I.Elec3rdisUnlocked = true; //�ر� ���� �ٲٰ�

                dataManager.I.SaveData(); //������ ����

                Elec3rdLockImg.SetActive(false); //���ǥ�� �����
                Elec3rdUnlockedPanel.SetActive(true);
                Elec3rdBuyPanel.SetActive(false);
                sfxManager.I.PlaySfx("Unlock");

            }
            else if (dataManager.I.PlayerCoin < price)
            {
                sfxManager.I.PlaySfx("NoCoin");
                Debug.Log("������ �����մϴ�!");
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
        if (dataManager.I.Fire2ndisUnlocked == false) // �� 2�� �ر� �ȵƴٸ�
        {
            Fire2ndBuyPanel.SetActive(true); //�� 2�� �����г� ����
        }
        else //�رݵƴٸ�
        {
            sfxManager.I.PlaySfx("Unlock");
            Fire2ndUnlockedPanel.SetActive(true); //�� 2�� �ر� �г� ����
        }
    }
    public void clickWater2ndPanel()
    {
        if (dataManager.I.Water2ndisUnlocked == false) // �� 2�� �رݵƴٸ�
        {
            Water2ndBuyPanel.SetActive(true); //�� 2�� �����г� ����
        }
        else
        {
            sfxManager.I.PlaySfx("Unlock");
            Water2ndUnlockedPanel.SetActive(true); //�� 2�� �ر� �г� ����
           
        }
    }
        
    public void clickElec2ndPanel()
    {
        if (dataManager.I.Elec2ndisUnlocked == false) // ���� 2�� �رݵƴٸ�
        {
            Elec2ndBuyPanel.SetActive(true); //���� 2�� �����г� ����
        }
        else
        {
            sfxManager.I.PlaySfx("Unlock");
            Elec2ndUnlockedPanel.SetActive(true); //���� 2�� �ر� �г� ����
            
        }
    }
    public void clickFire3rdPanel()
    {
        if (dataManager.I.Fire3rdisUnlocked == false) // �� 3�� �رݵƴٸ�
        {
            Fire3rdBuyPanel.SetActive(true); //�� 3�� �����г� ����
        }
        else
        {
            Fire3rdUnlockedPanel.SetActive(true); //�� 3�� �ر� �г� ����
            sfxManager.I.PlaySfx("Unlock");
        }
    }
    public void clickWater3rdPanel()
    {
        if (dataManager.I.Water3rdisUnlocked == false) // �� 3�� �رݵƴٸ�
        {
            Water3rdBuyPanel.SetActive(true); //�� 3�� �����г� ����
        }
        else
        {
            Water3rdUnlockedPanel.SetActive(true); //�� 3�� �ر� �г� ����
            sfxManager.I.PlaySfx("Unlock");
        }
    }
    public void clickElec3rdPanel()
    {
        if (dataManager.I.Elec3rdisUnlocked == false) // ���� 3�� �رݵƴٸ�
        {
            Elec3rdBuyPanel.SetActive(true); //���� 3�� �����г� ����
        }
        else
        {
            Elec3rdUnlockedPanel.SetActive(true); //���� 3�� �ر� �г� ����
            sfxManager.I.PlaySfx("Unlock");
        }
    }










}

