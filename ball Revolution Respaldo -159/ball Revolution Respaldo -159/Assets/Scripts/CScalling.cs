using UnityEngine;
using System.Collections;

public class CScalling : MonoBehaviour{
	[ContextMenu("Scalas")]
	private Vector3 _normalScale;
	private bool _scaling;
	public float scaleTo = 10f;
	private float _scaleRate =50000f;
	[ContextMenu("Objetos")]
	private Transform _meshTransform;

	// Use this for initialization
	public void Start () 
	{
//		base.Start ();
		_scaling = false;
		_normalScale = transform.localScale;
		_meshTransform = gameObject.transform.GetChild (0);

	}
	
	// Update is called once per frame
	public void Update () 
	{
		
		Scaling ();
		ScalingManual ();
	}
	public void ScalingManual()
	{
		
		if (Input.GetKeyDown (KeyCode.S)) {
			if (_meshTransform.localScale.x < 1f)
				_scaleRate = Mathf.Abs(_scaleRate);
			else if (_meshTransform.localScale.x > scaleTo)
				_scaleRate = -Mathf.Abs(_scaleRate);

			_meshTransform.localScale += Vector3.one * _scaleRate;

			if (_meshTransform.localScale.x < 1f)
				_scaling = false;
		}
	}
	public void Scaling()
	{
		if (_scaling)
		{
			if (_meshTransform.localScale.x < 1f)
				_scaleRate = Mathf.Abs(_scaleRate);
			else if (_meshTransform.localScale.x > scaleTo)
				_scaleRate = -Mathf.Abs(_scaleRate);

			_meshTransform.localScale += Vector3.one * _scaleRate;

			if (_meshTransform.localScale.x < 1f)
				_scaling = false;
		}
	}
	void OnCollisionEnter(Collision _CollisionEnter)
	{
		if(_CollisionEnter.gameObject.tag== "Ball")
		_scaling = true;
	}
}
