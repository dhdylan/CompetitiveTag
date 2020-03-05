using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;

public class UIPlayerItTime : MonoBehaviour
{
    public PlayerManager player;
    TextMeshProUGUI tMProComponent;

    void Start()
    {
        tMProComponent = GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        tMProComponent.SetText(Math.Round(player.totalItTime, 2).ToString());
    }
}
