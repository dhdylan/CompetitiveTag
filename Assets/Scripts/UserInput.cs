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
    private TaggingController taggingController;
    private InputObject inputObject;
    [SerializeField]
    private ButtonSettings inputButtonOptions; 
    #endregion

    #region MonoBehaviour Callbacks
    void Start()
    {
        inputObject = new InputObject();
        movementController = GetComponent<MovementController>();
        taggingController = GetComponent<TaggingController>();
    }
    void Update()
    {
        if (photonView.IsMine)
        {
            inputObject.GetInput(inputButtonOptions);
            movementController.Move(inputObject.directionalInput);
            if (inputObject.jump)
            {
                movementController.Jump();
            }
            taggingController.taggerGameObject.SetActive(inputObject.tag); // this should be an RPC call
        }
    }
    #endregion

    #region IPunObservable Implementation
    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo messageInfo)
    {
        if (stream.IsWriting)
        {
            //send
        }
        else
        {
            //recieve
        }
    } 
    #endregion

}


public class InputObject
{
    public Vector3 directionalInput;
    public bool jump;

    public bool tag;

    public void GetInput(ButtonSettings buttonSettings)
    {
        directionalInput = new Vector3(-Convert.ToInt16(Input.GetKey(buttonSettings.leftButton)) + Convert.ToInt16(Input.GetKey(buttonSettings.rightButton)), Convert.ToInt16(Input.GetKey(buttonSettings.downButton))); //probably dont need to do these fancy conversions
        jump = Input.GetKey(buttonSettings.jumpButton);
        tag = Input.GetKey(buttonSettings.tagButton);
    }
}