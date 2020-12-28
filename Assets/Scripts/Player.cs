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

    void HandleMovements()
    {
        // Get Motion input
        float horizontalMotion = Input.GetAxis("Horizontal");

        // Move the X axis (horizontal)
        Vector3 velocityMotion = Vector3.right * horizontalMotion * Time.deltaTime * _motionSpeed;

        // Gravity Motion
        Vector3 gravityMotion = Vector3.zero;

        // Handle Gravity if the character is NOT GROUNDED
        if (_controller.isGrounded == false)
        {
            // Apply gravity
            gravityMotion = Vector3.down * _gravity * Time.deltaTime;
        }

        // Move the character combining velocity + gravity
        _controller.Move(velocityMotion + gravityMotion);

    }

}
