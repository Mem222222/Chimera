using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    public string sceneToLoad;
    public Vector2 playerPos;
    public VectorValue storedPos;
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !other.isTrigger) 
        {
            storedPos.initVal = playerPos;
            SceneManager.LoadScene(sceneToLoad);
        }
    }
    
}
