using UnityEngine;
using System.Collections;

public class CKick : MonoBehaviour {

	public float Force = 100f;
	// Use this for initialization

	void OnCollisionEnter(Collision collision)
	{
		if (collision.transform.tag == "Ball") 
		{
			if (collision.rigidbody.velocity.magnitude < Constants.Ball.MaxVelocity) 
			{
				float x = collision.rigidbody.velocity.x > 0 ? Force : -Force;
				float z = collision.rigidbody.velocity.z > 0 ? Force : -Force;
				collision.rigidbody.AddForce (new Vector3 (x, 0f,z ));
			}
		}
	}
}
