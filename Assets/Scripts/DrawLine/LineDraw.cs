using System.Collections.Generic;
using UnityEngine;

public class LineDraw : MonoBehaviour
{
    public GameObject linePrefab; // 선 프리팹
    private Vector3 Start_Pos;
    private Vector3 End_Pos;
    private GameObject newLine;
    private List<Vector3> linePoints = new List<Vector3>(); // 선의 포인트들

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            StartDrawing();
        }
        else if (Input.GetMouseButton(0))
        {
            ContinueDrawing();
        }
        else if (Input.GetMouseButtonUp(0))
        {
            FinishDrawing();
        }
    }

    private void StartDrawing()
    {
        newLine = Instantiate(linePrefab, transform.position, Quaternion.identity);
        Start_Pos = GetMouseWorldPosition();
        Debug.Log(Start_Pos);

    }

    private void ContinueDrawing()
    {
        
    }

    private void FinishDrawing()
    {
        End_Pos = GetMouseWorldPosition();
        Debug.Log(End_Pos);
        DrawingLine();
    }

    private void DrawingLine()
    {
        LineRenderer LR = newLine.GetComponent<LineRenderer>();
        LR.SetPosition(0, Start_Pos);
        LR.SetPosition(1, End_Pos);

        EdgeCollider2D EC = newLine.GetComponent<EdgeCollider2D>();
        Vector2[] points = EC.points;
        points.SetValue(new Vector2(Start_Pos.x, Start_Pos.y), 0);
        points.SetValue(new Vector2(End_Pos.x, End_Pos.y), 1);
        EC.points = points;
    }

    private Vector2 GetMouseWorldPosition()
    {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition.z = -Camera.main.transform.position.z;
        return Camera.main.ScreenToWorldPoint(mousePosition);
    }

}