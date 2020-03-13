using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CountdownTimerScript : MonoBehaviour
{
    [SerializeField]
    private Text countdownTimerUI;
    [SerializeField]
    private float _countdownTime = 5f;
    [SerializeField]
    private PreGameManager preGameManager;
    private bool _countingDown = false;
    
    public float countdownTime
    {
        get { return _countdownTime; }
        set { _countdownTime = value; }
    }

    public bool countingDown
    {
        get
        {
            return _countingDown;
        }
        set
        {
            _countingDown = value;
            Debug.Log(_countingDown);
            if (!_countingDown)
            {
                countdownTimerUI.text = "Waiting for players...";
                _countdownTime = 5f;
            }
        }
    }

    void Update()
    {
        if (_countingDown)
        {
            _countdownTime -= Time.deltaTime;
            countdownTimerUI.text = "Match Starting in " + Mathf.Round(_countdownTime).ToString();
            if (_countdownTime <= 0f)
            {
                preGameManager.loadMatch();
            }
        }
    }
}
