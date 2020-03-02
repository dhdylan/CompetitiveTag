using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class It : MonoBehaviour
{
    private PlayerManager thisPlayer;
    private CharacterController2D characterController2D;

    void Update()
    {
        this.thisPlayer.addItTime(Time.deltaTime);
    }

    void Awake()
    {
        thisPlayer = GetComponent<PlayerManager>();
    }
}
