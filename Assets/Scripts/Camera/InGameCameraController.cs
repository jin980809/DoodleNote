using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameCameraController : MonoBehaviour
{
    public Transform target; // 플레이어 Transform
    public float zoomSize = 5f; // 확대할 카메라 크기
    public float zoomSpeed = 5f; // 확대/축소 속도

    private Vector3 offset; // 카메라와 플레이어의 거리 차이
    private float normalSize; // 기본 카메라 크기
    public bool isZoomedIn = false; // 확대 여부

    private void Start()
    {
        // 카메라와 플레이어의 거리 차이를 계산합니다.
        offset = transform.position - target.position;

        // 기본 카메라 크기를 저장합니다.
        normalSize = Camera.main.orthographicSize;
    }

    private void Update()
    {
        // "Zoom" 버튼을 누르면 확대/축소를 토글합니다.
        if (Input.GetKeyDown(KeyCode.Z))
        {
            isZoomedIn = !isZoomedIn;
        }

        // 카메라를 플레이어에 따라 이동시킵니다.
        

        // 확대 중이면 카메라 크기를 조정합니다.
        if (isZoomedIn)
        {
            Camera.main.orthographicSize = Mathf.Lerp(Camera.main.orthographicSize, zoomSize, Time.deltaTime * zoomSpeed);
            Vector3 targetPos = target.position + offset;
            transform.position = Vector3.Lerp(transform.position, targetPos, Time.deltaTime * zoomSpeed);
        }
        else
        {
            Camera.main.orthographicSize = Mathf.Lerp(Camera.main.orthographicSize, normalSize, Time.deltaTime * zoomSpeed);
        }
    }
}
