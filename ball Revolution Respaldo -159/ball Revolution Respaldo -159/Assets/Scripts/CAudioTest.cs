using UnityEngine;
using System.Collections;

public class CAudioTest : MonoBehaviour {

	private int _Random;


	public void Awake()
	{
		
	}
	void Start () 
	{
		RandomMusic ();
	}

	// Update is called once per frame
	void Update ()
	{
       // CheckRandomMusic();
		//		if (Input.GetKeyDown (KeyCode.Space))
		//			CAudioManager.Inst.PlaySFX ("FX299", false, null);
		//
		//		if (Input.GetKeyDown (KeyCode.Alpha1))
		//			CAudioManager.Inst.PlaySFX ("Gems", true, null);
		//		if (Input.GetKeyDown (KeyCode.Alpha2))
		//			CAudioManager.Inst.StopSFX ("Gems");

	}
	private void RandomMusic ()
	{
		_Random = Random.Range (0, 6);
		if (_Random == 0)
		{
			CAudioManager.Inst.PlayMusic ("Level1MA");
		} 
		else if (_Random == 1) 
		{
			CAudioManager.Inst.PlayMusic ("Level2MA");
		} 
		else if (_Random == 2)
		{
			CAudioManager.Inst.PlayMusic ("Level3MA");
		}
		else if (_Random == 3)
		{
			CAudioManager.Inst.PlayMusic ("Level4MA");
		}
        else if (_Random == 4)
        {
            CAudioManager.Inst.PlayMusic("Level5MA");
        }
        else if (_Random == 5)
        {
            CAudioManager.Inst.PlayMusic("Level6MA");
        }


    }
    /*
    public void CheckRandomMusic()
    {
        if (CAudioManager.Inst.GetMusic().clip.l >= 0.99f)
        {
            RandomMusic();
        }
    }
    */
}

