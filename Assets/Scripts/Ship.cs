using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour {

	public bool isShowTrack = false;
	private Steering[] steerings;
	public float maxSpeed = 5.0f;
	public float maxForce = 2.0f;
	protected float sqrMaxSpeed;
	public float mass = 1.0f;
	public Vector3 velocity;
	public float damping = 0.9f;
	public float computeInterval = 0.2f;

	private Vector3 moveDistance;
	private Vector3 steeringForce;
	private Vector3 acceleration;
	private Rigidbody _rigidbody;
	private float timer;
	void Start () {
		steeringForce = new Vector3(0,0,0);
		sqrMaxSpeed = maxSpeed * maxSpeed;
		moveDistance = new Vector3(0,0,0);
		timer = 0.0f;

		steerings = GetComponents<Steering>();
		_rigidbody = GetComponent<Rigidbody>();
	}
	
	void Update () {
		timer += Time.deltaTime;
		steeringForce = new Vector3(0,0,0);  

		if (timer > computeInterval)
		{
			foreach (Steering s in steerings)
			{
				if (s.enabled)
					steeringForce += s.Force() * s.weight;
			}

			steeringForce = Vector3.ClampMagnitude(steeringForce, maxForce);
			acceleration = steeringForce / mass;

			timer = 0.0f;
		}
	}

	private void FixedUpdate() {

		velocity += acceleration * Time.fixedDeltaTime; 
		
		if (velocity.sqrMagnitude > sqrMaxSpeed)
			velocity = velocity.normalized * maxSpeed;
		
		moveDistance = velocity * Time.fixedDeltaTime;
	
		if (isShowTrack)
			Debug.DrawLine(transform.position, transform.position + moveDistance, Color.white, 30.0f);
	
		_rigidbody.MovePosition(_rigidbody.position + moveDistance);
		// _rigidbody.position = _rigidbody.position + moveDistance;

		if (velocity.sqrMagnitude > 0.00001)
		{
			Vector3 newForward = transform.forward;
			if (acceleration.z >= 0.0f) {
				newForward = Vector3.Slerp(transform.forward, velocity, damping * Time.deltaTime);
			}
			transform.forward = newForward;
		}
	}
}
