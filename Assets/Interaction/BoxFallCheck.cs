using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxFallCheck : MonoBehaviour
{
    [SerializeField] private BoxController BC;

    void Start()
    {
    }

    /*private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("OriginLine") || Crayon_UI.Line_tag.ToString() == other.tag)
        {
            BC.is_fall = false;
        }
    }*/

    private void OnTriggerStay2D(Collider2D other)
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
            BC.is_fall = false;
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
            BC.is_fall = true;
        }
    }
}