using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    [SerializeField]
    public Items[] AllItems;

    public bool ItemDoubleisUnlocked;
    public bool ItemTripleisUnlocked;
    public bool ItemGetCoinisUnlocked;
    public bool ItemHpUpSmallisUnlocked;
    public bool ItemHpUpBigisUnlocked;
    public bool ItemSpeedUpisUnlocked;


    public List<Items> UnlockedItems = new List<Items>();
    public List<Items> UnlockedPointItems;
    public List<Items> UnlockedCoinItems;
    public List<Items> UnlockedHpUpItems;
    public List<Items> UnlockedSpeedItems;


    

   


    // Start is called before the first frame update
    void Start()
    {
       
        AllItems = Resources.LoadAll<Items>("Prefabs/Items"); //폴더 안의 모든 Asset을 AllItems에 불러옴
        dataManager.I.LoadData();

       
        if (dataManager.I.ItemDoubleisUnlocked == true)   //더블 아이템이 해금되었다면
            AllItems[0].isUnlocked = true;
        else
            AllItems[0].isUnlocked = false;

        if (dataManager.I.ItemTripleisUnlocked == true)   //트리플 아이템이 해금되었다면
            AllItems[1].isUnlocked = true;
        else
            AllItems[1].isUnlocked = false;

        if (dataManager.I.ItemGetCoinisUnlocked == true)  //코인 아이템이 해금되었다면
            AllItems[2].isUnlocked = true;
        else
            AllItems[2].isUnlocked = false;

        if (dataManager.I.ItemHpUpSmallisUnlocked == true) //체력회복(소) 아이템이 해금되었다면
            AllItems[3].isUnlocked = true;
        else
            AllItems[3].isUnlocked = false;

        if (dataManager.I.ItemHpUpBigisUnlocked == true) //체력회복(대) 아이템이 해금되었다면
            AllItems[4].isUnlocked = true;
        else
            AllItems[4].isUnlocked = false;

        if (dataManager.I.ItemSpeedUpisUnlocked == true)  //스피드 업 아이템이 해금되었다면
            AllItems[5].isUnlocked = true;
        else
            AllItems[5].isUnlocked = false;


        foreach (Items i in AllItems) 
        {
            if (i.isUnlocked == true)   //isUnlocked가 참인 아이템만 UnlockedItems 리스트에 추가한다
                UnlockedItems.Add(i);
        }

        foreach (Items i in UnlockedItems) //UnlockedItems 리스트의 items클래스를 조사해 각 타입별로 새로운 리스트에 추가한다.
        {
            if (i.type == "point")
                UnlockedPointItems.Add(i);

            if (i.type == "coin")
                UnlockedCoinItems.Add(i);

            if (i.type == "HpUp")
                UnlockedHpUpItems.Add(i);

            if (i.type == "speed")
                UnlockedSpeedItems.Add(i);
        
        }

        InvokeRepeating("PointTypeItemSpawn", 20, 15f);
        InvokeRepeating("CoinTypeItemSpawn", 25f, 30f);
        InvokeRepeating("HpUpTypeItemSpawn", 30f, 13f);
        InvokeRepeating("SpeedTypeItemSpawn", 15f, 25f);
        


    }

    // Update is called once per frame
    void Update()
    {

    }

   
    void PointTypeItemSpawn()
    {
        int RandomItem = Random.Range(0, UnlockedPointItems.Count);

        float x = Random.Range(-2.4f, 2.4f);
        float y = Random.Range(6.0f, 7.0f);
        Vector3 position = new Vector3(x, y, 1);

        Instantiate(UnlockedPointItems[RandomItem], position, Quaternion.identity);
    }

    void CoinTypeItemSpawn()
    {
        int RandomItem = Random.Range(0, UnlockedCoinItems.Count);

        float x = Random.Range(-2.4f, 2.4f);
        float y = Random.Range(6.0f, 7.0f);
        Vector3 position = new Vector3(x, y, 1);

        Instantiate(UnlockedCoinItems[RandomItem], position, Quaternion.identity);
    }

    void HpUpTypeItemSpawn()
    {
        int RandomItem = Random.Range(0, UnlockedHpUpItems.Count);

        float x = Random.Range(-2.4f, 2.4f);
        float y = Random.Range(6.0f, 7.0f);
        Vector3 position = new Vector3(x, y, 1);

        Instantiate(UnlockedHpUpItems[RandomItem], position, Quaternion.identity);
    }

    void SpeedTypeItemSpawn()
    {
        int RandomItem = Random.Range(0, UnlockedSpeedItems.Count);

        float x = Random.Range(-2.4f, 2.4f);
        float y = Random.Range(6.0f, 7.0f);
        Vector3 position = new Vector3(x, y, 1);

        Instantiate(UnlockedSpeedItems[RandomItem], position, Quaternion.identity);
    }



}



    