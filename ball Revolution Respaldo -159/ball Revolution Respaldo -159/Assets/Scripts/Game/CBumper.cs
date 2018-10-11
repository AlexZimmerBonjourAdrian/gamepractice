using UnityEngine;
using System.Collections;

public class CBumper : PointsGiver {


	public float cameraShake = 0.008f;

	private CameraTricks _Camera;
	bool _scaling;
	float _scaleRate = 0.05f;
//	private Vector3 _normalScale;
	// Use this for initialization
	private void Awake()
	{
		_Camera = GameObject.Find("Main Camera").GetComponent<CameraTricks> ();
	}

	void OnCollisionEnter(Collision _Collision)
	{
		if(_Collision.gameObject.tag == "Ball")
		{
			AddPoints ();
			_Camera.Shake (cameraShake);
		}
	}

}
