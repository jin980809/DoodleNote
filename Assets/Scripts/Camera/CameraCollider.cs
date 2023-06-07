using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraCollider : MonoBehaviour
{
    [SerializeField] bool isUpCollider = true;
    void Start()
    {
        BoxCollider2D bc = gameObject.AddComponent<BoxCollider2D>() as BoxCollider2D;
        float colPos = Camera.main.orthographicSize;
        if (isUpCollider == true) colPos = Camera.main.orthographicSize;
        else colPos = -Camera.main.orthographicSize;
        gameObject.transform.position = new Vector3(0, colPos, 0);
        bc.size = new Vector2(Camera.main.orthographicSize * Screen.width / Screen.height * 2 + 20f, 0.2f);
    }
}
