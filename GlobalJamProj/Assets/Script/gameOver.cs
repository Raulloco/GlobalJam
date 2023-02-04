using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gameOver : MonoBehaviour
{

    public void LoadSceneName(string str)
    {
        SceneManager.LoadScene(str);
        Time.timeScale = 1f;
    }
}

