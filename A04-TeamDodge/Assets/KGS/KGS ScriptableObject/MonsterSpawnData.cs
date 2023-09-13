using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "MonsterSpawnData", menuName = "ScriptableObjects/MonsterSpawnData", order = 1)]
public class MonsterSpawnData : ScriptableObject
{

    public GameObject[] monsterPrefabArray;
    public float        monsterSpawnTime;
    public float        monsterSpawnDistance;

    public GameObject   bossMonsterPrefab;

    public GameObject[] bulletPrefabArray;
    public float        bulletSpawnTime;
    public float        bulletSpawnDistance;

}
