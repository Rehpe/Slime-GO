using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class background : MonoBehaviour
{

    public GameObject Rock;
    public GameObject Tree;
    public GameObject Background;
    public Image FireRockImg;
    public Image FireTreeImg;
    public Image FireBackgroundImg;
    public Image WaterRockImg;
    public Image WaterTreeImg;
    public Image WaterBackgroundImg;
    public Image ElecRockImg;
    public Image ElecTreeImg;
    public Image ElecBackgroundImg;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }


    public void normalBackground()
    {
        Rock.GetComponent<SpriteRenderer>().material.color = new Color(255f / 255f, 255f / 255f, 255f / 255f, 255f / 255f);
        Tree.GetComponent<SpriteRenderer>().material.color = new Color(255f / 255f, 255f / 255f, 255f / 255f, 255f / 255f);
        Background.GetComponent<SpriteRenderer>().material.color = new Color(255f / 255f, 255f / 255f, 255f / 255f, 255f / 255f);
    }

    public void fireEvolveBackground()
    {
        Color firecolor = new Color(255f / 255f, 172f / 255f, 172f / 255f, 255f / 255f);

        Rock.GetComponent<SpriteRenderer>().material.color = firecolor;
        Tree.GetComponent<SpriteRenderer>().material.color = firecolor;
        Background.GetComponent<SpriteRenderer>().material.color = firecolor;
    }

    public void waterEvolveBackground()
    {
        Color watercolor = new Color(150f / 255f, 180f / 255f, 255f / 255f, 255f / 255f);

        Rock.GetComponent<SpriteRenderer>().material.color = watercolor;
        Tree.GetComponent<SpriteRenderer>().material.color = watercolor;
        Background.GetComponent<SpriteRenderer>().material.color = watercolor;
    }

    public void elecEvolveBackground()
    {
        Color eleccolor = new Color(255f / 255f, 232f / 255f, 197f / 255f, 255f / 255f);
        Rock.GetComponent<SpriteRenderer>().material.color = eleccolor;
        Tree.GetComponent<SpriteRenderer>().material.color = eleccolor;
        Background.GetComponent<SpriteRenderer>().material.color = eleccolor;
    }
}
