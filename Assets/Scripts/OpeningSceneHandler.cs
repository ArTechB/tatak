using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using UnityEngine;
using UnityEngine.Video;

public class OpeningSceneHandler : MonoBehaviour
{
    //Const
    private const float fadeTime = 0.75f;

    //Fields - Value Types
    private bool videoPlayed;

    //Fields  - Reference Types
    [SerializeField] private Animator fadeAnimator;
    [SerializeField] private Transform openningUIObjects;

    //Events
    public static event EventHandler StartTour;

    //Functions
    private void Awake()
    {
        PlayOpeningVideo.VideoEnded += LoadnextScene;
    }

    public void OnVideoButton()
    {
        StartCoroutine(startFade());
    }

    private void LoadnextScene(object sender, EventArgs e)
    {
        StartCoroutine(startFade());
    }

    private IEnumerator startFade()
    {
        fadeAnimator.SetTrigger("ButtonPressed");
        yield return new WaitForSeconds(fadeTime);
        if(videoPlayed)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("TatakTour");
        }
        else
        {
            openningUIObjects.gameObject.SetActive(false);
            OnWatchOpenningVideoClick();
            videoPlayed = true;
        }
    }

    private void OnWatchOpenningVideoClick()
    {
        StartTour?.Invoke(this, EventArgs.Empty);
    }

    private void OnDestroy()
    {
        PlayOpeningVideo.VideoEnded -= LoadnextScene;
    }
}