using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "TreeConfigSO", menuName = "GameDatas/TreeConfigSO")]
public class TreeConfigSO : ScriptableObject
{
    public Sprite topSprite;
    public Sprite[] statusSprite;

    public int maxHp;
}
