using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Items : MonoBehaviour
{
    public string itemName;
    public int price;
    public string type;
    public bool isUnlocked;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter2D(Collision2D coll) //�ٴڰ� �浹 �� ������ ������ �����
    {
        if (coll.gameObject.tag == "ground")
        {
            Destroy(gameObject);
        }

    }
}

