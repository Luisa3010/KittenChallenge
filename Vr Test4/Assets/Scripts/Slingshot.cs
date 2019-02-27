using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slingshot : MonoBehaviour {

    public GameObject catmint;
    public GameObject bandbone;
    public GameObject slingshotRigged;
    public GameObject mainBone;
    private Rigidbody rb;

    private GameObject current;

    public float speed = 1;
    [HideInInspector]
    public bool isReadyToShoot = false;



    private void Start()
    {
        rb = bandbone.GetComponent<Rigidbody>();
        spawnCatMint();
        rb.isKinematic = true;
    }

    public void spawnCatMint()
    {
        current = Instantiate(catmint);
        current.transform.parent = bandbone.transform;
        current.transform.localPosition = new Vector3(1, 0,0);
        isReadyToShoot = true;
       
    }

    public void shoot(Vector3 releasePos)
    {
        Rigidbody rb = current.GetComponent<Rigidbody>();

        Vector3 startPos = slingshotRigged.transform.position + slingshotRigged.transform.up * 0.3f;
        Vector3 direction =  startPos - releasePos;
        
        current.transform.parent = null;
        rb.AddForce(direction * speed,ForceMode.Impulse);
        rb.useGravity = true;
        Invoke("spawnCatMint", 1);
        bandbone.transform.parent = mainBone.transform;
        isReadyToShoot = false;
    }

    
    

   
   
}
