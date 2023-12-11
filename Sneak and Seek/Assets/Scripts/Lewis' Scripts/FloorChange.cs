using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FloorChange : MonoBehaviour
{
    // The gamemanager script
    [SerializeField] GameManager gameManager;

    // The name of the scene for the stairs to load
    [SerializeField] string sceneName;

    IEnumerator loadNextScene(string nextScene)
    {
        Debug.Log("Scene Change start");

        SceneManager.LoadScene("LoadingScene");
        AsyncOperation asyncLoading = SceneManager.LoadSceneAsync(nextScene);

        while (!asyncLoading.isDone)
        {
            yield return null;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Trigger active");
        Debug.Log(other.gameObject.tag);

        if (other.gameObject.tag == "Player")
        {
            Debug.Log("Player Found");
            loadNextScene(sceneName);
            //SceneManager.LoadScene(sceneName);
        }
    }

    public void OnButtonPress()
    {
        loadNextScene(sceneName);
    }
}
