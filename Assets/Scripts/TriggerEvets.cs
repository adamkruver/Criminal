using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TriggerEvets : MonoBehaviour
{
    [SerializeField] private UnityEvent _onTriggerEnterEvent;
    [SerializeField] private UnityEvent _onTriggerExitEvent;

    private void OnTriggerEnter(Collider other) 
    {
        _onTriggerEnterEvent?.Invoke();
    }

    private void OnTriggerExit(Collider other) 
    {
        _onTriggerExitEvent?.Invoke();
    }
}
