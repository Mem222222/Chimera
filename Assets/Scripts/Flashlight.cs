using UnityEngine;

public class Flashlight: MonoBehaviour
{
    public Transform player;         // Reference to your player's Transform.
    public float rotationSpeed = 5.0f;

    private void Update()
    {
        // Get the mouse position in screen coordinates.
        Vector3 mousePosition = Input.mousePosition;

        // Convert the mouse position from screen coordinates to world coordinates.
        mousePosition.z = Vector3.Distance(player.position, Camera.main.transform.position);
        Vector3 targetPosition = Camera.main.ScreenToWorldPoint(mousePosition);

        // Calculate the direction to the target position.
        Vector3 direction = targetPosition - transform.position;
        direction.z = 0; // Lock rotation to the y-axis only.

        // Calculate the rotation to look at the target position.
        Quaternion targetRotation = Quaternion.LookRotation(direction);

        // Smoothly interpolate between the current rotation and the target rotation.
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
    }
}
