using System.Collections;
using System.Collections.Generic;
//using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VideoPlay : MonoBehaviour
{

    [SerializeField] GameObject video;

    public void PlayVideo()
    {
        Debug.Log("Video is playing");

        //Calls the video player so it can be played whenever
        var videoPlayer = video.GetComponent<UnityEngine.Video.VideoPlayer>();

        videoPlayer.isLooping = false;

        videoPlayer.loopPointReached += EndReached;

        Destroy(GameObject.Find("GameAudio"));

        videoPlayer.Play();
    }

    void EndReached(UnityEngine.Video.VideoPlayer vp)
    {
        Debug.Log("Video has finished");

        PlayerPrefs.SetInt("IntroSeen", 1);

        SceneManager.LoadScene(PlayerPrefs.GetInt("CurrentStage"));

        //SceneManager.LoadScene("First Floor");
        //SceneManager.LoadSceneAsync("First Floor");
    }
}
