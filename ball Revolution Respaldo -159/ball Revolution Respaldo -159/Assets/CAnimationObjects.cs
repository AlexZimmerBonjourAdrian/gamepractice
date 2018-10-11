using UnityEngine;
using System.Collections;

public class CAnimationObjects : MonoBehaviour {

    private Animator _animator;
    private static int ANIM_IDLE = Animator.StringToHash("Idle");
    private static int ANIM_HIT = Animator.StringToHash("Hit");
    // Use this for initialization
    private const int STATE_IDLE = 0;
    private const int STATE_HIT = 1;
    private int _State;

    public void Start()
    {
        _animator = GetComponent<Animator>();
        _State = 0;
    }
    public void SetState(int aState)
    {
        _State = aState;
        if (_State == STATE_IDLE)
        {
            _animator.Play(ANIM_IDLE);
        }
        else if (_State == STATE_HIT)
        {
            _animator.Play(ANIM_HIT);
        }
    }
    public void Update()
    {
        TestScale();
        Debug.Log(_State);
        if (_State == STATE_IDLE)
        {

        }
        else if (_State == STATE_HIT)
        {
            if (_animator.GetCurrentAnimatorStateInfo(0).length >= 0.99f)
            {
                SetState(STATE_IDLE);
            }
        }
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.collider.gameObject.tag == "Ball")
        {
            SetState(STATE_HIT);
        }
    }
    public void TestScale()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {

            SetState(STATE_HIT);
        }
    }


}
