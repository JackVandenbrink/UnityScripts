using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePawn : MonoBehaviour {

	public GameObject pawn;
	public Transform viewpoint;

	public float speed = 1f;
	public float jumpPower = 10f;
	public float groundDist = 2f;



	Rigidbody rb;

	// Use this for initialization
	void Start () {
		if (pawn == null) {
			throw new UnityException ("pawn reference is null");

		}
		rb = pawn.GetComponent<Rigidbody> ();

	}
	
	// Update is called once per frame
	void Update () {
		ProcessMovement ();
	}



	void ProcessMovement() {
		float forwardAxis = Input.GetAxisRaw ("MoveForward");
		float strafeAxis = Input.GetAxisRaw ("MoveStrafe");
		float up = Input.GetAxisRaw ("Jump");

		Vector3 moveBy = new Vector3();

		if (forwardAxis != 0) {
			//moveBy += (Multiply(viewpoint.forward, Vector3.forward)) * forwardAxis;
			moveBy += viewpoint.forward * forwardAxis;
		}

		if (strafeAxis != 0) {
			//moveBy += (Multiply(viewpoint.right, Vector3.right)) * strafeAxis;
			moveBy += viewpoint.right * strafeAxis;
		}

		moveBy.y = 0;
		pawn.transform.Translate (moveBy.normalized * speed * Time.deltaTime);
		if (up != 0) {			
			if (IsGrounded () == true) {
				Vector3 jump = new Vector3 (rb.velocity.x,jumpPower,rb.velocity.z);
				rb.velocity = jump;	
			}
		}
	}

	bool IsGrounded() {
		return Physics.Raycast (transform.position, -Vector3.up, groundDist);
	}
		

}
