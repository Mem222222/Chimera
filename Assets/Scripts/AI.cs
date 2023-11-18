using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI : MonoBehaviour
{
    public GameObject target;
    public float speed = 1.0f;
    bool seeking = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        seeking = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        seeking = false;
    }

    void Update()
    {
        float dt = Time.deltaTime;
        if (seeking)
            transform.position = Vector3.MoveTowards(transform.position, target.transform.position, speed * dt);
    }
}
