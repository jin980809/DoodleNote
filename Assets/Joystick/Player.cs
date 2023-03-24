using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed;
    private Joystick joystick;

    void Awake()
    {
        joystick = GameObject.FindObjectOfType<Joystick>();
    }

    void FixedUpdate()
    {
        if (joystick.Horizontal != 0 || joystick.Vertical != 0)
        {
            MoveControl();
            //Debug.Log(joystick.Horizontal + " / " + joystick.Vertical);
        }
    }

    private void MoveControl()
    {
        transform.position += Vector3.up * speed * Time.deltaTime * joystick.Vertical;
        transform.position += Vector3.right * speed * Time.deltaTime * joystick.Horizontal;
    }
}
