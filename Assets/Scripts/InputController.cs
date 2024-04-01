using System;
using UnityEngine;

public class InputController : MonoBehaviour
{
    [SerializeField] private GameObject _player;
    private IControllable _controllable;
    private GameInput _gameInput;
    private bool _isJumping = false;

    private void Awake()
    {
        _gameInput = new GameInput();
        _gameInput.Enable();

        if (_player.TryGetComponent(out IControllable controllable))
            _controllable = controllable;
        else
            throw new NullReferenceException("IControllable not value assigned");
    }

    private void OnEnable()
    {
        _gameInput.GamePlay.Jump.performed += OnJumpPerformed;
    }

    private void OnJumpPerformed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        _isJumping = true;
    }

    private void OnDisable()
    {
        _gameInput.GamePlay.Jump.performed -= OnJumpPerformed;
    }

    private void Update()
    {
        ReadMovement();
        ReadJump();
    }

    private void ReadMovement()
    {
        var inputDirection = _gameInput.GamePlay.Movement.ReadValue<Vector2>();

        _controllable.Move(inputDirection);
    }

    private void ReadJump()
    {
        if (_isJumping && _controllable != null)
        {
            _controllable.Jump();
            _isJumping = false;
        }
    }
}