using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RideCheck : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator Anim;

    void Start()
    {
        rb = GameObject.Find("LobbyPlayer").GetComponent<Rigidbody2D>();
        Anim = GetComponent<Animator>();
        Anim.enabled = false;
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Anim.enabled = true;
            rb.constraints = RigidbodyConstraints2D.None;
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Anim.enabled = false;
            rb.constraints = RigidbodyConstraints2D.None;
        }
    }
}
