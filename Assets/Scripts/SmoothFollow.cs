using UnityEngine;
using System.Collections;


public class SmoothFollow : MonoBehaviour
{
	public Transform target;
	public float smoothDampTime = 0.2f;
    [Range(.01f, 1f)]
    public float yFollowMultiplier = .3f;
	[HideInInspector]
	public new Transform transform;
	public Vector3 cameraOffset;
    public bool useFixedUpdate = false;
	
	private Vector3 _smoothDampVelocity;
    private 
	

	void Awake()
	{
		transform = gameObject.transform;
	}

	void FixedUpdate()
	{
        if (useFixedUpdate)
            updateCameraPosition();
    }


    void updateCameraPosition()
    {
        if (target == null)
        {
            transform.position = Vector3.SmoothDamp(transform.position, new Vector3(target.position.x - cameraOffset.x, (target.position.y * yFollowMultiplier) - cameraOffset.y, target.position.z - cameraOffset.z), ref _smoothDampVelocity, smoothDampTime);
            return;
        }
    }

}
