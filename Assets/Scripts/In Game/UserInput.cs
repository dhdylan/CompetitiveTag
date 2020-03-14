using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

using Photon.Pun;
using Photon.Realtime;

public class UserInput : MonoBehaviourPun, IPunObservable
{

    #region Private Fields
    private MovementController movementController;
    private CombatController combatController;
    private InputObject inputObject;

    [SerializeField]
    private ButtonSettings inputButtonOptions; 
    #endregion


    #region MonoBehaviour Callbacks
    void Start()
    {
        inputObject = new InputObject();
        movementController = GetComponent<MovementController>();
        combatController = GetComponent<CombatController>();
    }
    void Update()
    {
        if (photonView.IsMine)
        {
            inputObject.GetInput(inputButtonOptions);

            combatController.taggerGameObject.SetActive(inputObject.tag);
        }
    }

    void FixedUpdate()
    {
        if (photonView.IsMine)
        {
            movementController.Move(inputObject);

            //
        }
    }
    #endregion


    #region IObservable Implementation

    public void OnPhotonSerializeView (PhotonStream stream, PhotonMessageInfo messageInfo)
    {
        if (stream.IsWriting) //send data
        {
            stream.SendNext(inputObject.tag);
        }
        else //recieve data
        {
            inputObject.tag = (bool)stream.ReceiveNext();
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
    public float directionalInput;
    public bool jump;
    public bool crouch;
    public bool tag;
    public bool ability;

    public void GetInput(ButtonSettings buttonSettings)
    {
        directionalInput = -Convert.ToInt16(Input.GetKey(buttonSettings.leftButton)) + Convert.ToInt16(Input.GetKey(buttonSettings.rightButton)); //probably dont need to do these fancy conversions
        crouch = Input.GetKey(buttonSettings.downButton);
        jump = Input.GetKey(buttonSettings.jumpButton);
        tag = Input.GetKey(buttonSettings.tagButton);
        ability = Input.GetKeyDown(buttonSettings.abilityButton);
    }
}