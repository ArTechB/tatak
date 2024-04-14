using System.Collections;
using System.Collections.Generic;
using Unity.XR.CoreUtils;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.Interaction.Toolkit;

public class BlackHover : MonoBehaviour
{
    //Fields
    [SerializeField] private Animator teleportHover;
    [SerializeField] private Transform feet;


    //Functions
    public void OnSelect()
    {
        if(feet.gameObject.active)
        {
            StartCoroutine(fadeAfterTeleport());
        }
    }

    public IEnumerator fadeAfterTeleport()
    {
        teleportHover.SetTrigger("isTeleporting");
        yield return new WaitForSeconds(0.67777f);
        teleportHover.SetTrigger("back");
    }
}