using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target; // Player��ġ ����
    public float zoomSpeed = 1.0f; // ���� �ܾƿ� �ӵ�
    public float originalSize = 5.0f; // ������ ī�޶� ũ��
    public float minSize = 2.0f; // ���� ������ �ּ�ũ��
    public float maxSize = 10.0f; // �ܾƿ������� �ִ� ũ��

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
        if (Input.mouseScrollDelta.y != 0) //ī�޶� ��ũ�� �Է� ������
        {
            isFollowing = false;
        }
        if (Input.GetKeyDown(KeyCode.Space)) // �����̽��� �Է� ������
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