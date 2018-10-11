using UnityEngine;
using System.Collections;

public class CTextureControl : MonoBehaviour {

	Material _Pixel;
	Texture _LookupTexture;
	// Use this for initialization
	void OnEnable()
	{
		Shader shader = Shader.Find ("Pinball/PixelEffects");
		if (_Pixel == null) 
		{
			_Pixel = new Material(shader);
		}
	}
	void OnRenderImage(RenderTexture src, RenderTexture dst)
	{
		_Pixel.SetTexture ("_PlatterTex", _LookupTexture);
		Graphics.Blit (src, dst, _Pixel);
	}
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
