using UnityEngine;
using System.Collections;

public class CameraTricks : MonoBehaviour {

	Vector3 _startPos;
	Quaternion _startRot;
	float _shakeIntensity;
	float _shakeDecay = .1f;
	private float _intensity=0.5f;
	// Use this for initialization
	void Start () {
		_startPos = gameObject.transform.position;
		_startRot = gameObject.transform.rotation;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Input.GetKeyDown (KeyCode.W)) 
		{
			Shake (_intensity);
		}

		if (_shakeIntensity > 0) 
		{
			gameObject.transform.position = _startPos + Random.insideUnitSphere * _shakeIntensity;
			gameObject.transform.rotation = new Quaternion(
				_startRot.x + Random.Range(-_shakeIntensity, _shakeIntensity) * 0.2f,
				_startRot.y + Random.Range(-_shakeIntensity, _shakeIntensity) * 0.2f,
				_startRot.z + Random.Range(-_shakeIntensity, _shakeIntensity) * 0.2f,
				_startRot.w + Random.Range(-_shakeIntensity, _shakeIntensity) * 0.2f);
			_shakeIntensity -= _shakeDecay;
		}

		if (_shakeIntensity <= 0) 
		{
			transform.position = _startPos;
			transform.rotation = _startRot;
		}
	}

	public void Shake(float intensity) {
		_shakeIntensity = intensity;
	}
}
