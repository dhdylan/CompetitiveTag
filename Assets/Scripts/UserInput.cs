using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

using Photon.Pun;
using Photon.Realtime;

public class UserInput : MonoBehaviourPun, IPunObservable
{
    private MovementController movementController;
    private TaggingController taggingController;
    private InputObject inputObject;
    [SerializeField]
    private ButtonSettings inputButtonOptions;

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
        }

        taggingController.taggerGameObject.SetActive(inputObject.tag); // this should be an RPC call
        movementController.Move(inputObject);
    } 
    #endregion

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo messageInfo)
    {
        if (stream.IsWriting)
        {
            // We own this player: send the others our data
            stream.SendNext(inputObject);
        }
        else
        {
            // Network player, receive data
            inputObject = (InputObject)stream.ReceiveNext();
        }
    }

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