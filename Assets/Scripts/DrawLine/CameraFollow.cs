using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public float cameraSpeed = 5f;
    public float cameraBoundary = 12f;

    public  Transform target;

    private void Start()
    {
    }

    private void Update()
    {
        if (target != null)
        {
            // ī�޶� �̵�
            Vector3 targetPosition = new Vector3(transform.position.x + cameraSpeed * Time.deltaTime, transform.position.y, transform.position.z);
            transform.position = targetPosition;

            // Ÿ���� ī�޶� ������� Ȯ��
            float targetRight = target.position.x + cameraBoundary;
            if (targetRight < transform.position.x)
            {
                // Ÿ���� ī�޶� ���������� ����� ��
                Game.Instance.CharacterDead();
            }
        }
    }
}