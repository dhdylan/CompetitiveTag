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
    private CharacterController2D playerCharacterController2D;

    #region MonoBehaviour Callbacks
    void Start()
    {
        inputObject = new InputObject();
        movementController = GetComponent<MovementController>();
        taggingController = GetComponent<TaggingController>();
        playerCharacterController2D = GetComponent<CharacterController2D>();
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
            stream.SendNext(playerCharacterController2D.transform.position);
            stream.SendNext(playerCharacterController2D.transform.rotation);
            stream.SendNext(playerCharacterController2D.velocity);
        }
        else
        {
            playerCharacterController2D.transform.position = (Vector3)stream.ReceiveNext();
            playerCharacterController2D.transform.rotation = (Quaternion)stream.ReceiveNext();
            playerCharacterController2D.velocity = (Vector3)stream.ReceiveNext();

            float lag = Mathf.Abs((float)(PhotonNetwork.Time - messageInfo.SentServerTime));
            playerCharacterController2D.transform.position += playerCharacterController2D.velocity * lag;
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