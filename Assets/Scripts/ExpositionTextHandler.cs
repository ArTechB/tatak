using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ExpositionTextHandler : MonoBehaviour
{
    //Fields - Value Types
    private const float fadeTime = 0.75f;
    private int indexOfExposition = 0;

    //Fields - Reference Types
    [SerializeField] private Transform expositionObject;
    [SerializeField] private List<string> textList;
    [SerializeField] private TextMeshProUGUI textBox;
    [SerializeField] private List<Sprite> imageList;
    [SerializeField] private Image imageBox;
    [SerializeField] private List<AudioClip> expositionAudioList;
    [SerializeField] private AudioSource audioSource;

    //Events
    public static event EventHandler ExpositionTextEnd;

    //Functions
    private void Awake()
    {
        OpeningSceneHandler.StartTour += StartExpositionText;
    }

    private void OnDestroy()
    {
        OpeningSceneHandler.StartTour -= StartExpositionText;
    }

    private void StartExpositionText(object sender, EventArgs e)
    {
        
        expositionObject.gameObject.SetActive(true);
        OnClick_PlayNextExposition();
        //StartCoroutine(PlayText());
    }

    public void OnClick_PlayNextExposition()
    {
        if(indexOfExposition < textList.Count)
        {
            textBox.text = textList[indexOfExposition];
            imageBox.sprite = imageList[indexOfExposition];
            StartCoroutine(PlayAudio());
        }
        else
        {
            expositionObject.gameObject.SetActive(false);
            audioSource.clip = null;
            OnExpositionTextEnd();
        }
    }

    private IEnumerator PlayAudio()
    {
        yield return new WaitForSeconds(0.5f);
        audioSource.clip = expositionAudioList[indexOfExposition];
        audioSource.Play();
        indexOfExposition++;
    }

    private IEnumerator PlayText()
    {
        for(int i = 0; i < textList.Count; i++) 
        {
            textBox.text = textList[i];
            imageBox.sprite = imageList[i];
            yield return new WaitForSeconds(SecondsToWait(i));
        }
        expositionObject.gameObject.SetActive(false);
        OnExpositionTextEnd();
    }

    private int SecondsToWait(int index)
    {
        switch(textList[index].Length)
        {
            case int i when i > 0 && i <= 30:
                {
                    return 5;
                }
            case int i when i > 30 && i <= 50:
                {
                    return 5;
                }
            case int i when i > 50 && i <= 70:
                {
                    return 6;
                }
            case int i when i > 70 && i <= 100:
                {
                    return 7;
                }
        }
        return 0;
    }

    private void OnExpositionTextEnd()
    {
        ExpositionTextEnd?.Invoke(this, EventArgs.Empty);
    }
}