using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField]
    private GameObject localPlayerGameObject;
    [SerializeField][Range(0f, 1f)]
    private float followSpeed = 1f;
    [SerializeField]
    private Vector3 offset = Vector3.zero;
    private Vector3 velocity = Vector3.zero;

    #region MonoBehaviour Callbacks

    void Update()
    {
        if (localPlayerGameObject != null)
        {
            this.transform.position = Vector3.SmoothDamp(this.transform.position, localPlayerGameObject.transform.position, ref velocity, followSpeed) + offset;
        }
    }

    #endregion

    public void SetLocalPlayer(GameObject player)
    {
        localPlayerGameObject = player;
    }
}
