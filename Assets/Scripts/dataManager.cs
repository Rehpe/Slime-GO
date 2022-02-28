using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dataManager : MonoBehaviour
{
    public static dataManager I;

    public int PlayerCoin;

    public bool ItemDoubleisUnlocked;
    public bool ItemTripleisUnlocked;
    public bool ItemGetCoinisUnlocked;
    public bool ItemHpUpSmallisUnlocked;
    public bool ItemHpUpBigisUnlocked;
    public bool ItemSpeedUpisUnlocked;

    public bool Fire2ndisUnlocked;
    public bool Water2ndisUnlocked;
    public bool Elec2ndisUnlocked;
    public bool Fire3rdisUnlocked;
    public bool Water3rdisUnlocked;
    public bool Elec3rdisUnlocked;

    


    private void Awake()
    {
        if (I == null)
        {
            I = this;
        }
        var obj = FindObjectsOfType<dataManager>(); 
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
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SaveData()
    {
        GameData gd = new GameData();
        gd.PlayerCoin = this.PlayerCoin; //플레이어 재화 정보 저장

        //플레이어 아이템 해금 정보 저장
        gd.ItemDoubleisUnlocked = this.ItemDoubleisUnlocked;
        gd.ItemTripleisUnlocked = this.ItemTripleisUnlocked;
        gd.ItemGetCoinisUnlocked = this.ItemGetCoinisUnlocked;
        gd.ItemHpUpSmallisUnlocked = this.ItemHpUpSmallisUnlocked;
        gd.ItemHpUpBigisUnlocked = this.ItemHpUpBigisUnlocked;
        gd.ItemSpeedUpisUnlocked = this.ItemSpeedUpisUnlocked;

        //플레이어 진화체 해금 정보 저장
        gd.Fire2ndisUnlocked = this.Fire2ndisUnlocked;
        gd.Water2ndisUnlocked = this.Water2ndisUnlocked;
        gd.Elec2ndisUnlocked = this.Elec2ndisUnlocked;
        gd.Fire3rdisUnlocked = this.Fire3rdisUnlocked;
        gd.Water3rdisUnlocked = this.Water3rdisUnlocked;
        gd.Elec3rdisUnlocked = this.Elec3rdisUnlocked;

        SaveManager.Save(gd);
    }

    public void LoadData()
    {
        this.PlayerCoin = SaveManager.Load().PlayerCoin;

        this.ItemDoubleisUnlocked = SaveManager.Load().ItemDoubleisUnlocked;
        this.ItemTripleisUnlocked = SaveManager.Load().ItemTripleisUnlocked;
        this.ItemGetCoinisUnlocked = SaveManager.Load().ItemGetCoinisUnlocked;
        this.ItemHpUpSmallisUnlocked = SaveManager.Load().ItemHpUpSmallisUnlocked;
        this.ItemHpUpBigisUnlocked = SaveManager.Load().ItemHpUpBigisUnlocked;
        this.ItemSpeedUpisUnlocked = SaveManager.Load().ItemSpeedUpisUnlocked;

        this.Fire2ndisUnlocked = SaveManager.Load().Fire2ndisUnlocked;
        this.Water2ndisUnlocked = SaveManager.Load().Water2ndisUnlocked;
        this.Elec2ndisUnlocked = SaveManager.Load().Elec2ndisUnlocked;
        this.Fire3rdisUnlocked = SaveManager.Load().Fire3rdisUnlocked;
        this.Water3rdisUnlocked = SaveManager.Load().Water3rdisUnlocked;
        this.Elec3rdisUnlocked = SaveManager.Load().Elec3rdisUnlocked;
    }
}


