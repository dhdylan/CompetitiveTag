using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class It : MonoBehaviour
{
    private PlayerManager thisPlayer;
    void Update()
    {
    }

    void Awake()
    {
        thisPlayer = GetComponent<PlayerManager>();
    }
}
