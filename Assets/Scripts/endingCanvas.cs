using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class endingCanvas : MonoBehaviour
{
    //Constants
    private const float timeOfShowAnim = 1f;

    //Fields - reference types
    [SerializeField] private Transform button1;
    [SerializeField] private Transform button2;

    //Functions
    private void Awake()
    {
        electricityDoor_Opening.readyToShowUI += ShowBoard;
    }

    private void OnDestroy()
    {
        electricityDoor_Opening.readyToShowUI -= ShowBoard;
    }

    private void ShowBoard(object sender, EventArgs e)
    {
        GetComponent<Animator>().SetTrigger("endOfTour");
        StartCoroutine(SetButtonsActive());
    }

    private IEnumerator SetButtonsActive()
    {
        yield return new WaitForSeconds(timeOfShowAnim);
        button1.gameObject.SetActive(true);
        button2.gameObject.SetActive(true);
    }

    public void OnRestartClick()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Opening");
    }

    public void OnExitClick()
    {
        Application.Quit();
    }
}