using UnityEngine;
using System.Collections;
//using UnityEditor.Animations;

public class CAnimatorontroler : MonoBehaviour {

	private float _time;
	private Animator _Animator;
	private const int STATE_IDLE =0;
	private const int STATE_HIT = 1;
	private const int STATE_SCARED = 3;
	private int _State=0;
	private float _TimerStates;
	public float _RandomEyesState;
	public static int ANIM_IDLE = Animator.StringToHash("Idle");
	public static int ANIM_EYES = Animator.StringToHash("EyesAnimation");
	public static int ANIM_HIT = Animator.StringToHash("Hit");
//	private int _Layer = 1;
	private float _timeGame = 10f;

	public void Start()
	{
		
		_Animator = GetComponent<Animator> ();
		_State = 0;
		_timeGame = 10 * Time.deltaTime;
//		_time = 1;
//		_TimerStates = 1f * Time.deltaTime;

	}
//	private void OnPrevStateExit()
//	{
//		if(aSt)
//		
//	}
	private void setState(int aState)
	{
		_State = aState;
		if (_State == STATE_IDLE) 
		{
			
		}
		if (_State == STATE_HIT) 
		{
			
		}
		if (_State == STATE_SCARED) 
		{
			
		}
	}
	public void Update()
	{
		
		if (_State == STATE_IDLE) 
		{
			_Animator.Play (ANIM_IDLE);
//			if(_TimerStates <= 0f)
//			setState (STATE_HIT);
			if (_Animator.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.99f) 
			{
				AnimationEyes ();
				_Animator.Play(ANIM_EYES);

			}

		}
		else if (_State == STATE_HIT) 
		{
			_Animator.Play (ANIM_HIT);
//			_Animator.SetFloat ("Blend", 1);
		}
		else if (_State == STATE_SCARED) 
		{

		}
	}
	private void AnimationEyes ()
	{
		
		_RandomEyesState = Random.Range (-1, 1);
		_Animator.SetFloat ("Time", _RandomEyesState);
	}

	void OnTriggerEnter(Collider _Collision)
	{
		if (_Collision.gameObject.tag == "Ball") 
		{
			Debug.Log ("FUNCIONA");
			setState (STATE_HIT);
		}
	}
}
