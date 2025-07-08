using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [Header("属性配置")]
    public float moveSpeed = 0.0f;
    public float runSpeed = 0.0f;

    private Rigidbody2D rigidbody;
    private PlayerInputSettings playerInput;
    private PlayerAnimation playerAnimation;

    private Vector2 velocity = Vector2.zero;

    /// <summary>
    /// 玩家朝向
    /// </summary>
    public CharactorDirection PlayerDirection {  get { return _playerDirection; } }
    private CharactorDirection _playerDirection = CharactorDirection.Down;

    /// <summary>
    /// 玩家操作
    /// </summary>
    public CharactorAction PlayerAction { get { return _playerAction; } }
    private CharactorAction _playerAction = CharactorAction.None;

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        playerAnimation = GetComponent<PlayerAnimation>();
        playerInput = new PlayerInputSettings();
        playerInput.Game.Action.started += OnPlayerActionStart;
        playerInput.Game.Action.canceled += OnPlayerActionEnd;
    }

    private void OnEnable()
    {
        playerInput.Game.Enable();
    }

   
    private void FixedUpdate()
    {
        // 速度
        Vector2 v = playerInput.Game.Move.ReadValue<Vector2>();
        if (v.x != 0 && v.y != 0) v *= 0.8f;
        v *= moveSpeed * Time.deltaTime;
        velocity.Set(v.x, v.y);
        rigidbody.velocity = velocity;
    }

    
    void Update()
    {
          // 方向
        if (velocity.x > 0)
        {
            _playerDirection = CharactorDirection.Right;
        }
        else if (velocity.x < 0)
        {
            _playerDirection = CharactorDirection.Left;
        }
        else if (velocity.y > 0)
        {
            _playerDirection = CharactorDirection.Up;
        }
        else if (velocity.y < 0)
        {
            _playerDirection = CharactorDirection.Down;
        }
    }

    // 动作
    private void OnPlayerActionStart(InputAction.CallbackContext context)
    {
        Debug.Log("OnPlayerActionStart");
        if (velocity.sqrMagnitude > 0) return;
        _playerAction = CharactorAction.UseTool;
        playerAnimation.PlayerAction(_playerAction, ToolTypes.Axe);
    }

    private void OnPlayerActionEnd(InputAction.CallbackContext context)
    {
        Debug.Log("OnPlayerActionEnd");
        _playerAction = CharactorAction.None;
    }


    private void OnDisable()
    {
        playerInput.Game.Disable();
    }
}
