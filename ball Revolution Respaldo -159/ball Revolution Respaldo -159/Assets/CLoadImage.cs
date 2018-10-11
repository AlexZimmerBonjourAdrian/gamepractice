using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
public class CLoadImage : MonoBehaviour 
{
	private RawImage _rawImage;
//	private List<Texture> _Texture;
//	private Dictionary<string,AudioClip> _TextureList;
	private Texture _Texture;

	public void Start()
	{
		_rawImage = GetComponent<RawImage> ();
		_Texture = Resources.Load<Texture> ("Stage01");
//		_rawImage.texture = _Texture;
		_rawImage.texture = _Texture;
	}

	public void SetImage(string Level)
	{
		_Texture = Resources.Load<Texture> (Level);
//		_rawImage.texture = _Texture;
//		_rawImage.texture = _Texture;
		_rawImage.texture = _Texture;
	}
//	public void Update()
//	{
//		
//	}
//	private void 
	// Use this for initialization
//	private void Start () 
//	{
//		_Texture = new List<Texture> ();
////		_TextureList = new Dictionary<string, Texture> ();
//		Texture[] TextureAssets = Resources.LoadAll<Texture> ("Texture/");
//
//		for (int i = 0; i < TextureAssets.Length; i++)
//		{
//			_TextureList.Add (TextureAssets [i].name, TextureAssets[i]);
//		}
//	}
//	public void AddTexture(string name)
//	{
//		for (int i = _Texture.Count - 1; i >= 0; i--)
//		{
//			if(_Texture[i].name == name)
//				_rawImage.texture = _Texture [i].name;
//		}
//	}
//	// Update is called once per frame
//	void Update () 
//	{
//		
//	}

}
