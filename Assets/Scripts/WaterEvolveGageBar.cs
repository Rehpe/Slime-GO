using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaterEvolveGageBar : MonoBehaviour
{
    Image waterGageBar;
    public float evolvePoint = 30f;
    float currentWaterPoint;
    public Text currentWaterPointText;

    // Start is called before the first frame update
    void Start()
    {
        waterGageBar = GetComponent<Image>();
        this.currentWaterPoint = gameManager.I.totalWaterPoint;

    }

    // Update is called once per frame
    void Update()
    {
        this.currentWaterPoint = gameManager.I.totalWaterPoint;
        waterGageBar.fillAmount = this.currentWaterPoint / evolvePoint;
        currentWaterPointText.text = this.currentWaterPoint.ToString();
    }
}