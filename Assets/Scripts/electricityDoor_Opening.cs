using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class electricityDoor_Opening : MonoBehaviour
{
    //Constants
    private const float timeOfOpeningAnim = 1.5f;
    
    //Fields
    //public Material materialToReplace;

    //Events
    public static event EventHandler readyToShowUI;
    
    //Functions
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag != "wall")
        {
            GetComponent<Animator>().SetTrigger("doorPushed");
            StartCoroutine(OnReadyToShowUI());
        }
    }

    private IEnumerator OnReadyToShowUI()
    {
        yield return new WaitForSeconds(timeOfOpeningAnim);
        //GetComponent<MeshRenderer>().material = materialToReplace;
        readyToShowUI?.Invoke(this, EventArgs.Empty);
    }
}
