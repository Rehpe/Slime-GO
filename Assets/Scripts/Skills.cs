using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skills : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    

    public void Fire1stSkill()
    {
        StartCoroutine(Fire1stSkill(5f));
    }


    IEnumerator Fire1stSkill(float seconds)
    {
        GameObject.Find("ElementSpawner").GetComponent<ElementSpawner>().src = 0;
        GameObject.Find("ElementSpawner").GetComponent<ElementSpawner>().dst = 1;

        yield return new WaitForSecondsRealtime(seconds);

        GameObject.Find("ElementSpawner").GetComponent<ElementSpawner>().src = 0;
        GameObject.Find("ElementSpawner").GetComponent<ElementSpawner>().dst = 3;
    }
}
