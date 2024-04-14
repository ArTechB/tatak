//using Palmmedia.ReportGenerator.Core.Reporting.Builders;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class PlayOpeningVideo : MonoBehaviour
{
    //Fields
    [SerializeField] Transform text;
    [SerializeField] Transform startButton;
    [SerializeField] Transform videoImage;

    //Events
    public static event EventHandler VideoEnded;

    //Functions
    private void Awake()
    {
        //OpeningSceneHandler.StartTour += PlayVideo;
        ExpositionTextHandler.ExpositionTextEnd += PlayVideo;
        GetComponent<VideoPlayer>().loopPointReached += OnVideoEnded;
    }

    private void PlayVideo(object sender, EventArgs e)
    {
        text.gameObject.SetActive(false);
        startButton.gameObject.SetActive(false);
        videoImage.gameObject.SetActive(true);
        GetComponent<VideoPlayer>().Play();
    }

    private void OnVideoEnded(UnityEngine.Video.VideoPlayer vp)
    {
        VideoEnded?.Invoke(this, EventArgs.Empty);
    }

    private void OnDestroy()
    {
        GetComponent<VideoPlayer>().loopPointReached -= OnVideoEnded;
        ExpositionTextHandler.ExpositionTextEnd -= PlayVideo;
    }
}