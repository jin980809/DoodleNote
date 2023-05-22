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
            // 카메라 이동
            Vector3 targetPosition = new Vector3(transform.position.x + cameraSpeed * Time.deltaTime, transform.position.y, transform.position.z);
            transform.position = targetPosition;

            // 타겟이 카메라를 벗어났는지 확인
            float targetRight = target.position.x + cameraBoundary;
            if (targetRight < transform.position.x)
            {
                // 타겟이 카메라 오른쪽으로 벗어났을 때
                Game.Instance.CharacterDead();
            }
        }
    }
}