using UnityEngine;
using System.Collections;

public class CParticuleControl : MonoBehaviour {

    private ParticleSystem _system;
    private float _elapsedTime = 0;

    void Awake()
    {
        _system = GetComponent<ParticleSystem>();
        //		if (!_system.loop)
        //		{
        //			Destroy (gameObject, _system.startLifetime);
        //		}
        //		StopSystem();
    }
    void Update()
    {
        if (!_system.loop && _system.isPlaying)
        {
            _elapsedTime += Time.deltaTime;
            //			if (_elapsedTime > _system.startLifetime)
            //				Destroy (gameObject);
        }
    }
    public void StartSystem()
    {
        _system.Play();
    }

    public void StopSystem()
    {
        _system.Stop();
    }

    public void PauseSystem()
    {
        _system.Pause();
    }

    public void ClearSystem()
    {
        _system.Clear();
    }
}
