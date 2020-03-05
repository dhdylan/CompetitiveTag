using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class It : MonoBehaviour
{
    private PlayerManager thisPlayer;
    void Update()
    {
        this.thisPlayer.addItTime(Time.deltaTime);
    }

    void Awake()
    {
        thisPlayer = GetComponent<PlayerManager>();
    }
}
