using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree : MonoBehaviour
{
    public TreeConfigSO config;

    public SpriteRenderer treeImg;
    public SpriteRenderer topImg;

    public GameObject topPart;

    public int id;

    [SerializeField]
    private TreeStatus status = TreeStatus.Mature;

    // Start is called before the first frame update
    void Start()
    {
        topImg.sprite = config.topSprite;
        UpdateTreeImg();
    }

    public void UpdateStatus(TreeStatus status)
    {
        this.status = status;
        UpdateTreeImg();
    }

    private void UpdateTreeImg()
    {
        topImg.gameObject.SetActive(status == TreeStatus.Complete);
        treeImg.sprite = config.statusSprite[(int)status];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
