using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class PlayerAnimationState : MonoBehaviour
{
    [SerializeField] private float _animationChangeSpeed = .2f;

    private readonly float _walkSpeed = 1f;
    private readonly float _runSpeed = 2f;

    private Animator _animator;
    
    private float _currentSpeed = .9f;
    private float _speed = 1f;


    private void Update() 
    {
        if(_speed != _currentSpeed) 
        {
            _currentSpeed = Mathf.MoveTowards(_currentSpeed, _speed, _animationChangeSpeed * Time.deltaTime);
            _animator.SetFloat(ThiefAnimator.Speed, _currentSpeed);
        }
    }

    private void Start() 
    {
        _animator = GetComponent<Animator>();
    }

    public void Walk() 
    {
        _speed = _walkSpeed;
    }

    public void Run() 
    {
        _speed = _runSpeed;
    }

    public void StartUpStairs() 
    {
        _animator.SetTrigger(ThiefAnimator.StartWalkingUpTheStrait);
    }

    public void StopUpStairs() 
    {
        _animator.SetTrigger(ThiefAnimator.StopWalkingUpTheStrait);
    }
}
