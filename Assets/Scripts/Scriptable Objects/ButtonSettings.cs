using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ButtonSettings", menuName = "Button Settings", order = 51)]
public class ButtonSettings : ScriptableObject
{
    public KeyCode leftButton;
    public KeyCode rightButton;
    public KeyCode upButton;
    public KeyCode downButton;
    public KeyCode jumpButton;
    public KeyCode tagButton;
}