using System.Collections;
using System.Collections.Generic;
using System;
using TMPro;
using UnityEngine;

namespace Com.MyCompany.MyGame
{
    public class UIMatchTimer : MonoBehaviour
    {
        GameManager gameManager;
        TextMeshProUGUI tMProComponent;

        void Start()
        {
            gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
            tMProComponent = GetComponent<TextMeshProUGUI>();
        }

        void Update()
        {
            tMProComponent.SetText(Math.Round(gameManager.matchTime, 2).ToString());
        }
    }
}