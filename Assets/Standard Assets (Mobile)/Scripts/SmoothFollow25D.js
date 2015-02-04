
#pragma strict

var target : Transform;
var smoothTime = 0.3;
private var thisTransform : Transform;
private var velocity : Vector3;

function Start()
{
	thisTransform = transform;
	thisTransform.position.x = 1;
}

function Update() 
{
thisTransform.position.y = Mathf.SmoothDamp( thisTransform.position.y, 
		target.position.y, velocity.y, smoothTime);
	thisTransform.position.z = Mathf.SmoothDamp( thisTransform.position.z, 
		target.position.z, velocity.z, smoothTime);
	
}