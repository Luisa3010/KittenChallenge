using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    public GameObject catmint;

    private void OnCollisionEnter(Collision collision)
    {
        print("hit");
        if (collision.gameObject.tag == "projectile")
        {

            Destroy(this.gameObject);
        }
    }
}

