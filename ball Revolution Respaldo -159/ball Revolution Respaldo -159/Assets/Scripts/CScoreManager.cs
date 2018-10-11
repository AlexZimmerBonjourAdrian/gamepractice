using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class CScoreManager : MonoBehaviour {

	public Text _Text;
	//public CLevelManager _levelManager;
	private string _Score = " ";
	private string _TextString = " ";
	public Text _Exit;
	public Text _ScoreText;
	private CLevelManager _levelManager;
	// Use this for initialization
	void Start () 
	{
		_Text.text = _Score;
		_Exit.text = _TextString;
		_ScoreText.text = _Score;
	}
	// Update is called once per frame
	void Update ()
	{
//		CheckGame ();
		GameOver();
	}
	public void GameOver()
	{
		if (CManagerBall.Inst.GetBallHole() < 0) 
		{
		_ScoreText.text = _levelManager.GetPoints().ToString();
		_Text.text = "Game Over";
		_Exit.text = "Press Return back to Menu";
		}
	}
//	public void CheckGame()
//	{
//		if (CManagerBall.Inst.GetBallHole() < 0) 
//		{
//			_Text.text = _levelManager.Inst.GetPoints ().ToString();
//		}
//	}
}
