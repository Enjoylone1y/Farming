using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

public class PlayerAnimation : MonoBehaviour
{
    // 人物速度和朝向
    private static readonly string VELOCITY = "velocity";
    private static readonly string VELOCITY_X = "velocityX";
    private static readonly string VELOCITY_Y = "velocityY";

    // 人物动画key
    private static readonly string TRIGGER_PULL = "pull";
    private static readonly string TRIGGER_TOOL = "tool";
    private static readonly string TRIGGER_REAP = "reap";
    private static readonly string TRIGGER_WATERING = "water";
    private static readonly string TRIGGER_ATTACK = "attack";

    // 工具动画KEY
    private static readonly string TRIGGER_TOOL_AXE = "axe";
    private static readonly string TRIGGER_TOOL_HOE = "hoe";
    private static readonly string TRIGGER_TOOL_PICKAXE = "pickaxe";
    private static readonly string TRIGGER_TOOL_REAP = "reapTool";
    private static readonly string TRIGGER_TOOL_WATER = "water";

    [Header("角色动画")]
    public List<Animator> playerAnimators = new List<Animator>();
    public List<Animator> otherAnimators = new List<Animator>();

    [Header("工具动画")]
    public Animator toolAnimator;

    private Rigidbody2D rigidbody;
    private PlayerController playerController;

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        playerController = GetComponent<PlayerController>();
    }

    private void Update()
    {
        SetPlayerAnimation();
    }

    private void SetPlayerAnimation()
    {
        // 移动和朝向
        foreach (Animator animator in playerAnimators) {
            animator.SetFloat(VELOCITY, rigidbody.velocity.sqrMagnitude);
            if(rigidbody.velocity.sqrMagnitude != 0)
            {
                animator.SetFloat(VELOCITY_X, rigidbody.velocity.x);
                animator.SetFloat(VELOCITY_Y, rigidbody.velocity.y);
            }
        }
        foreach (Animator animator in otherAnimators)
        {
            if (rigidbody.velocity.sqrMagnitude != 0)
            {
                animator.SetFloat(VELOCITY_X, rigidbody.velocity.x);
                animator.SetFloat(VELOCITY_Y, rigidbody.velocity.y);
            }
        }
        if (rigidbody.velocity.sqrMagnitude != 0)
        {
            toolAnimator.SetFloat(VELOCITY_X, rigidbody.velocity.x);
            toolAnimator.SetFloat(VELOCITY_Y, rigidbody.velocity.y);
        }
    }


    public void PlayerAction(CharactorAction action, ToolTypes tool = ToolTypes.None)
    {
        // 动作
        if (playerController.PlayerAction != CharactorAction.None)
        {
            string key = action switch
            {
                CharactorAction.None => "",
                CharactorAction.Pull => TRIGGER_PULL,
                CharactorAction.UseTool => TRIGGER_TOOL,
                CharactorAction.Wattering => TRIGGER_WATERING,
                CharactorAction.Reap => TRIGGER_REAP,
                CharactorAction.Attack => TRIGGER_ATTACK,
            };
            foreach (Animator animator in playerAnimators)
            {
                animator.SetTrigger(key);
            }
        }

        if (tool != ToolTypes.None) {
            string key = tool switch
            {
                ToolTypes.None => "",
                ToolTypes.Axe => TRIGGER_TOOL_AXE,
                ToolTypes.Pickaxe => TRIGGER_TOOL_PICKAXE,
                ToolTypes.Hoe => TRIGGER_TOOL_HOE,
                ToolTypes.Water => TRIGGER_TOOL_WATER,
                ToolTypes.ReapTool => TRIGGER_TOOL_REAP,
            };
            //toolAnimator.SetTrigger(key);
        }
    }
}