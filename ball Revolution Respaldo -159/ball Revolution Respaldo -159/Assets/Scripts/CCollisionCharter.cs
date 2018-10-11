using UnityEngine;
using System.Collections;

public class CCollisionCharter : MonoBehaviour {


	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnCollisionEnter(Collision _Enter)
	{
		if (_Enter.gameObject.tag == "Ball") 
		{
			
		}
	}
}
