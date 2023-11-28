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
        AI myai = collision.GetComponent<AI>();
        if (Flashlight.triggerOn == true && myai != null)
        {   
            myai.fleeing = true;
            myai.seeking = false;
        }


    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        AI myai = collision.GetComponent<AI>();
        if (myai != null)
        {
            myai.fleeing = false;
        }


    }
}
