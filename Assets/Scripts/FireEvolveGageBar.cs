using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FireEvolveGageBar : MonoBehaviour
{
    Image fireGageBar;
    public float evolvePoint = 30f;
    float currentFirePoint;
    public Text currentFirePointText;

    // Start is called before the first frame update
    void Start()
    {
        fireGageBar = GetComponent<Image>();
        this.currentFirePoint = gameManager.I.totalFirePoint;
        
    }

    // Update is called once per frame
    void Update()
    {
        this.currentFirePoint = gameManager.I.totalFirePoint;
        fireGageBar.fillAmount = this.currentFirePoint / evolvePoint;
        currentFirePointText.text = this.currentFirePoint.ToString();
    }
}