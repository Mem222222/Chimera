using UnityEngine;

public class Flashlight : MonoBehaviour
{
    public Transform player;         // Reference to your player's Transform.
    public Light flashlight;         // Reference to the Light component.
    public float rotationSpeed = 5.0f;
    public float maxBatteryTime = 30.0f;

    private bool isFlashlightOn = false;
    private float currentBatteryTime = 0.0f;
    private float currentCooldownTime = 0.0f;


    private void Start()
    {
        flashlight.enabled = false;
    }

    private void Update()
    {
        if (currentCooldownTime > 0)
        {
            currentCooldownTime -= Time.deltaTime;
        }

        if (Input.GetKeyDown(KeyCode.Q) && currentCooldownTime <= 0)
        {
            
            ToggleFlashlight();
            
        }

        if (isFlashlightOn)
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

            // Update the battery time.
            currentBatteryTime += Time.deltaTime;

            // Check if the flashlight should turn off automatically.
            if (currentBatteryTime >= maxBatteryTime)
            {
                ToggleFlashlight();
            }
        }
    }

    private void ToggleFlashlight()
    {
        if (isFlashlightOn)
        {
            
            isFlashlightOn = false;
            flashlight.enabled = false; //turrn off light
            currentCooldownTime = currentBatteryTime; // cooldown time based on the duration the flashlight was on.
            currentBatteryTime = 0.0f;
        }
        else
        {
            
            isFlashlightOn = true;
            flashlight.enabled = true; //activate light
        }
    }
    private void OnGUI()
    {
        // Display battery level on screen.
        float batteryLevel = Mathf.Clamp01(1 - currentBatteryTime / maxBatteryTime);
        GUI.Label(new Rect(10, 10, 150, 20), "Battery Level: " + batteryLevel.ToString("P0"));
    }
}

