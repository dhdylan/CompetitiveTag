using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;

public class UIPlayerItTime : MonoBehaviour
{
    Player player;
    TextMeshProUGUI tMProComponent;

    void Start()
    {
        player = GameObject.Find("Player").GetComponent<Player>();
        tMProComponent = GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        tMProComponent.SetText(Math.Round(player.totalItTime, 2).ToString());
    }
}
