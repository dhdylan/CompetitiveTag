using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Photon.Pun;

public class MovementController : MonoBehaviourPun
{
    [SerializeField]
    private CharacterController2D characterController2D;

    void Start()
    {
        if (this.transform.parent.transform.GetComponent<PhotonView>().IsMine)
        {
            UserInputController.OnMovementButtonPressed += Move;
        }

        if(characterController2D == null)
        {
            Debug.LogError(this.name + " has not been assigned a CC2D.");
        }
    }

    public void Move(MovementInput movementInput)
    {
        characterController2D.Move(movementInput.directionalInput * Time.fixedDeltaTime, movementInput.crouch, movementInput.jump);
    }

    void OnDestroy()
    {
        UserInputController.OnMovementButtonPressed -= Move;
    }
}
