using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class AI : MonoBehaviour
{
    public GameObject target;
    public float speed = 1.0f;
    public bool seeking = false;
    public bool fleeing = false;
    private bool isawake = false;
 
    private void Start()
    {
        target = GameObject.FindWithTag("Player");
    }
  private void OnTriggerStay2D(Collider2D collision)
  { if(collision.gameObject.tag == "Player")
        {   
            seeking = true;
        }
      
  }
 
    private void OnTriggerExit2D(Collider2D collision)
    {
        seeking = false;
        
    }

    void Update()
    {
        float dt = Time.deltaTime;
        if (seeking)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.transform.position, speed * dt);
        }
            
        if (fleeing)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.transform.position, speed* dt * -1);
            seeking = false;

        }

    }
}
