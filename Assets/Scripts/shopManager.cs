using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class shopManager : MonoBehaviour
{
    public GameObject NoCoinPopUp;
    public GameObject ItemPanel;
    public GameObject EvolvePanel;



    // Start is called before the first frame update
    void Start()
    {
        soundManager.I.PlayBgm("ShopScene");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
  

}
