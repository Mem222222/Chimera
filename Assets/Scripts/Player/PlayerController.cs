using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NewBehaviourScript : MonoBehaviour
{
    // Definitions
    public float moveSpeed = 5.0f;
    public bool controlFreeze;
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // get input for movement (WASD or arrow keys)
        float dirX = Input.GetAxis("Horizontal");
        float dirY = Input.GetAxis("Vertical");

        // calculate movement direction
        Vector2 dir = new Vector2(dirX, dirY);

        //appply movement
        if (controlFreeze != true)
        {
            rb.velocity = dir * moveSpeed;
        }
        if (controlFreeze == true)
        {
            rb.velocity = dir * moveSpeed * 0;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "AI")
        {
            SceneManager.LoadScene("Game Over");
        }
    }
}
