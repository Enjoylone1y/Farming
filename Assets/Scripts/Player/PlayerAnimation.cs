using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

public class PlayerAnimation : MonoBehaviour
{
    private static readonly string VELOCITY = "velocity";
    private static readonly string VELOCITY_X = "velocityX";
    private static readonly string VELOCITY_Y = "velocityY";

    private static readonly string TRIGGER_PULL = "pull";
    private static readonly string TRIGGER_TOOL = "tool";
    private static readonly string TRIGGER_REAP = "reap";
    private static readonly string TRIGGER_WATERING = "water";

    private List<Animator> animators = new List<Animator>();

    private Rigidbody2D rigidbody;
    private PlayerController playerController;

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        playerController = GetComponent<PlayerController>();
        foreach (var animator in GetComponentsInChildren<Animator>()) animators.Add(animator);
    }

    private void Update()
    {
        SetPlayerAnimation();
    }

    private void SetPlayerAnimation()
    {
        foreach (Animator animator in animators) {
            // 移动和朝向
            animator.SetFloat(VELOCITY, rigidbody.velocity.sqrMagnitude);
            if(rigidbody.velocity.sqrMagnitude != 0)
            {
                animator.SetFloat(VELOCITY_X, rigidbody.velocity.x);
                animator.SetFloat(VELOCITY_Y, rigidbody.velocity.y);
            }
            // 动作
            if (playerController.PlayerAction != CharactorAction.None)
            {
                if (playerController.PlayerAction == CharactorAction.Pull)
                {
                    animator.SetTrigger(TRIGGER_PULL);
                }
                else if (playerController.PlayerAction == CharactorAction.Pull)
                {
                    animator.SetTrigger(TRIGGER_PULL);
                }
                else if (playerController.PlayerAction == CharactorAction.Pull)
                {
                    animator.SetTrigger(TRIGGER_PULL);
                }
                else if (playerController.PlayerAction == CharactorAction.Pull)
                {
                    animator.SetTrigger(TRIGGER_PULL);
                }
            }
        }
    }
}
