using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneStart : MonoBehaviour
{ 
    // Start is called before the first frame update
    void Start()
    {
        
            SceneController.DisScene = SceneManager.GetActiveScene().name;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
