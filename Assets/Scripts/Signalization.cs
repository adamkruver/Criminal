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
    private Coroutine _fadeJob;

    private void Start() 
    {
        _audio = GetComponent<AudioSource>();
        _audio.volume = _minVolume;
    }

    private IEnumerator FadeVolume(float targetVolume) 
    {
        _audio.Play();

        while(_audio.volume != targetVolume) {

            yield return null;
            _audio.volume = Mathf.MoveTowards(_audio.volume, targetVolume, _fadeSpeed * Time.deltaTime);
        }

        if(_audio.volume == _minVolume)
            _audio.Stop();
    }

    public void Run() 
    {
        if(_fadeJob != null)
            StopCoroutine(_fadeJob);

        _fadeJob = StartCoroutine(FadeVolume(_maxVolume));
    }

    public void Stop() 
    {
        if(_fadeJob != null)
            StopCoroutine(_fadeJob);

        _fadeJob = StartCoroutine(FadeVolume(_minVolume));
    }
}
