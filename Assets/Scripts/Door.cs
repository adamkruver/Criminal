using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Door : MonoBehaviour
{
    [SerializeField] private UnityEvent<bool> IsPlayerInside;

    private void OnTriggerEnter(Collider other) 
    {
        if(other.TryGetComponent<Player>(out Player player)) 
            IsPlayerInside?.Invoke(true);
    }

    private void OnTriggerExit(Collider other) 
    {
        if(other.TryGetComponent<Player>(out Player player)) 
            IsPlayerInside?.Invoke(false);
    }
}