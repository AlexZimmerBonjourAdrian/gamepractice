using UnityEngine;
using System.Collections;

public class Plunger : MonoBehaviour {

	const float MAX_DISTANCE = 100f;
	const float MAX_PULL_SPEED = 200f;
	const float RESET_SPEED = 0f;
	private float _PULL_SPEED=0;
	public GameObject ball;
	public float maxForce = 2200;
	private Vector3 _startPos;
	public Vector3 _ballStartPos;
	public Vector3 _MoveAmout;
	public Transform _Spawn;

	// Use this for initialization
	void Start () 
	{
//		_active = true;
		_startPos = gameObject.transform.position;
		if(ball != null)
		_ballStartPos = ball.transform.position;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
//		if (!_resetting && _active
//		    && Input.GetKey(KeyCode.Space) 
//		    && Mathf.Abs(gameObject.transform.position.z - _startPos.z) < 1f)
//		{
//			_resetting = false;
//			Vector3 moveAmount = new Vector3(0f, 0f, -PULL_SPEED * Time.deltaTime);
//			gameObject.transform.Translate(moveAmount);
//			ball.transform.Translate(moveAmount);
//		}
//		if (_active && Input.GetKeyUp(KeyCode.Space))
//		{
//			if (Mathf.Abs(transform.position.z) - Mathf.Abs(ball.transform.position.z) < 1f) 
//			{
//				float distance = Mathf.Abs(gameObject.transform.position.z - _startPos.z);
//				ball.GetComponent<Rigidbody>().AddForce(0f, 0f, maxForce * distance);
//			}
//			_resetting = true;
//			_active = false;
//		}
//		if(!_resetting && _active)
//		if (_resetting)
//		{
//			if (gameObject.transform.position.z < _startPos.z)
//			{
//				Vector3 moveAmount = new Vector3(0f, 0f, RESET_SPEED * Time.deltaTime);
//				gameObject.transform.Translate(moveAmount);
//			}
//			else
//				_resetting = false;
//		}

	}
	public void Reload()
	{
		if (ball != null) 
		{
			ball.GetComponent<Rigidbody> ().velocity = Vector3.zero;
			ball.GetComponent<Rigidbody> ().angularVelocity = Vector3.zero;
			ball.transform.localRotation = Quaternion.identity;
			ball.transform.position = _ballStartPos;
		}
	}
	void OnCollisionEnter(Collision collision) 
	{
		Debug.Log("coll");
		ball.GetComponent<Rigidbody>().AddForce(0f, 0f, maxForce * _PULL_SPEED);
	}
	void Update()
	{
//		if (Input.GetKeyDown (KeyCode.Space))
//		{
//
//		} 
		if (ball != null) 
		{
			if (Input.GetKey (KeyCode.Space)) 
			{
				if (_PULL_SPEED >= 10f) 
					_PULL_SPEED += 1f;
				
				_MoveAmout = new Vector3 (transform.position.x, transform.position.y, transform.position.z * _PULL_SPEED);
				transform.Translate (_MoveAmout);
			}
			if (Input.GetKeyUp (KeyCode.Space)) 
			{
				_PULL_SPEED = RESET_SPEED;
				_MoveAmout = _ballStartPos;
			}
		}
	}
}
