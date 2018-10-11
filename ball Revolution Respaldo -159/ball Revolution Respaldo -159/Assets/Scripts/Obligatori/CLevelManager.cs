using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class CLevelManager : MonoBehaviour {

	private static int STATE_PLAY = 0;
	private static int STATE_PAUSE = 1;
	private int _state;
	public Transform _Spawn;
	private CLevelManager _LevelManager;
	public Text _ScoreTextObject;
//	public Text hitScoreTextObject;
	public Text _messages;
	public Text _BallHoleText;
	private CManagerBall _BallManager;

	private float _Score;
	private float _BallHole;

	public float GetBallHole()
	{
		return _BallHole;
	}
	public void SetBallHole(float aBallHole)
	{
		aBallHole = _BallHole;
	}
//	private float _hiScore;
//	private _ballRemaining =2;
//	private CPlayer _player;
	// Use this for initialization
	public void CheckBallHole()
	{
		if (_BallHole <= 0) 
		{
			if (Input.GetKeyDown (KeyCode.Return)) 
			{
				CGameManager.Inst.LoadSceneAsync ("Menu");
			}
		}
	}
	private void Start ()
	{
		
		setScoreText ();
		SetMessenger ();

	}
	
	// Update is called once per frame
//	private void CreatePlayer()
//	{
//		GameObject asset = Resources.Load<GameObject> ("Player");
//		GameObject obj = Instantiate (asset, Vector3.zero,Quaternion.identity) as GameObject;
//		_player = obj.GetComponent<CPlayer> ();
//	}

	private void OnPrevStateExit(int aState)
	{
		
		if (_state == STATE_PLAY)
		{
			
		}
		else if (_state == STATE_PAUSE) 
		{
			Time.timeScale = 1;
		}
	}
	private void CreateBall()
	{
//		if (Input.GetKeyDown (KeyCode.Z)) 
//		{
//			CManagerBall.Inst.CreateBall (_Spawn.position);
//		}
	}
	public void SetState(int aState)
	{
		OnPrevStateExit (_state);
		_state = aState;
		if (_state == STATE_PLAY) 
		{

		}
		else if (_state == STATE_PAUSE) 
		{
			Time.timeScale = 0;
		}
	}
	private void SetMessenger()
	{
		_messages.text = "Welcome to Ball revolution";
	}
	public float GetPoints()
	{
		return _Score;
	}
	public void AddPoints(float points)
	{
		_Score += points;
		setScoreText ();
	}

	public void Message(string text)
	{
		_messages.text = text;
		StopCoroutine ("BlankMessage");
		StartCoroutine ("BlankMessage");
	}
	IEnumerator BlankMessage()
	{
		yield return new WaitForSeconds (1);
		_messages.text = "";
	}
	void Update () 
	{

		CheckBallHole ();
		if (_state == STATE_PLAY) 
		{
			if (CheckPause ())
			SetState (STATE_PAUSE);
			CreateBall ();
		}
		else if (_state == STATE_PAUSE)
		{
			if (CheckPause ())
				SetState (STATE_PLAY);
		}
	}
	void setScoreText()
	{
		_ScoreTextObject.text = "Score: " + _Score;
	}
	public void SetBallHoleText()
	{
		_BallHoleText.text = "BallHole: " + _BallManager;
	}

	private bool CheckPause()
	{
		return Input.GetKeyDown (KeyCode.Escape) || Input.GetKeyDown (KeyCode.Return);
	}
}
