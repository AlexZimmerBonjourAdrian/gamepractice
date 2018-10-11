using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CAudioManager : MonoBehaviour
{
	private static CAudioManager _inst;
	public static CAudioManager Inst
	{
		get
		{ 
			if (_inst != null)
				return _inst;
			GameObject obj = new GameObject ("AudioManager");
			return obj.AddComponent<CAudioManager> ();
		}
	}

	private Dictionary<string,AudioClip> _soundList;
	private AudioSource _musicSource;
	private List<AudioSource> _sfx;

	public AudioSource GetMusic ()
	{
		return _musicSource;
	}
	void Awake ()
	{
		if (_inst != null && _inst != this)
		{
			Destroy (gameObject);
			return;
		}
		_inst = this;
		DontDestroyOnLoad (gameObject);
		Load ();
	}
	void Update()
	{
		
	}

	private void Load()
	{
		_sfx = new List<AudioSource> ();
		_soundList = new Dictionary<string, AudioClip> ();
		AudioClip[] audioAssets = Resources.LoadAll<AudioClip> ("Music/");
		for (int i = 0; i < audioAssets.Length; i++)
		{
			_soundList.Add (audioAssets [i].name, audioAssets [i]);
		}
	}

	public void BuildMusicSource()
	{
		GameObject obj = new GameObject ("Music Source");
		_musicSource = obj.AddComponent<AudioSource> ();
		_musicSource.playOnAwake = false;
		DontDestroyOnLoad (obj);
	}

	public void PlayMusic(string name, bool loops = false, Transform parent = null, Vector3 pos = default(Vector3))
	{
		if (_musicSource == null)
			BuildMusicSource ();

		_musicSource.clip = _soundList [name];
		_musicSource.loop = loops;
		_musicSource.spatialBlend = 0; //2D
		if (parent != null)
			_musicSource.transform.SetParent (parent);
		_musicSource.transform.localPosition = pos;

		_musicSource.Play ();
	}
	public AudioSource PlaySFX(string name, bool loops, Transform parent)
	{
		GameObject obj = new GameObject ("sfx" + name);
		AudioSource source = obj.AddComponent<AudioSource> ();
		source.clip = _soundList [name];
		source.spatialBlend = 0;
		source.loop = loops;
		source.playOnAwake = false;

		if (parent != null)
			source.transform.SetParent (parent);
		source.transform.localPosition = Vector3.zero;
		source.Play ();
		_sfx.Add (source);
		return source;
	}
	public void ResumenMusic()
	{
		for(int i = _soundList.Count-1; i>=0; i--)
		{
				_musicSource.UnPause ();
		}
	}
	public void PauseMusic ()
	{
		for (int i = _soundList.Count - 1; i >= 0; i--) 
		{
				_musicSource.Pause ();
		}
	}
	private void LateUpdate()
	{
		for (int i = _sfx.Count - 1; i >= 0; i--)
		{
			AudioSource source = _sfx [i];
			if (source == null)
            {
				_sfx.RemoveAt (i);
			}
			else if(!source.isPlaying)
			{
				Destroy (source.gameObject);
				_sfx.RemoveAt (i);
			}
		}
	}

	public void StopSFX(string name,bool all = false)
	{
		for (int i = _sfx.Count-1; i >= 0; i--)
		{
			if (_sfx [i].name == name)
			{
				Destroy (_sfx [i]);
				_sfx.RemoveAt (i);
				if (!all)
					break;
			}
		}
	}
}
