using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayGame : MonoBehaviour
{
    public string sceneName;

    public void playGame()
    {
        SceneManager.LoadScene(sceneName);
    }
}
