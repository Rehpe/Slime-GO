using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fallingElements : MonoBehaviour
{

   // Start is called before the first frame update
    void Start()
    { 
  
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D coll) //¹Ù´Ú°ú Ãæµ¹ ½Ã ¿ø¼Ò ÇÁ¸®ÆÕ »ç¶óÁü
    {
        if (coll.gameObject.tag == "ground")
        {
            Destroy(gameObject);
        }

    }
}
