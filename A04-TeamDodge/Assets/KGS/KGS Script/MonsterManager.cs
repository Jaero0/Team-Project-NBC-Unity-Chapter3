using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class MonsterManager : MonoBehaviour
{

    private static MonsterManager I = null;
    public static MonsterManager Instance => I;


    public MonsterTable.TABLE[] MonsterTable => m_monsterTable.monsterTable;

    public GameObject TargetGameObject => m_targetGameObject;


    public void AddMonsterDieEvent(Action<int, Vector3> action)
    {
        m_monsterDieEvent += action;
    }

    public void CallMonsterDieEvent(int identifier, Vector3 position)
    {
        m_monsterDieEvent.Invoke(identifier, position);
    }


    private void Awake()
    {

        //싱글턴을 적용합니다.
        Debug.Assert(Instance == null);
        I = this;

    }


    private void OnDestroy()
    {
        //싱글턴을 해제합니다.
        I = null;
    }


    private void Start()
    {
        InvokeRepeating("CreateMonster", 0, m_monsterSpawnData.monsterSpawnTime);
        InvokeRepeating("CreateBullet", 0, m_monsterSpawnData.bulletSpawnTime);
        AddMonsterDieEvent(OnMonsterDieEvent);
    }


    private void CreateMonster()
    {

        if(!m_monsterSpawnOnOff)
        {
            return;
        }

        float radian = UnityEngine.Random.Range(0, Mathf.PI * 2.0f);

        Vector2 position = new Vector2(Mathf.Cos(radian) * m_monsterSpawnData.monsterSpawnDistance, Mathf.Sin(radian) * m_monsterSpawnData.monsterSpawnDistance);

        int select          = UnityEngine.Random.Range(0, m_monsterSpawnData.monsterPrefabArray.Length);
        var monster         = Instantiate(m_monsterSpawnData.monsterPrefabArray[select], position, Quaternion.identity);

    }


    private void CreateBullet()
    {

        if (!m_bulletSpawnOnOff)
        {
            return;
        }

        //생성될 위치를 계산하고 
        float   radian      = UnityEngine.Random.Range(0, Mathf.PI * 2.0f);
        Vector3 position    = new Vector2(Mathf.Cos(radian) * m_monsterSpawnData.bulletSpawnDistance, Mathf.Sin(radian) * m_monsterSpawnData.bulletSpawnDistance);

        //생성합니다.
        int select                          = UnityEngine.Random.Range(0, m_monsterSpawnData.bulletPrefabArray.Length);
        var bullet                          = Instantiate(m_monsterSpawnData.bulletPrefabArray[select], position, Quaternion.identity);
        var bulletScript                    = bullet.GetComponent<Bullet>();
        var bulletMovementDirection         = bullet.GetComponent<MovementBase>();
        bulletScript.TargetTag              = "Player";
        bulletMovementDirection.Direction   = Vector3.Normalize(TargetGameObject.transform.position - position);

    }


    private void OnMonsterDieEvent(int identifier, Vector3 position)
    {

        if(MonsterTable[identifier].itemDropArray.Count() != 0)
        {
            var select = UnityEngine.Random.Range(0, MonsterTable[identifier].itemDropArray.Count());
            ItemSpawner.Instance.MakeDropItem(MonsterTable[identifier].itemDropArray[select], position);
        }
        

    }

    [SerializeField] private GameObject         m_targetGameObject;

    [SerializeField] private MonsterTable       m_monsterTable;
    [SerializeField] private MonsterSpawnData   m_monsterSpawnData;

    [SerializeField] private bool               m_monsterSpawnOnOff;
    [SerializeField] private bool               m_bulletSpawnOnOff;


    private event Action<int, Vector3> m_monsterDieEvent;

}
