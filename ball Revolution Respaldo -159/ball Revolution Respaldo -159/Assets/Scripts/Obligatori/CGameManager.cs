using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
public class CGameManager : MonoBehaviour {

	public static CGameManager Inst
	{
		get 
		{
			if (_inst == null) 
			{
				GameObject obj = new GameObject ("CGameManager");
				return obj.AddComponent<CGameManager> ();
			}
			return _inst;
		}
	}
	private static CGameManager _inst;
	private bool _activatePause = false;
	private AsyncOperation _currentLoadingScene;
	// Use this for initialization
	public void Awake()
	{
		if (_inst != null && _inst != this) 
		{
			Destroy (gameObject);
			return;
		}
		DontDestroyOnLoad (this.gameObject);
		_inst = this;
	}
	// Update is called once per frame
	void Update ()
	{
//		Debug.Log (IsLoadingScene ());
		PauseControl ();
	}
	public void LateUpdate()
	{
		if (_currentLoadingScene != null) 
		{
			if (_currentLoadingScene.isDone) 
			{
				_currentLoadingScene = null;
			}
		}
	}
	private void PauseControl()
	{
		if (Input.GetKeyDown (KeyCode.P)) 
		{
			_activatePause = !_activatePause;
			if (_activatePause == true) 
			{
				Time.timeScale = 0;
			} 
			else if (_activatePause == false)
			{
				Time.timeScale = 1;
			}
		}
	}
	public bool IsLoadingScene()
	{
		return _currentLoadingScene != null && !_currentLoadingScene.isDone;
	}
	public void LoadScene(int index)
	{
		SceneManager.LoadScene (name);
	}
	public void LoadScene(string name)
	{
		SceneManager.LoadScene (name);
	}
	public void LoadSceneAsync(string name)
	{
		_currentLoadingScene = SceneManager.LoadSceneAsync (name);
	}
	public void LoadSceneAsyncAddictive(string name)
	{
		_currentLoadingScene = SceneManager.LoadSceneAsync(name,LoadSceneMode.Additive);
	}

}
