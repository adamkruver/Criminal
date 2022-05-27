using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Signalization : MonoBehaviour
{
    private readonly float _minVolume = 0;
    private readonly float _maxVolume = 1f;

    [SerializeField] private float _fadeSpeed = 2f;

    private AudioSource _audio;
    private bool _isSignalizationWorks = false;

    private void Start() 
    {
        _audio = GetComponent<AudioSource>();
        _audio.volume = 0;
    }

    private void Update() 
    {
        FadeVolume();
    }

    private void FadeVolume() 
    {
        if(_isSignalizationWorks) {
            if(_audio.volume == _minVolume) 
                _audio.Play();

            _audio.volume = Mathf.MoveTowards(_audio.volume, _maxVolume, _fadeSpeed * Time.deltaTime);
        }
        else 
        {
            _audio.volume = Mathf.MoveTowards(_audio.volume, _minVolume, _fadeSpeed * Time.deltaTime);

            if(_audio.volume == _maxVolume) 
                _audio.Stop();
        }

    }

    public void Run() 
    {
        _isSignalizationWorks = true;
    }

    public void Stop() 
    {
        _isSignalizationWorks = false;
    }
}
