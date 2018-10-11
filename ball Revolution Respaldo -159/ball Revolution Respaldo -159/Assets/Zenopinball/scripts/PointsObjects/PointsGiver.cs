using UnityEngine;
using System.Collections;

public abstract class PointsGiver : MonoBehaviour {

	public int points = 10;
	public string message = "";

	CLevelManager _levelManager;

	// Use this for initialization
	protected void Start () {
		_levelManager = GameObject.Find("CLevelManager").GetComponent<CLevelManager>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}



	protected void AddPoints()
	{
		
		_levelManager.AddPoints(points);
		_levelManager.Message(message);
	}
}
