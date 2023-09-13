using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ItemSpawnData", menuName = "ScriptableObjects/ItemSpawnData", order = 3)]
public class ItemSpawnData : ScriptableObject
{
    public GameObject[] ItemPrefabs;
}