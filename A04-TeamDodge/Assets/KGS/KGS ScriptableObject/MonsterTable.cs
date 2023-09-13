using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "MonsterTable", menuName = "ScriptableObjects/MonsterTable", order = 1)]
public class MonsterTable : ScriptableObject
{

    [Serializable]
    public struct TABLE
    {
        [SerializeField] public ItemData[]  itemDropArray;
        [SerializeField] public int         hp;
    }

    public TABLE[] monsterTable;

}
