using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private double _totalItTime = 0;
    public double totalItTime
    {
        get
        {
            return _totalItTime;
        }
    }

    public void addItTime(double itTime)
    {
        _totalItTime += itTime;
    }
    public void makeIt()
    {
        this.gameObject.AddComponent<It>();
    }
    public void unmakeIt()
    {
        Destroy(GetComponent<It>());
    }
}
