using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private double totalItTime = 0;
    public void addItTime(double itTime)
    {
        totalItTime += itTime;
    }
    public void makeIt()
    {
        this.gameObject.AddComponent<It>();
        GetComponent<SpriteRenderer>().material.SetColor("Red", Color.red);
    }
    public void unmakeIt()
    {
        Destroy(GetComponent<It>());
        GetComponent<SpriteRenderer>().material.SetColor("White", Color.white);
    }
}
