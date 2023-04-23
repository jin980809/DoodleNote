using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CameraController : MonoBehaviour
{
    public Transform target;

    public Vector2 offset;

    public float smoothing = 5f;

    public Vector2 minPosition;
    public Vector2 maxPosition;

    private void LateUpdate()
    {
        Vector3 targetPosition = target.position + new Vector3(offset.x, offset.y, transform.position.z);
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, targetPosition, smoothing * Time.deltaTime);
        transform.position = new Vector3(
            Mathf.Clamp(smoothedPosition.x, minPosition.x, maxPosition.x),
            Mathf.Clamp(smoothedPosition.y, minPosition.y, maxPosition.y),
            transform.position.z
        );
    }
}