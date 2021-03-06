using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explode : MonoBehaviour
{

    public float radius = 10f;

    private GameObject playerObj;

    private void Start()
    {
        playerObj = GameObject.Find("Player");
    }

    public void explode()
    {
        Collider[] hitColliders = Physics.OverlapSphere(playerObj.transform.position, radius);
        for (int i = 0; i < hitColliders.Length; i++)
        {
            if (hitColliders[i].gameObject.tag == "Obstacle")
            {
                Destroy(hitColliders[i]);
            }
        }
    }

}
