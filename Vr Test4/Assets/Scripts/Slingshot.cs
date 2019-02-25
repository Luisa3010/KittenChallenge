using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slingshot : MonoBehaviour {

    public GameObject catmint;
    public GameObject bandbone;
    public GameObject slingshotRigged;

    private GameObject current;


    
    public float speed = 1;

    private void Start()
    {
        spawnCatMint();
    }

   

    public void spawnCatMint()
    {
        current = Instantiate(catmint);
        current.transform.parent = bandbone.transform;
        current.transform.localPosition = new Vector3(1, 0,0);
       
    }

    public void shoot(Vector3 releasePos)
    {
        Rigidbody rb = current.GetComponent<Rigidbody>();

        Vector3 startPos = slingshotRigged.transform.position + slingshotRigged.transform.up * 0.3f;
        Vector3 direction =  startPos - releasePos;
        
        current.transform.parent = null;
        print(direction);
        rb.AddForce(direction * speed,ForceMode.Impulse);
        rb.useGravity = true;
        Invoke("spawnCatMint", 1);
    }
}
