using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserInput : MonoBehaviour
{
    private MovementController movementController;

    void Start()
    {
        movementController = GetComponent<MovementController>();
    }
    void Update()
    {
    }
}
