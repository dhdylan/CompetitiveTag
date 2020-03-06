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
            
            taggingController.taggerGameObject.SetActive(inputObject.tag); // this should be an RPC call
        }
    }

    void FixedUpdate()
    {
        if (photonView.IsMine)
        {
            movementController.Move(inputObject);
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
    public float directionalInput;
    public bool jump;
    public bool crouch;
    public bool tag;

    public void GetInput(ButtonSettings buttonSettings)
    {
        directionalInput = -Convert.ToInt16(Input.GetKey(buttonSettings.leftButton)) + Convert.ToInt16(Input.GetKey(buttonSettings.rightButton)); //probably dont need to do these fancy conversions
        crouch = Input.GetKey(buttonSettings.downButton);
        jump = Input.GetKey(buttonSettings.jumpButton);
        tag = Input.GetKey(buttonSettings.tagButton);
    }
}