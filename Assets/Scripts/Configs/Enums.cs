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
    Kettle,
}
