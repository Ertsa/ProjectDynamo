using UnityEngine;
using System.Collections;

public class CamFollow : MonoBehaviour {

	public GameObject target = null;
	public bool orbitY = false;

	private Vector3 positionOffset = Vector3.zero;

	// Use this for initialization
	void Start () {
		positionOffset = transform.position - target.transform.position;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (target != null)
		{
			transform.LookAt(target.transform);
				                       }
		if (orbitY) {
						transform.RotateAround (target.transform.position, Vector3.up, Time.deltaTime * 60);

						transform.position = target.transform.position + positionOffset;
				}
	}
}
