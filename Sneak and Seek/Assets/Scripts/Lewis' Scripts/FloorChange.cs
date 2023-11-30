using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FloorChange : MonoBehaviour
{
    // The gamemanager script
    [SerializeField] GameManager gameManager;

    // The name of the scene for the stairs to load
    [SerializeField] int sceneIndex;

    IEnumerator loadNextScene(int nextScene)
    {
        SceneManager.LoadScene("LoadingScene");
        AsyncOperation asyncLoaing = SceneManager.LoadSceneAsync(nextScene);

        while (!asyncLoaing.isDone) 
        {
            yield return null;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        loadNextScene(sceneIndex);
    }

    public void OnButtonPress()
    {
        loadNextScene(sceneIndex);
    }
}
