using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSwitch : MonoBehaviour
{
    public GameObject flashlight;
    public GameObject weaponParent;

    void Update()
    {
        // Check for mouse wheel input
        float scrollWheel = Input.GetAxis("Mouse ScrollWheel");

        if (scrollWheel > 0f)
        {
            // Scroll up: Activate weapon, deactivate flashlight
            ToggleWeapon(true);
        }
        else if (scrollWheel < 0f)
        {
            // Scroll down: Activate flashlight, deactivate weapon
            ToggleWeapon(false);
        }
    }

    void ToggleWeapon(bool activateWeapon)
    {
        flashlight.SetActive(!activateWeapon);
        weaponParent.SetActive(activateWeapon);
    }
}

