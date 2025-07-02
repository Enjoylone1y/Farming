using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 角色朝向
/// </summary>
public enum CharactorDirection
{
    Up,
    Down,
    Left,
    Right,
}

/// <summary>
/// 角色动作
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
/// 物品类型
/// </summary>
public enum ItemTypes
{
    None,
    Weapon,
    Tool,
    Seed,
}

/// <summary>
/// 工具类型
/// </summary>
public enum ToolTypes
{
    None,
    /// <summary>
    /// 斧头
    /// </summary>
    Axe,
    /// <summary>
    /// 稿子
    /// </summary>
    Pickaxe,
    /// <summary>
    /// 锄头
    /// </summary>
    Hoe,
    /// <summary>
    /// 水壶
    /// </summary>
    Water,
    /// <summary>
    /// 收获工具
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
