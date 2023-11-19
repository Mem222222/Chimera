using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lightTrigger : MonoBehaviour
{
// private void Update()
// {
//     if (Flashlight.triggerOn)
//     {
//         gameObject.SetActive(true);
//     }
//     else
//     {
//         gameObject.SetActive(false);
//     }
// }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (Flashlight.triggerOn == true && collision.gameObject.tag == "AI")
        {
            AI.fleeing = true;
            AI.seeking = false;
        }


    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "AI")
        {
            AI.fleeing = false;
        }


    }
}
