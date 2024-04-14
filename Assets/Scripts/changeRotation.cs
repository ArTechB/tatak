using System.Collections;
using System.Collections.Generic;
using Unity.XR.CoreUtils;
using UnityEngine;

public class changeRotation : MonoBehaviour
{
    //Fields
    public XROrigin xrOrigin;
    [SerializeField] Transform camera;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //switch (xrOrigin.Camera.transform.eulerAngles.y - (xrOrigin.Camera.transform.eulerAngles.y % 360) * 360)
        //{
        //    case 0f... 45f:
        //        {
        //            break;
        //        }
        //    case 315f... 360f:
        //            {
        //            break;
        //        }
        //    case 
        //}
        this.transform.LookAt(camera);

        Debug.Log(xrOrigin.Camera.transform.eulerAngles.y);
    }
}
