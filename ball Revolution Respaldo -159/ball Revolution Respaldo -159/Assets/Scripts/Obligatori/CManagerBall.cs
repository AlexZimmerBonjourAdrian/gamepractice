using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CManagerBall : MonoBehaviour {

	private float _BallHole= 3f;
	public Transform _pos;
	private static CManagerBall _inst;
    public CLevelManager _LevelManager;
	public float GetBallHole()
	{
		return _BallHole;
	}
	public static CManagerBall Inst
	{
		get
		{
			if(_inst != null)
			return _inst;
				GameObject obj = new GameObject ("CManagerBall");
				return obj.AddComponent<CManagerBall> ();

		}
	}

	private List<CBall> _ballList;
	private GameObject _ballAsset;
	private void Awake()
	{
		_inst = this;
		if (_inst != null && _inst != this) 
		{
			Destroy (gameObject);
			return;
		}
		_ballAsset = Resources.Load<GameObject> ("Ball");
		_ballList = new List<CBall> ();
	}

	// Use this for initialization
	// Update is called once per frame
	void Update () 
	{
        _LevelManager.SetBallHoleText();
		Debug.Log (_ballList.Count.ToString() +  " Numero de Balas");
		Debug.Log (_BallHole.ToString() + " Ballas Restates");

		for (int i = _ballList.Count - 1; i >= 0; i--)
		{
			if (_ballList [i] == null)
				_ballList.RemoveAt (i);
		}
			if (_BallHole > 0 && _ballList.Count <= 0)
			{
				_BallHole -= 1;
				CreateBall (_pos.position);
			}

	}
	public void CreateBall(Vector3 aPos)
	{
		GameObject obj = (GameObject)Instantiate (_ballAsset, aPos, Quaternion.identity);
		CBall newball = obj.AddComponent<CBall> ();
		_ballList.Add (newball);
	}

}
