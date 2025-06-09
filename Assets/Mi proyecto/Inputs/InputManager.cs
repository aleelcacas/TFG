using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    public static InputManager instance;

    public bool PausaOpenCloseInput { get; private set; }
    public bool DashPressed { get; private set; }
    public bool JumpPressed { get; private set; }
    public bool AttackPressed { get; private set; }
    public bool InteractPressed { get; private set; }
    public Vector2 MoveInput { get; private set; }

    private PlayerInput _playerInput;
    private InputAction _pausaOpneCloseAction;
    private InputAction _moveAction;
    private InputAction _jumpAction;
    private InputAction _dashAction;
    private InputAction _attackAction;
    private InputAction _interact;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }

        _playerInput = GetComponent<PlayerInput>();
        _pausaOpneCloseAction = _playerInput.actions["Pausa"];
        _moveAction = _playerInput.actions["Move"];
        _jumpAction = _playerInput.actions["Jump"];
        _dashAction = _playerInput.actions["Dash"];
        _attackAction = _playerInput.actions["Attack"];
        _interact = _playerInput.actions["Interact"];
    }

    private void Update()
    {
        PausaOpenCloseInput = _pausaOpneCloseAction.WasPressedThisFrame();
        MoveInput = _moveAction.ReadValue<Vector2>();
        DashPressed = _dashAction.WasPressedThisFrame();
        JumpPressed = _jumpAction.WasPressedThisFrame();
        AttackPressed = _attackAction.WasPressedThisFrame();
        InteractPressed = _interact.WasPressedThisFrame();
    }
}
