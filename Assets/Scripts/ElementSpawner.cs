using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using System;

public class ElementSpawner : MonoBehaviour

{
    [SerializeField]
    public GameObject[] elements;
    private List<GameObject> ElementsList;
    public int src = 0;
    public int dst = 3;
    public float spawntime = 0.8f;

    private IEnumerator ElementSpawningCoroutine;
        
  
    // Start is called before the first frame update

    public void Start()
    {
        elements = Resources.LoadAll<GameObject>("Prefabs/elements");
       
        StartCoroutine(InvokeElementSpawn());

        /*        if (runningCoroutine != null)
                {
                    StopCoroutine(runningCoroutine);
                }
                runningCoroutine = StartCoroutine(ElementSpawningCoroutine);

                Debug.Log(runningCoroutine);*/

    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator InvokeElementSpawn()
    {
        ElementSpawn();
        yield return new WaitForSeconds (spawntime);
        StartCoroutine(InvokeElementSpawn());
        
    }


    void ElementSpawn()
    {
        int randomNumber = Random.Range(this.src, this.dst);
        float x = UnityEngine.Random.Range(-2.3f, 2.4f);
        float y = UnityEngine.Random.Range(5.5f, 5.7f);

        Vector3 position = new Vector3(x, y, 1);

        Instantiate(elements[randomNumber], position, Quaternion.identity);
    }

    public void StopSpawning()
    {
        StopAllCoroutines();
        Debug.Log("Stop");
    }

}