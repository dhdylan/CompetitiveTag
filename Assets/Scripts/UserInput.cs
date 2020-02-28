using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class UserInput : MonoBehaviour
{
    private MovementController movementController;
    private TaggingController taggingController;
    private InputObject inputObject;
    [SerializeField]
    private ButtonSettings inputButtonOptions;

    void Start()
    {
        inputObject = new InputObject();
        movementController = GetComponent<MovementController>();
        taggingController = GetComponent<TaggingController>();
    }
    void Update()
    {
        inputObject.GetInput(inputButtonOptions);
        movementController.Move(inputObject);
        taggingController.taggerGameObject.SetActive(inputObject.tag); // this needs to be changed to more of an event system style
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