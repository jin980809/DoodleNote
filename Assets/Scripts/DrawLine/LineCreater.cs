using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class LineCreater : MonoBehaviour
{
    public GameObject linePrefab;
    public static float maxLineLength = 50;
    public static float Current_Pencil = maxLineLength;
    public float Increase_Pencil = 5.0f;
    public Image PencilGauge;
    Line activeLine;

    void Update()
    {
        sliderGauge();
        if (Current_Pencil <= 50f)
        {
            Current_Pencil += Increase_Pencil * Time.deltaTime;
        }

        if (Current_Pencil <= 0)
        {
            activeLine = null;
            return;
        }



        if (Input.GetMouseButtonDown(0))
        {
            if (!EventSystem.current.IsPointerOverGameObject())
            {
                GameObject lineGO = Instantiate(linePrefab);
                activeLine = lineGO.GetComponent<Line>();
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            if (!EventSystem.current.IsPointerOverGameObject())
            {
                activeLine = null;
            }
        }

        if (activeLine != null)
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            activeLine.UpdateLine(mousePos);
        }
    }

    public void sliderGauge()
    {
        float fillAmount = Current_Pencil / maxLineLength;
        PencilGauge.fillAmount = fillAmount;
    }
}