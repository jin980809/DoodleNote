using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Line : MonoBehaviour
{
	public LineRenderer lineRenderer;
	public EdgeCollider2D edgeCol;
	List<Vector2> points;
	static Vector2 prevPoint;
	public void UpdateLine(Vector2 mousePos)
	{
		if (points == null)
		{
			points = new List<Vector2>();
			SetPoint(mousePos);
			return;
		}

		if (Vector2.Distance(points.Last(), mousePos) > 0.5f)
			SetPoint(mousePos);
	}

	void SetPoint(Vector2 point)
	{
		if (points.Count != 0)
		{
			LineCreater.Current_Pencil -= Vector3.Distance(prevPoint, point) * 1.3f;
			prevPoint = point;
		}
		else
		{
			prevPoint = point;
		}
		points.Add(point);
		lineRenderer.positionCount = points.Count;
		lineRenderer.SetPosition(points.Count - 1, point);
		if (points.Count > 1)
			edgeCol.points = points.ToArray();
	}
}