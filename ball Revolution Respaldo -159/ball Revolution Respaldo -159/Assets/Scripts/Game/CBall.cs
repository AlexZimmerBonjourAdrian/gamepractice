using UnityEngine;
using System.Collections;

public class CBall : MonoBehaviour 
{

	private Rigidbody _Rigidbody;
	public float _launchForce =550f;
	private Vector3 _Pos;
	private bool _inPlay = false;
	private const float euler = 2.7f;
	private Vector3 _PosFin;
	private float _ReleaseForce;
	private float _maxY = 2f;
	private void Start()
	{
		_Rigidbody = GetComponent<Rigidbody> ();
		_PosFin = Vector3.forward;
	//	_Rigidbody.useGravity = false;
		_inPlay = false;
	}
	private void FixedUpdate()
	{
		if (_Rigidbody.velocity.y >= _maxY) 
		{
			_Rigidbody.velocity = new Vector3 (_Rigidbody.velocity.x, -_maxY, _Rigidbody.velocity.z);

		} 
	}
//	private void Update()
//	{
//
//
//	}
	void OnCollisionEnter(Collision _Collision)
	{
		if (_Collision.gameObject.tag == "DeathLine") 
		{
			Destroy (gameObject);
		}
		if (_Collision.gameObject.tag == "Block") 
		{
			_inPlay = false;
		}
		if (_Collision.gameObject.tag == "Frezze") 
		{
			_Rigidbody.velocity = new Vector3 (_Rigidbody.velocity.x, _Rigidbody.velocity.y, 0);
		}
	}

//	void OnCollisionExit(Collision _Collision)
//	{
////		if (_Collision.gameObject.tag == "Paddle") 
////		{
////			if (Input.GetKey (KeyCode.X) || Input.GetKey (KeyCode.M)) {
////				_Rigidbody.AddForce (_Pos*Time.deltaTime, ForceMode.Impulse);
////			}
////		 if(Input.GetKeyUp(KeyCode.X) || Input.GetKeyUp(KeyCode.M))
////			{
////			_Rigidbody.AddForce (_Pos*Time.deltaTime, ForceMode.Impulse);
////			}
////		}
////		}
//	}



}

