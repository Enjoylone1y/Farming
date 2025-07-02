using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ��ɫ����
/// </summary>
public enum CharactorDirection
{
    Up,
    Down,
    Left,
    Right,
}

/// <summary>
/// ��ɫ����
/// </summary>
public enum CharactorAction
{
    None,
    Pull,
    UseTool,
    Wattering,
    Reap,
    Attack
}

/// <summary>
/// ��Ʒ����
/// </summary>
public enum ItemTypes
{
    None,
    Weapon,
    Tool,
    Seed,
}

/// <summary>
/// ��������
/// </summary>
public enum ToolTypes
{
    None,
    /// <summary>
    /// ��ͷ
    /// </summary>
    Axe,
    /// <summary>
    /// ����
    /// </summary>
    Pickaxe,
    /// <summary>
    /// ��ͷ
    /// </summary>
    Hoe,
    /// <summary>
    /// ˮ��
    /// </summary>
    Water,
    /// <summary>
    /// �ջ񹤾�
    /// </summary>
    ReapTool
}


public enum TreeStatus
{
    Children,
    Young,
    Mature,
    Complete,
    Break,
}
