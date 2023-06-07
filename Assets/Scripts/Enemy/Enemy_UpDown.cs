using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_UpDown : Enemy
{
    [SerializeField] float xSpeed = 2;
    [SerializeField] float ySpeed = 2;
    [SerializeField] float yHeight = 2;
    private float x, y, z;

    private void Start()
    {
        x = transform.position.x;
        y = transform.position.y;
        z = transform.position.z;
    }
    void Update()
    {
        x -= (Time.deltaTime * xSpeed);
        y += Mathf.Sin(Time.time * ySpeed) * Time.deltaTime * yHeight;
        transform.position = new Vector3(x, y, z);
    }
}
