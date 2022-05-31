using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class WaypointAction : MonoBehaviour
{
    [SerializeField] private UnityEvent OnEnterWaypoint;

    private void OnTriggerEnter(Collider other) 
    {
        OnEnterWaypoint?.Invoke();
    }
}
