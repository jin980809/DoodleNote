using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundMove : MonoBehaviour
{
    public float BackGroundSpeed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    void Move()
    {
        Vector3 targetPosition = new Vector3(transform.position.x + BackGroundSpeed * Time.deltaTime, transform.position.y, 1f);
        transform.position = targetPosition;
    }
}
