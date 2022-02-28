using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ElecEvolveGageBar : MonoBehaviour
{
    Image elecGageBar;
    public float evolvePoint = 30f;
    float currentElecPoint;
    public Text currentElecPointText;

    // Start is called before the first frame update
    void Start()
    {
        elecGageBar = GetComponent<Image>();
        this.currentElecPoint = gameManager.I.totalElecPoint;

    }

    // Update is called once per frame
    void Update()
    {
        this.currentElecPoint = gameManager.I.totalElecPoint;
        elecGageBar.fillAmount = this.currentElecPoint / evolvePoint;
        currentElecPointText.text = this.currentElecPoint.ToString();
    }
}