using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    private CharacterController2D characterController2D;

    void Start()
    {
        characterController2D = GetComponent<CharacterController2D>();
    }

    public void Move(InputObject inputObject)
    {
        characterController2D.Move(inputObject.directionalInput * Time.fixedDeltaTime, inputObject.crouch, inputObject.jump);
    }
}
