using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Signalization : MonoBehaviour
{
    [SerializeField] private float _fadeSpeed = 2f;

    private readonly float _minVolume = 0;
    private readonly float _maxVolume = 1f;

    private AudioSource _audio;
    private Coroutine _fadeJob;

    private void Start() 
    {
        _audio = GetComponent<AudioSource>();
        _audio.volume = _minVolume;
    }

    public void Toggle(bool isWorking) 
    {
        if(_fadeJob != null)
            StopCoroutine(_fadeJob);

        _fadeJob = StartCoroutine(FadeVolume(isWorking ? _maxVolume: _minVolume));
    }

    private IEnumerator FadeVolume(float targetVolume) 
    {
        _audio.Play();

        while(_audio.volume != targetVolume) 
        {
            yield return null;
            _audio.volume = Mathf.MoveTowards(_audio.volume, targetVolume, _fadeSpeed * Time.deltaTime);
        }

        if(_audio.volume == _minVolume)
            _audio.Stop();
    }
}
