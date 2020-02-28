using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserInput : MonoBehaviour
{
    private MovementController movementController;
    private TaggingController taggingController;
    private InputObject inputObject;

    void Start()
    {
        inputObject = new InputObject();
        movementController = GetComponent<MovementController>();
        taggingController = GetComponent<TaggingController>();
    }
    void Update()
    {
        inputObject.GetInput();
        movementController.Move(inputObject);
       taggingController.taggerGameObject.SetActive(inputObject.tag);
    }
}
public class InputObject
{
    public Vector3 directionalInput;
    public bool jump;

    public bool tag;

    public void GetInput()
    {
        directionalInput = new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        jump = Input.GetKey(KeyCode.Space);
        tag = Input.GetKey(KeyCode.Mouse0);
    }
}