using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followPlayer : MonoBehaviour {

    public Transform playerTrans;
    public float lerpVal;
    private Transform desiredPos;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        this.transform.position = new Vector3(Mathf.Lerp(this.transform.position.x, playerTrans.position.x, lerpVal), Mathf.Lerp(this.transform.position.y, playerTrans.position.y, lerpVal), this.transform.position.z);
		
	}
}
