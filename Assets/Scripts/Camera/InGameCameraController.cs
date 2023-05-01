using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameCameraController : MonoBehaviour
{
    public Transform target; // �÷��̾� Transform
    public float zoomSize = 5f; // Ȯ���� ī�޶� ũ��
    public float zoomSpeed = 5f; // Ȯ��/��� �ӵ�

    private Vector3 offset; // ī�޶�� �÷��̾��� �Ÿ� ����
    private float normalSize; // �⺻ ī�޶� ũ��
    public bool isZoomedIn = false; // Ȯ�� ����

    private void Start()
    {
        // ī�޶�� �÷��̾��� �Ÿ� ���̸� ����մϴ�.
        offset = transform.position - target.position;

        // �⺻ ī�޶� ũ�⸦ �����մϴ�.
        normalSize = Camera.main.orthographicSize;
    }

    private void Update()
    {
        // "Zoom" ��ư�� ������ Ȯ��/��Ҹ� ����մϴ�.
        if (Input.GetKeyDown(KeyCode.Z))
        {
            isZoomedIn = !isZoomedIn;
        }

        // ī�޶� �÷��̾ ���� �̵���ŵ�ϴ�.
        

        // Ȯ�� ���̸� ī�޶� ũ�⸦ �����մϴ�.
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
