using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;
using UnityEngine.XR.Interaction.Toolkit;

public class ActivateTelepotationRay : MonoBehaviour
{
    //Fields - Value Types
    private bool IsRightInteractorInUse;
    private bool IsLeftInteractorInUse;

    //Fields - Reference Types
    [SerializeField] private GameObject leftTeleportationRay;
    [SerializeField] private GameObject rightTeleportationRay;

    [SerializeField] private InputActionProperty leftActivate;
    [SerializeField] private InputActionProperty rightActivate;

    private void FixedUpdate()
    {
        leftTeleportationRay.SetActive(!IsLeftInteractorInUse && leftActivate.action.ReadValue<Vector2>().x != 0);
        rightTeleportationRay.SetActive(!IsRightInteractorInUse && rightActivate.action.ReadValue<Vector2>().x != 0 );
    }

    //The following functions change the state of the booleans "IsRightInteractorInUse" and
    // "IsLeftInteractorInUse", In order to allow creating teleportation ray only when hands are free.
    //It is a subscriber of the "Select Entered" and the "Select Exited" events, located in the
    //"XR Interactor" component on each hand.
    public void SetRightInteractorMode_InUse()
    {
        IsRightInteractorInUse = true;
    }

    public void SetRightInteractorMode_NotInUse()
    {
        IsRightInteractorInUse = false;
    }

    public void SetLeftInteractorMode_InUse()
    {
        IsLeftInteractorInUse = true;
    }

    public void SetLeftInteractorMode_NotInUse()
    {
        IsLeftInteractorInUse = false;
    }
}