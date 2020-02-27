using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserInput : MonoBehaviour
{
    private MovementController movementController;
    private MovementInput movementInput;

    void Start()
    {
        movementInput = new MovementInput();
        movementController = GetComponent<MovementController>();
    }
    void Update()
    {
        movementInput.GetInput();
        movementController.Move(movementInput);
        Debug.Log(movementInput.directionalInput + "      &&      " + movementInput.jump);
    }
}
