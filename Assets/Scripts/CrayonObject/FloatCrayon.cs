using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatCrayon: MonoBehaviour
{

    public float speed = 1f;

    void Update()
    {
        float y = transform.position.y + Mathf.Sin(Time.time * speed) * 0.001f;
        transform.position = new Vector3(transform.position.x, y, transform.position.z);
    }
}