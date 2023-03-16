using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target; // Player위치 저장
    public float zoomSpeed = 1.0f; // 줌인 줌아웃 속도
    public float originalSize = 5.0f; // 원래의 카메라 크기
    public float minSize = 2.0f; // 줌인 했을떄 최소크기
    public float maxSize = 10.0f; // 줌아웃했을때 최대 크기

    private Camera cam;
    private bool isFollowing = true;
    private float currentSize;

    void Start()
    {
        cam = GetComponent<Camera>();
        currentSize = originalSize;
    }

    void Update()
    {
        if (Input.mouseScrollDelta.y != 0) //카메라 스크롤 입력 들어오면
        {
            isFollowing = false;
        }
        if (Input.GetKeyDown(KeyCode.Space)) // 스페이스바 입력 들어오면
        {
            isFollowing = true;
            currentSize = originalSize;
        }

        if (isFollowing)
        {
            transform.position = new Vector3(target.position.x, target.position.y, transform.position.z);
            cam.orthographicSize = currentSize;
        }
        else
        {
            currentSize -= Input.mouseScrollDelta.y * zoomSpeed;
            currentSize = Mathf.Clamp(currentSize, minSize, maxSize);
            cam.orthographicSize = currentSize;
        }
    }
}