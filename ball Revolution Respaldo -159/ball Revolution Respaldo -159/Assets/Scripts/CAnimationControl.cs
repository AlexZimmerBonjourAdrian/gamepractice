using UnityEngine;
using System.Collections;
//using UnityEditor.Animations;
public class CAnimationControl : MonoBehaviour {

	private Animator _animator;
	private static int ANIM_IDLE =Animator.StringToHash("Idle");
	private static int	ANIM_SCALE=Animator.StringToHash("Scale");
	// Use this for initialization
	private const int STATE_IDLE= 0;
	private const int  STATE_SCALE = 1;
	private int _State;

	public void Start()
	{
		_animator = GetComponent<Animator> ();
		_State = 0;
	}
	public void SetState(int aState)
	{
		_State = aState;
		if (_State == STATE_IDLE) 
		{
			_animator.Play (ANIM_IDLE);
		}
		else if (_State == STATE_SCALE) 
		{
			_animator.Play (ANIM_SCALE);
		}
	}
	public void Update()
	{
		TestScale ();
		Debug.Log (_State);
		if (_State == STATE_IDLE) 
		{

		}
		else if (_State == STATE_SCALE) 
		{
			if (_animator.GetCurrentAnimatorStateInfo (0).length >= 0.99f) 
			{
				SetState (STATE_IDLE);
			}	
		}
	}

	void OnCollisionEnter(Collision other)
	{
		if (other.collider.gameObject.tag == "Ball") 
		{
			SetState (STATE_SCALE);
		}
	}
	public void TestScale()
	{
		if(Input.GetKeyDown(KeyCode.S))
		{

			SetState (STATE_SCALE);
		}
	}


}
