using UnityEngine;
using System.Collections;

public class CGizmo : MonoBehaviour 
{
	public float gizmosize = .75f;
	public Color gizmoColor =Color.yellow;
	private float _Pos;
	private float _ID =0;
	private void Start()
	{
//		_Pos =  Vector3.right;
	}
	void OnDrawGizmos()
	{
		Gizmos.color = gizmoColor;
		Gizmos.DrawWireSphere(transform.position,gizmosize);
		if (_ID == 0) 
		{
			Debug.DrawRay (transform.position + Vector3.zero, -Vector3.right*50f,Color.white,30f);
		} 
//		else if (_ID == 1) 
//		{
//			Gizmos.DrawRay(transform.position,5f,Color.red);
//		}
	}
}
