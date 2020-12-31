using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{

    [SerializeField]
    private float _speed = 1.0f;

    [SerializeField]
    private Transform _pointA, _pointB;

    // Current target
    Transform _target;

    private void Awake()
    {
        _target = _pointA;
    }

    // Update is called once per frame
    void Update()
    {
        HandleMoving();
    }


    void HandleMoving()
    {
        // Current position
        Vector3 currentPosition = transform.position;

        // Ping Pong Target Logic
        if(currentPosition == _pointA.position)
        {
            _target = _pointB;
        }

        if(currentPosition == _pointB.position)
        {
            _target = _pointA;
        }


        // Move to the target position
        transform.position = Vector3.MoveTowards(currentPosition, _target.position, _speed * Time.deltaTime);

    }

}
