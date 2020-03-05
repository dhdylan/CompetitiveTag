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
	
	
	void LateUpdate()
	{
		//if( !useFixedUpdate )
		//	updateCameraPosition();
	}


	void FixedUpdate()
	{
		//if( useFixedUpdate )
		//	updateCameraPosition();
	}


	//void updateCameraPosition()
	//{
	//	if( target == null )
	//	{
	//		transform.position = Vector3.SmoothDamp( transform.position, new Vector3(target.position.x - cameraOffset.x, (target.position.y * yFollowMultiplier) - cameraOffset.y, target.position.z - cameraOffset.z), ref _smoothDampVelocity, smoothDampTime);
	//		return;
	//	}
		
	//	if( target.velocity.x > 0 )
	//	{
 //           transform.position = Vector3.SmoothDamp( transform.position, new Vector3(target.position.x - cameraOffset.x, (target.position.y * yFollowMultiplier) - cameraOffset.y, target.position.z - cameraOffset.z), ref _smoothDampVelocity, smoothDampTime);
 //       }
 //       else
	//	{
	//		var leftOffset = cameraOffset;
	//		leftOffset.x *= -1;
 //           transform.position = Vector3.SmoothDamp(transform.position, new Vector3(target.position.x - leftOffset.x, (target.position.y * yFollowMultiplier) - leftOffset.y, target.position.z - leftOffset.z), ref _smoothDampVelocity, smoothDampTime);
 //       }
 //   }
	
}
