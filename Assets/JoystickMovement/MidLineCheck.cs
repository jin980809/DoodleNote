using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MidLineCheck : MonoBehaviour
{
    private JCharacterMovement JCM;

    void Start()
    {
        JCM = GameObject.Find("Player").GetComponent<JCharacterMovement>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("OriginLine"))
        {
            JCM.moveSpeed = 0f;
        }
    }

        private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("OriginLine"))
        {
            JCM.moveSpeed = 5.0f;
        }
    }
}
