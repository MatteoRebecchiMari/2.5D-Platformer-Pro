using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Character controller
    CharacterController _controller;

    // Start is called before the first frame update
    void Start()
    {
        _controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        HandleMovements();
    }

    [SerializeField]
    float _motionSpeed = 3f;

    [SerializeField]
    float _gravity = 1.0f;

    [SerializeField]
    float _jumpHeight = 15.0f;

    float _yMotion = 0f;

    void HandleMovements()
    {
        // Get Motion input
        float horizontalMotion = Input.GetAxis("Horizontal");

        // Move the X axis (horizontal)
        float xMotion = horizontalMotion * _motionSpeed;

        // HANDLE Y MOTION (Gravity + jumping)

        // Handle Jumping (only the the character is not on air --> grounded + Hitting Spacebar in keyboard)
        if (_controller.isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            _yMotion = _jumpHeight;
        }

        // Handle Gravity if the character is NOT GROUNDED
        if (_controller.isGrounded == false)
        {
            // Apply gravity to Y Motion
            _yMotion -= _gravity;
        }

        Vector3 motionVector = new Vector3(xMotion, _yMotion, 0);
    
        // Move the character combining all motions
        _controller.Move(motionVector * Time.deltaTime);

    }

}
