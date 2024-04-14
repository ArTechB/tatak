using System.Collections;
using System.Collections.Generic;
using Unity.XR.CoreUtils;
using UnityEngine;

public class feetRotaion : MonoBehaviour
{

    //Fields
    [SerializeField] private XROrigin xrOrigin;
    private Transform thisTransform;

    //Functions
    private void Awake()
    {
        thisTransform = this.GetComponent<Transform>();
    }

    private void Update()
    {
        thisTransform.eulerAngles = new Vector3 (0, xrOrigin.Camera.transform.eulerAngles.y+180f, 0);
    }
}