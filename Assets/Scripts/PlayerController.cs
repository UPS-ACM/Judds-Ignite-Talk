using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
	
	public float speed = 5f;
	public float jumpPower = 250f;
	
	private Rigidbody body;

	// Use this for initialization
	void Start () {
		body = GetComponent<Rigidbody>();
		body.useGravity = false;
	}
	
	// FixedUpdate is called a set number of times every second regardless of framerate
	void FixedUpdate () {
		if (transform.position.y > 3f) {
			body.AddForce(new Vector3(0, -9f, 0));
		}
		else if (transform.position.y < 1f) {
			body.AddForce(new Vector3(0, 4f, 0));
		}
		
		float forward = Input.GetAxis("Vertical");
		float sideways = Input.GetAxis("Horizontal");
		
		body.AddForce(new Vector3(forward * speed, 0, -sideways * speed));
		
		if (Input.GetButtonDown("Jump") && transform.position.y < 3f) {
			body.AddForce(new Vector3(0, jumpPower, 0));
		}
	}
}
