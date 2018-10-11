using UnityEngine;
using System.Collections;

public class CLaucher : MonoBehaviour {

	private bool _inPlay = false;
	private Rigidbody _rigidbody;
	public float _launchForce= 550F;

	void Start()
	{
		_inPlay = false;
		_rigidbody = GetComponent<Rigidbody> ();	
	}
	void Update()
	{
		Launch ();
	}
	public void Launch()
	{
		if (Input.GetKey (KeyCode.Space)) 
		{
			if(_inPlay == false)
			{
				_rigidbody.AddForce (-Vector3.forward *_launchForce* Time.deltaTime, ForceMode.Impulse);
				_rigidbody.useGravity = true;
				_inPlay = true;
			}
		}
		if (Input.GetKeyDown (KeyCode.G)) 
		{
			_rigidbody.useGravity = true;
		}
	}
	void OnCollisionEnter(Collision _Collision)
	{
		if (_Collision.gameObject.tag == "Box") 
		{
			_inPlay = false;
		}
	}
}
