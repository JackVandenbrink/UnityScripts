using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleFreeCamFollow: MonoBehaviour {

	Camera cam;
	public Transform target;
	public float height;
	public float maxDistance;

	private float distance;
	// Use this for initialization
	void Start () {
		
		cam = GetComponent<Camera> ();
		if (target == null) {
			Debug.Log (this.name + ": No Target Set");
		}
	}
	
	// Update is called once per frame
	void Update () {

		//TODO: Lerp to max distance from player
		Vector3 camLoc = new Vector3(cam.transform.position.x,0,cam.transform.position.z);
		Vector3 pawnLoc = new Vector3 (target.position.x, 0, target.position.z);

		distance = Vector3.Distance(camLoc, pawnLoc);


		if (distance > maxDistance) {
			float distanceToTravel = distance - maxDistance;
			Vector3 dir = camLoc - pawnLoc;

			Vector3 destinationLoc = target.position +  (dir.normalized * maxDistance);
			destinationLoc = new Vector3 (destinationLoc.x,height,destinationLoc.z);
			cam.transform.position = destinationLoc;

		}


		cam.transform.LookAt(target);

	}
}
