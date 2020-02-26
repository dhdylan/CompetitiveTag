using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public float matchTime = 300f;

    void Start()
    {

    }

    void Update()
    {
        if(matchTime > 0f)
        {
            matchTime -= Time.deltaTime;
        }
        else
        {
            //set a game state to stopped
        }
    }
}
