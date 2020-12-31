using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Character controller
    CharacterController _controller;

    // UI Manager reference
    UIManager _uiManager;

    // Start is called before the first frame update
    void Start()
    {
        _controller = GetComponent<CharacterController>();

        _uiManager = GameObject.Find("UIManager").GetComponent<UIManager>();
        if(_uiManager == null)
        {
            Debug.LogError("UIManager null!");
        }

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

    // Cache y motion value
    float _yMotion = 0f;

    // Handle double jump activation
    bool _canDoubleJump = false;

    void HandleMovements()
    {
        // Get Motion input
        float horizontalMotion = Input.GetAxis("Horizontal");

        // Move the X axis (horizontal)
        float xMotion = horizontalMotion * _motionSpeed;

        // HANDLE Y MOTION (Gravity + jumping)

        // Handle Jumping (only the the character is not on air --> grounded + Hitting Spacebar in keyboard)
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (_controller.isGrounded)
            {
                _yMotion = transform.position.y + _jumpHeight;
                _canDoubleJump = true;
            }
            // Handle double jump Hitting Spacebar in keyboard
            else if (_canDoubleJump)
            {
                _canDoubleJump = false;
                _yMotion = transform.position.y + _jumpHeight;
            }
        }
        else
        {
            // Handle Gravity if the character is NOT GROUNDED
            if (_controller.isGrounded == false)
            {
                // Apply gravity to Y Motion
                _yMotion -= _gravity;
            }
        }

        Vector3 motionVector = new Vector3(xMotion, _yMotion, 0);
    
        // Move the character combining all motions
        _controller.Move(motionVector * Time.deltaTime);

    }

    [SerializeField]
    int _coinsCount = 0;

    // Increase coin count by one
    public void AddCoin()
    {
        _coinsCount++;
        _uiManager.UpdateCoinDisplay(_coinsCount);
    }


}
