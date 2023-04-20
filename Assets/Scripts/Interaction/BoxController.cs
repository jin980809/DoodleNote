using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxController : MonoBehaviour
{
    public bool is_fall;
    public bool is_side;
    private JCharacterMovement JCM;
    private float MoveSpeed = 0.8f;

    void Start()
    {
        is_fall = false;
        is_side = false;
        JCM = GameObject.Find("Player").GetComponent<JCharacterMovement>();
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !is_fall && !is_side)
        {
            Vector3 pos = other.transform.position + other.transform.right * MoveSpeed;
            transform.parent.position = pos;
        }
        else if (other.CompareTag("Player") && is_fall && is_side)
        {
            MoveSpeed = 0f;
        }
    }
}
