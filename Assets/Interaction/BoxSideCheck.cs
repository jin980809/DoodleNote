using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxSideCheck : MonoBehaviour
{
    [SerializeField] private CrayonUI Crayon_UI;
    [SerializeField] private BoxController BC;

    void Start()
    {
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
            Debug.Log("side");
            BC.is_side = true;
        }
    }
}
