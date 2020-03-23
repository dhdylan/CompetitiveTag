using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

using Photon.Pun;
using Photon.Realtime;

public class UserInputController : MonoBehaviourPun, IPunObservable
{   

    #region Private Fields

    [SerializeField]
    private ButtonSettings inputButtonOptions;
    private InputObject inputObject;

    #endregion


    #region Events

    public static event Action<MovementInput> OnMovementButtonPressed = delegate { };
    public static event Action OnActiveAbilityButtonPressed = delegate { };
    public static event Action OnTagButtonPressed = delegate { };


    #endregion


    #region MonoBehaviour Callbacks

    void Start()
    {
        inputObject = new InputObject();
    }

    void Update()
    {
        if (photonView.IsMine)
        {
            inputObject.GetAbilityInput(inputButtonOptions);

            if(inputObject.abilityInputs.tag)
                OnTagButtonPressed();

            if (inputObject.abilityInputs.activeAbility)
                OnActiveAbilityButtonPressed();
        }
    }

    void FixedUpdate()
    {
        if (photonView.IsMine)
        {
            inputObject.GetMovementInput(inputButtonOptions);

            //If any movement buttons are pressed
            if (inputObject.movementInputs.directionalInput != 0 || inputObject.movementInputs.crouch || inputObject.movementInputs.jump)
            { 
                OnMovementButtonPressed(inputObject.movementInputs);
            }
        }
    }

    #endregion


    #region IObservable Implementation

    public void OnPhotonSerializeView (PhotonStream stream, PhotonMessageInfo messageInfo)
    {
        if (stream.IsWriting) //send data
        {
            stream.SendNext(inputObject.abilityInputs.tag);
        }
        else //recieve data
        {
            inputObject.abilityInputs.tag = (bool)stream.ReceiveNext();
        }
    }

    #endregion


    #region Private Functions

    [PunRPC]
    private void setObjectActive(GameObject activateObject, bool active)
    {
        activateObject.SetActive(active);
    }

    #endregion

}


public class InputObject
{
    public MovementInput movementInputs;
    public AbilityInput abilityInputs;

    public void GetMovementInput(ButtonSettings buttonSettings)
    {
        movementInputs.directionalInput = -Convert.ToInt16(Input.GetKey(buttonSettings.leftButton)) + Convert.ToInt16(Input.GetKey(buttonSettings.rightButton)); //probably dont need to do these fancy conversions
        movementInputs.crouch = Input.GetKey(buttonSettings.downButton);
        movementInputs.jump = Input.GetKey(buttonSettings.jumpButton);
    }

    public void GetAbilityInput(ButtonSettings buttonSettings)
    {
        abilityInputs.tag = Input.GetKey(buttonSettings.tagButton);
        abilityInputs.activeAbility = Input.GetKeyDown(buttonSettings.abilityButton);
    }
}

public struct MovementInput
{
    public float directionalInput;
    public bool jump;
    public bool crouch;
    private Vector2 vector2;

    public MovementInput(Vector2 vector2) : this()
    {
        this.vector2 = vector2;
    }
}

public struct AbilityInput
{
    public bool tag;
    public bool activeAbility;
}