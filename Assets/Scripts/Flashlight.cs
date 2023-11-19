using UnityEngine;
using TMPro;
public class Flashlight : MonoBehaviour
{
    public TMP_Text Battery_lvl_txt;
    public Transform player;         
    public Light flashlight;         
    public float rotationSpeed = 5.0f;
    public float maxBatteryTime = 30.0f;
    public float batteryLevelOn;
    public float batteryLevelOff;
    static public bool triggerOn;
   
    private bool isFlashlightOn = false;
    private float currentBatteryTime = 0.0f;
    private float currentCooldownTime = 0.0f;


    private void Start()
    {
        AI.fleeing = true;
        flashlight.enabled = false;
        
    }

    private void Update()
    {
        triggerOn = isFlashlightOn;
        batteryLevelOn = Mathf.Clamp01(1 - currentBatteryTime / maxBatteryTime);
        batteryLevelOff = Mathf.Clamp01(1 - currentCooldownTime / maxBatteryTime);

        if (currentCooldownTime > 0)
        {
            currentCooldownTime -= Time.deltaTime;
            //Battery_lvl_txt.SetText("recharging");
        }
        

        if (Input.GetKeyDown(KeyCode.Q) && currentCooldownTime <= 0)
        {
            
            ToggleFlashlight();
            
        }

        if (isFlashlightOn)
        {
            
            Battery_lvl_txt.SetText("Battery Level: " + batteryLevelOn.ToString("P0"));
            Vector3 mousePosition = Input.mousePosition;

            
            mousePosition.z = Vector3.Distance(player.position, Camera.main.transform.position);
            Vector3 targetPosition = Camera.main.ScreenToWorldPoint(mousePosition);

            
            Vector3 direction = targetPosition - transform.position;
            direction.z = 0; 

            
            Quaternion targetRotation = Quaternion.LookRotation(direction);

            
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);

            //uupdate the battery time.
            currentBatteryTime += Time.deltaTime;

            //if the flashlight should turn off automatically.
            if (currentBatteryTime >= maxBatteryTime)
            {
                ToggleFlashlight();
            }
            
         
        }
        else
        {

            Battery_lvl_txt.SetText("Battery Level: " + batteryLevelOff.ToString("P0"));
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
        //battery level on screen.
        //batteryLevel = Mathf.Clamp01(1 - currentBatteryTime / maxBatteryTime);
        //GUI.Label(new Rect(10, 10, 150, 20), "Battery Level: " + batteryLevel.ToString("P0"));
    }
    
}

