using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Fall : MonoBehaviour
{
    Animator Anim;
    private void Start()
    {
        Anim = GetComponent<Animator>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Line")
        {
            Anim.SetBool("IsFall", true);
            gameObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
        }
    }
}
