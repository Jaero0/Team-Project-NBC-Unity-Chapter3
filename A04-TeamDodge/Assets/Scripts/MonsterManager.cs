using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MonsterManager : MonoBehaviour
{

    static MonsterManager I = null;
    static MonsterManager instance => I;

    public void Awake()
    {

        Debug.Assert(instance == null);
        I = this;

    }

    public void OnDestroy()
    {
        I = null;
    }

    public void Start()
    {

        InvokeRepeating("CreateMonster", 0, monsterSpawnData.spawnTime);

    }

    public void CreateMonster()
    {

        float radian = Random.Range(0, Mathf.PI * 2.0f);

        Vector2 position = new Vector2(Mathf.Cos(radian) * monsterSpawnData.distance, Mathf.Sin(radian) * monsterSpawnData.distance);

        int select = Random.Range(0, monsterSpawnData.monsterPrefabArray.Length);
        Instantiate(monsterSpawnData.monsterPrefabArray[select], position, Quaternion.identity);

    }

    [SerializeField] private MonsterSpawnData monsterSpawnData;
}
