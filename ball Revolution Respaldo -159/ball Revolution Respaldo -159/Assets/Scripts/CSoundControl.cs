using UnityEngine;
using System.Collections;

public class CSoundControl : MonoBehaviour 
{

	public enum _SoundSelection 
	{
		Bumper,
		Flipper,
		Rumpler,
		Ligths,
		Launch,
		FallHole,
		Esenarie,
		HitSpider,
        Lapide

	};
	public _SoundSelection _Sound;
	private int _Random;

	void OnCollisionEnter(Collision _collision)
	{
		_Random = Random.Range (0, 2);
		if (_collision.gameObject.tag == "Ball") 
		{

            if (_Sound == _SoundSelection.Bumper)
            {
                if (_Random == 0)
                {
                    CAudioManager.Inst.PlaySFX("FX01B",false,null);
                }
                if (_Random == 1)
                {
                    CAudioManager.Inst.PlaySFX("FX02B", false, null);
                }
                if (_Random == 2)
                {
                    CAudioManager.Inst.PlaySFX("FX03B", false, null);
                }
            }

            else if (_Sound == _SoundSelection.Flipper)
                CAudioManager.Inst.PlaySFX("FX01F", false, null);
            else if (_Sound == _SoundSelection.Rumpler)
                CAudioManager.Inst.PlaySFX("FX03B", false, null);

            else if (_Sound == _SoundSelection.FallHole)
                CAudioManager.Inst.PlaySFX("FX01F", false, null);
            else if (_Sound == _SoundSelection.Launch)
                CAudioManager.Inst.PlaySFX("FX01F", false, null);

            else if (_Sound == _SoundSelection.Lapide)
            {

                if (_Random == 0)
                {
                    CAudioManager.Inst.PlaySFX("FX01R", false, null);
                }
                if (_Random == 1)
                {
                    CAudioManager.Inst.PlaySFX("FX02R", false, null);
                }
                if (_Random == 2)
                {
                    CAudioManager.Inst.PlaySFX("FX03R", false, null);
                }
            }
		}
	}
}
