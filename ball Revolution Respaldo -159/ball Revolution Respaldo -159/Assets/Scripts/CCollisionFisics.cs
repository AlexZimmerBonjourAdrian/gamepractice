using UnityEngine;
using System.Collections;

public class CCollisionFisics : MonoBehaviour {

	public float euler = 2.7f;
	private Vector3 _pos;
	// Update is called once per frame



	public void FixedUpdate()
	{
		_Fisic();	
	}
	private void _Fisic()
	{
		if (_pos == null)
			return;
		
		float PositionX = transform.position.x;
		float PositionY = transform.position.y;
		float VelocityX = transform.position.x;
		float VelocityY = transform.position.y * euler;
		_pos= new Vector3 (VelocityX,0,VelocityY);
	}
}
