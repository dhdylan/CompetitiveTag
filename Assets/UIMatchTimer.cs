using System.Collections;
using System.Collections.Generic;
using System;
using TMPro;
using UnityEngine;

public class UIMatchTimer : MonoBehaviour
{
    GameManager gameManager;
    TextMeshPro tMProComponent;

    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        tMProComponent = GetComponent<TextMeshPro>();
    }

    void Update()
    {
        tMProComponent.SetText(Math.Round(gameManager.matchTime, 2).ToString());
    }
}
