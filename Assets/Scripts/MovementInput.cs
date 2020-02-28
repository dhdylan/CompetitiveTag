using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class MovementInput
{
    public Vector3 directionalInput;
    public bool jump;

    public void GetInput()
    {
        directionalInput = new Vector3(Input.GetAxisRaw("Horizontal"),Input.GetAxisRaw("Vertical"));
        jump = Input.GetKey(KeyCode.Space);
    }
}
