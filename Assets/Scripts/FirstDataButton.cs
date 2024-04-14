using Oculus.Interaction;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstDataButton : MonoBehaviour
{
    //Consts
    private const float timeOfPressAnim = 2f;
    
    //Fields - Value Types
    private bool isInfoShowing;
    private bool didCollitionInLast2Sec;
    
    //Fields - Reference Types
    [SerializeField] private Animator dataAnimator;
    [SerializeField] private string nameOfTriggerToShowData;
    [SerializeField] private string nameOfTriggerToHideData;

    //Functions
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag != "base")
        {
            didCollitionInLast2Sec = true;
            StartCoroutine("StartPressAnim");
            StartCoroutine("SetcollitionBoolean");
        }
    }

    private IEnumerator StartPressAnim()
    {
        GetComponent<Animator>().SetBool("CollistionHappened", true);
        GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(timeOfPressAnim);
        GetComponent<Animator>().SetBool("CollistionHappened", false);
        dataAnimator.gameObject.SetActive(true);
        if(didCollitionInLast2Sec)
        {
            if(isInfoShowing)
            {
                dataAnimator.SetTrigger(nameOfTriggerToHideData);
                didCollitionInLast2Sec = false;
                isInfoShowing = false;
            }
            else
            {
                dataAnimator.SetTrigger(nameOfTriggerToShowData);
                didCollitionInLast2Sec = false;
                isInfoShowing = true;
            }
        }
    }

    private IEnumerator SetcollitionBoolean()
    {
        didCollitionInLast2Sec = true;
        yield return new WaitForSeconds(timeOfPressAnim);
        didCollitionInLast2Sec = false;
    }
}