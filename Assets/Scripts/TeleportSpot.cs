using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportSpot : MonoBehaviour
{
    //Fields = Reference Types
    [SerializeField] private Transform boundries;
    [SerializeField] private Material selectedMaterial;
    [SerializeField] private Material unselectedMaterial;

    //Functions
    public void OnHover()
    {
        boundries.gameObject.SetActive(true);
        //GetComponent<MeshRenderer>().material = selectedMaterial;
    }

    public void OnHoverExit()
    {
        boundries.gameObject.SetActive(false);
        //GetComponent<MeshRenderer>().material = unselectedMaterial;
    }
}