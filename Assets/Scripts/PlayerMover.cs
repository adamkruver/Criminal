using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    [SerializeField] private Transform _path;
    [SerializeField] private float _speed = 2f;

    private List<Transform> _waypoints = new List<Transform>();

    private int _currentWaypointIndex = 0;

    private void Start() 
    {
        foreach(Transform child in _path) 
            _waypoints.Add(child);
        
        ResetWaypointPosition();
    }

    private void Update() 
    {
        MoveToWaypoint();
    }

    private void MoveToWaypoint() 
    {
        if(_waypoints.Count == 0)
            return;

        var currentPosition = transform.position;
        var targetPosition = _waypoints[_currentWaypointIndex].position;

        transform.position = Vector3.MoveTowards(currentPosition, targetPosition, _speed * Time.deltaTime);

        if(transform.position == targetPosition) 
        {
            _currentWaypointIndex ++;

            if(_currentWaypointIndex >= _waypoints.Count)
                ResetWaypointPosition();
        }
    }

    private void ResetWaypointPosition() 
    {
        if(_waypoints.Count == 0)
            return;

        _currentWaypointIndex = 0;
        transform.position = _waypoints[_currentWaypointIndex].position;
    }
}
