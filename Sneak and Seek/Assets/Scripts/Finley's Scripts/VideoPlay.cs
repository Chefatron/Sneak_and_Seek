using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VideoPlay : MonoBehaviour
{

    [SerializeField] GameObject video;
    [SerializeField] FloorChange floorChange;



    public void PlayVideo()
    {
        //Calls the video player so it can be played whenever
        var videoPlayer = video.GetComponent<UnityEngine.Video.VideoPlayer>();

        videoPlayer.isLooping = false;

        videoPlayer.loopPointReached += EndReached;

        videoPlayer.Play();
    }

    void EndReached(UnityEngine.Video.VideoPlayer vp)
    {
        Debug.Log("Video has finished");

        SceneManager.LoadScene("First Floor");
        //SceneManager.LoadSceneAsync("First Floor");
    }
}
