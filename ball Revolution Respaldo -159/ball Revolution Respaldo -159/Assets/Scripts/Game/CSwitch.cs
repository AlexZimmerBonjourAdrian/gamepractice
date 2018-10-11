using UnityEngine;
using System.Collections;

public class CSwitch : MonoBehaviour {

////	public enum _SelectLevel{_ArachneLand,Test2,Test3};
//	public _SelectLevel _Level;

//	public void LoadLevel_ArachneLand()
//	{
//		
//			_Level = _SelectLevel._ArachneLand;
//			
//	}
//	public void LoadLevel_Test2()
//	{
//
//		_Level = _SelectLevel.Test2;
//
//	}
//	public void LoadLevel_Test3()
//	{
//
//		_Level = _SelectLevel.Test3;
//
//	}
//	public void Update()
//	{
//		
//
//	}

//	public float _SelectedLevel;
	public enum _SelectedLevel
	{
		Arachnelad,
		AlienCarnage,
		JackIsBack,
		Dracubunny,
		Shadows,
		
	};

	private _SelectedLevel _Level;

	public void SelectedLevel(string _name)
	{
		CGameManager.Inst.LoadSceneAsync(_name);
	}
	public void SelectedLevelGame(string aName)
	{
		if (aName == "Arachnelad") 
		{
			_Level = _SelectedLevel.Arachnelad;
		}
		else if (aName == "AlienCarnage") 
		{
			_Level = _SelectedLevel.AlienCarnage;
		}
	}
	private void Update()
	{

		ReloadLevel1 ();
		ExitGame ();
	}

	public void SetLevel ()
	{
		if (_Level == _SelectedLevel.Arachnelad) 
		{
			CGameManager.Inst.LoadSceneAsync ("Game3");
		}
		else if (_Level == _SelectedLevel.Dracubunny) 
		{
			CGameManager.Inst.LoadSceneAsync ("Game3");
			
		}
		else if (_Level == _SelectedLevel.JackIsBack) 
		{
			CGameManager.Inst.LoadSceneAsync ("Game3");
			
		}
		else if (_Level == _SelectedLevel.Shadows) 
		{
			CGameManager.Inst.LoadSceneAsync ("Game3");
		}
		else if (_Level == _SelectedLevel.AlienCarnage) 
		{
			CGameManager.Inst.LoadSceneAsync ("Game3");
		}
	}
	private void ReloadLevel1()
	{
		if(Input.GetKeyDown(KeyCode.Alpha1))
		CGameManager.Inst.LoadSceneAsync ("game3");
	}
	private void ExitGame()
	{
		if (Input.GetKeyDown (KeyCode.Escape)) 
		{
			Application.Quit();
		}
	}



}
