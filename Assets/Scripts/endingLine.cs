using Oculus.Interaction;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class endingLine : MonoBehaviour
{
    //Fields - Reference Types
    [SerializeField] private Canvas endingCanvas;

    //Functions
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("gog");
        if (other.transform.tag != "floor" && other.transform.tag != "wall")
        {
            endingCanvas.gameObject.SetActive(true);
            endingCanvas.GetComponent<Animator>().SetTrigger("endOfTour");
        }
    }
}
