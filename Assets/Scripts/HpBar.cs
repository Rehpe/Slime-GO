using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HpBar : MonoBehaviour
{
    Image Hpbar;
    Image HpbarUp;
    public float maxHp;
    public float currentHp;

    // Start is called before the first frame update
    void Start()
    {
        Hpbar = GetComponent<Image>();
        HpbarUp = Resources.Load<Image>("HPBar");
        this.maxHp = gameManager.I.maxHp;
        this.currentHp = gameManager.I.currentHp;
    }

    // Update is called once per frame
    void Update()
    {
        this.currentHp = gameManager.I.currentHp;
        Hpbar.fillAmount = currentHp / maxHp;
    }
}

    /*void Hpup()
    {
        if this.currentHp = this
    }
} */