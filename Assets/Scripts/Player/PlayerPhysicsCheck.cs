using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPhysicsCheck : MonoBehaviour
{
    [Serializable]
    public class CharacterRay2D
    {
        public Vector3 position;
        public Vector2 direction;
        public float distance;
    }

    public CharacterRay2D[] ray2D;
    public LayerMask checkLayer;
    private RaycastHit2D rayResult;

    private PlayerController playerController;

    void Start()
    {
        playerController = GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        RaysCheck();
    }

    public RaycastHit2D GetRayResult()
    {
        return rayResult;
    }

    private void RaysCheck()
    {
        var direct = (int)playerController.PlayerDirection;
        var ray = ray2D[direct];
        rayResult = Physics2D.Raycast(transform.position + ray.position, ray.direction, ray.distance, checkLayer);
        Color color = rayResult.collider == null ? Color.white : Color.blue;
        Debug.DrawRay(transform.position + ray.position, ray.direction, color);
    }
}
