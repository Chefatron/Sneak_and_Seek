using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VideoPlay : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private VideoPlayer MyVideoPlayer;

    public void PlayVideo(){
        MyVideoPlayer =  GetComponent<StartingVideo>();
        //Calls the video player so it can be played whenever
        MyVideoPlayer.Play();
    }
}
