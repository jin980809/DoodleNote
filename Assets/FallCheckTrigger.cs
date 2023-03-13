using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallCheckTrigger : MonoBehaviour
{
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Line")
        {
            GameObject.Find("Player").GetComponent<CharacterController2D>().is_fall = false;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    { 
        if (other.tag == "Line")
        {
            GameObject.Find("Player").GetComponent<CharacterController2D>().is_fall = true;
        }
    }
}
