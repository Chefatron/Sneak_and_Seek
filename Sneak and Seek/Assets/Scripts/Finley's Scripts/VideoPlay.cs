using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class VideoPlay : MonoBehaviour
{

    [SerializeField] GameObject video;

    public void PlayVideo()
    {
        //Calls the video player so it can be played whenever
        var videoPlayer = video.GetComponent<UnityEngine.Video.VideoPlayer>();

        videoPlayer.isLooping = false;

        videoPlayer.Play();

        if (!videoPlayer.isPlaying)
        {
            
        }
    }
}
