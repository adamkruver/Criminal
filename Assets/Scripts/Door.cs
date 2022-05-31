using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Door : MonoBehaviour
{
    [SerializeField] private UnityEvent OnPlayerEnter;
    [SerializeField] private UnityEvent OnPlayerExit;


    private void OnTriggerEnter(Collider other) 
    {
        if(other.TryGetComponent<Player>(out Player player)) 
            OnPlayerEnter?.Invoke();
    }

    private void OnTriggerExit(Collider other) 
    {
        if(other.TryGetComponent<Player>(out Player player)) 
            OnPlayerExit?.Invoke();
    }
}