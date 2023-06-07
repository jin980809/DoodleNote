using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Bounce : Enemy
{
    [SerializeField] float force = 500.0f;
    void Start()
    {
        Quaternion qrot = Quaternion.Euler(0, 0, Random.Range(-50, 50));
        transform.rotation = qrot;
        GetComponent<Rigidbody2D>().AddForce(-transform.right * force);
    }
}
