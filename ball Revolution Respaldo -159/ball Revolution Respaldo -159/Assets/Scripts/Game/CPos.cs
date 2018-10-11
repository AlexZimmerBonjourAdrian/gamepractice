using UnityEngine;
using System.Collections;

public class CPos : MonoBehaviour {

	public GameObject _CBlockAsset;
//	void Start()
//	{
//		
//	}

	void OnTriggerExit(Collider _Collision)
	{
		if(_Collision.gameObject.tag == "Ball")
		{
		_CBlockAsset.transform.position = transform.position;
		}
	}
}
