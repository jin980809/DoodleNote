using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SideCheckTrigger : MonoBehaviour
{
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Line")
        {
            GameObject.Find("Player").GetComponent<JCharacterController>().is_side = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Line")
        {
            GameObject.Find("Player").GetComponent<JCharacterController>().is_side = false;
        }
    }
}
