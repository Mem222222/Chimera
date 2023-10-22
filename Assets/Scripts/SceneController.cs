using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public int DisScene = 1;
    public void SwitchScene()
    {
        SceneManager.LoadScene(DisScene);
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) //Closes the game mid-gameplay
        {
           GetComponent<CloseProgram>().CloseGame();
        }
        if (Input.GetKeyDown(KeyCode.R)) //Test key for death screen
        {
            SceneManager.LoadScene(2);
        }
    }

}
