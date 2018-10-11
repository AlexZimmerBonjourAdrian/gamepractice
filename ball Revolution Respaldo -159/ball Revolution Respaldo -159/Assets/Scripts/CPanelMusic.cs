using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class CPanelMusic : MonoBehaviour {



	public Toggle _readyToggle;
	public bool _PauseMusic = false;

	// Use this for initialization
	void Start () 
	{
		_readyToggle = GetComponent<Toggle> ();
		_readyToggle.isOn = false;
	}

	// Update is called once per frame
	void Update () 
	{
		MuteMusic ();
	}
	public void MuteMusic()
	{
		
		if (_readyToggle.isOn == true)
			CAudioManager.Inst.PauseMusic ();
		else 
		{
			CAudioManager.Inst.ResumenMusic ();
		}
	}

}
