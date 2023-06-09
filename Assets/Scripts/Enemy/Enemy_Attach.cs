using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Attach : Enemy
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Line")
            gameObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
    }
}
