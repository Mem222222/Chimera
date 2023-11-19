using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    public Transform target;         // The target to follow (your player's Transform).
    public float smoothSpeed = 5.0f; // The smoothness of camera movement.

    private Vector3 offset;          // The initial offset between the camera and target.

    private void Start()
    {
        // Calculate the initial offset between the camera and target.
        offset = transform.position - target.position;
    }

    private void Update()
    {
        // Calculate the desired position for the camera.
        Vector3 targetPosition = target.position + offset;

        // Use SmoothDamp to interpolate between the current position and the target position.
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, targetPosition, smoothSpeed * Time.deltaTime);

        // Set the camera's position to the smoothed position.
        transform.position = smoothedPosition;
    }

}

