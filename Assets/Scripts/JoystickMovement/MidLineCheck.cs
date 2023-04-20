using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MidLineCheck : MonoBehaviour
{
    private JCharacterMovement JCM;
    [SerializeField] private CrayonUI Crayon_UI;

    void Start()
    {
        JCM = GameObject.Find("Player").GetComponent<JCharacterMovement>();
        Crayon_UI = GameObject.Find("CrayonButton").GetComponent<CrayonUI>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        bool is_true;
        is_true = other.CompareTag("OriginLine") ||
            other.CompareTag("RedLine") ||
            other.CompareTag("OrangeLine") ||
            other.CompareTag("YellowLine") ||
            other.CompareTag("GreenLine") ||
            other.CompareTag("BlueLine") ||
            other.CompareTag("PurpleLine");

        if (is_true)
        {
            JCM.moveSpeed = 0f;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        bool is_true;
        is_true = other.CompareTag("OriginLine") ||
            other.CompareTag("RedLine") ||
            other.CompareTag("OrangeLine") ||
            other.CompareTag("YellowLine") ||
            other.CompareTag("GreenLine") ||
            other.CompareTag("BlueLine") ||
            other.CompareTag("PurpleLine");

        if (is_true)
        {
            JCM.moveSpeed = 5.0f;
        }
    }
}
