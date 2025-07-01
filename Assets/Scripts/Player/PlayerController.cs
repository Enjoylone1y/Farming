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
        playerInput = new PlayerInputSettings();
        playerInput.Game.Action.started += OnPlayerAction;
    }

    private void OnEnable()
    {
        playerInput.Game.Enable();
    }

    private void OnPlayerAction(InputAction.CallbackContext context)
    {
        Console.WriteLine("OnPlayerAction");
    }

    private void FixedUpdate()
    {
        // 速度
        Vector2 v = playerInput.Game.Move.ReadValue<Vector2>();
        v *= moveSpeed * Time.fixedDeltaTime;
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

        // 动作
        
    }

    private void OnDisable()
    {
        playerInput.Game.Disable();
    }
}
