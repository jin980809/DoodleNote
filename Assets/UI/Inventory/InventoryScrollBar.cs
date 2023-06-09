using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class InventoryScrollBar : MonoBehaviour
{
    void Start()
    {
    }

    private void Awake()
    {
        //Dont Work
        this.transform.GetComponent<ScrollRect>().verticalScrollbar.size = 0.2f;
        LayoutRebuilder.ForceRebuildLayoutImmediate(this.GetComponent<RectTransform>());
    }

    void Update()
    {
        this.transform.GetComponent<ScrollRect>().verticalScrollbar.size = 0.2f;
    }
}
