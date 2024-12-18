using System.Collections;
using System.Collections.Generic;
using System.Net.Security;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class PlayerScript : MonoBehaviour
{
    Animator _playerAnim;
    private Vector2 _input;
    private CharacterController _characterController;
    private Vector3 _direction;

    [SerializeField] private float smoother = 0.05f;
    private float _currentVelocity;
    
    [SerializeField] private float gravityMultiplier = 1.0f;
    private float _gravity = -4f;

    [SerializeField] private float speed;
    private float _velocity;

    public Vector3 checkPoint;

    private Rigidbody rb;
    [SerializeField] private float _jumpPower;

    public float hSpeed = 2.0F;
    public float vSpeed = 2.0F;


    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        checkPoint = transform.position;
        Cursor.visible = false;
        _characterController = GetComponent<CharacterController>();
        _playerAnim = GetComponent<Animator>();

        
    }

    private void Update()
    {
        ApplyGravity();
        ApplyRotation();
        ApplyMovement();
        ReturnPlayerSpeed();
        
        if (_input == Vector2.zero)
        {
            _playerAnim.SetFloat("Speed", 0);
        }
        else
        {
            _playerAnim.SetFloat("Speed", 1);
        }
        
    }

    private void ReturnPlayerSpeed() => _playerAnim.SetFloat("Speed", 0);

    private void ApplyGravity()
    {
        if (IsGrounded() && _velocity < 0.0f)
        {
            _velocity = -1.0f;
            _playerAnim.SetFloat("Height", 0);
        }
        else
        {
            _velocity += _gravity * gravityMultiplier * Time.deltaTime;
            
            _characterController.Move(_direction * _jumpPower * Time.deltaTime);
        }

        _direction.y = _velocity;

    }

    private void ApplyRotation()
    {
        if (_input.sqrMagnitude == 0) return;

        var targetAngle = Mathf.Atan2(_direction.x, _direction.z) * Mathf.Rad2Deg;

        var angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref _currentVelocity, smoother);

        _currentVelocity = angle;
    }

    public void Move(InputAction.CallbackContext context)
    {
        _input = context.ReadValue<Vector2>();

        _direction = new Vector3(_input.x, 0, _input.y);

        Debug.Log(_input);
    }

    private void ApplyMovement()
    {
        _characterController.Move(_direction * speed * Time.deltaTime);
    }

    public void Jump(InputAction.CallbackContext context)
    {
        if (!context.started) return;
        if (!IsGrounded()) return;
        _playerAnim.SetFloat("Height", 5);

        _velocity = +_jumpPower;

    }

    private bool IsGrounded() => _characterController.isGrounded;
}

