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


}
