using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class endingButton : MonoBehaviour
{
    //Contants
    private const float timeOfPressAnim = 2f;

    //Fields
    private bool didCollitionInLast2Sec;
    private bool isInfoShowing;

    //Functions
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.tag == "hand")
        {
            Debug.Log("hand touched");
            didCollitionInLast2Sec = true;
            StartCoroutine("StartPressAnim");
            StartCoroutine("SetcollitionBoolean");
            StartCoroutine(executeButtonFunctionality());
        }
    }

    private IEnumerator executeButtonFunctionality()
    {
        if(didCollitionInLast2Sec)
        {
            yield return new WaitForSeconds(timeOfPressAnim);
            if (this.tag == "exitButton")
            {
                Application.Quit();
            }
            else if (this.tag == "restartButton")
            {
                UnityEngine.SceneManagement.SceneManager.LoadScene("Opening");
            }
        }
    }

    private IEnumerator StartPressAnim()
    {
        GetComponent<Animator>().SetBool("CollistionHappened", true);
        GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(timeOfPressAnim);
        GetComponent<Animator>().SetBool("CollistionHappened", false);
        if (didCollitionInLast2Sec)
        {
            if (isInfoShowing)
            {
                didCollitionInLast2Sec = false;
                isInfoShowing = false;
            }
            else
            {
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
