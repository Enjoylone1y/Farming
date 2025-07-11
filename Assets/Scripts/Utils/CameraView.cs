using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraView : MonoBehaviour
{
    private static readonly string CAMERA_VIEW_TAG = "CameraView";
    private CinemachineConfiner cinemachineConfiner;
    private CameraView _instance;
    public CameraView Instance { get { return _instance; } }

    private void Awake()
    {
        _instance = this;
        cinemachineConfiner = GetComponent<CinemachineConfiner>();
    }

    private void Start()
    {
        //TODO д╛хо
        OnSceneLoaded();
    }

    public void OnSceneLoaded()
    {
        GameObject obj = GameObject.FindGameObjectWithTag(CAMERA_VIEW_TAG);
        if (obj != null) { 
            PolygonCollider2D collider2D = obj.GetComponent<PolygonCollider2D>();
            if (collider2D != null) {
                cinemachineConfiner.m_BoundingShape2D = collider2D;
                cinemachineConfiner.InvalidatePathCache();
            }
        }
    }
}
