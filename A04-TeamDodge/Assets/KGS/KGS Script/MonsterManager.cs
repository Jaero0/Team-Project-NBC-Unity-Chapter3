using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MonsterManager : MonoBehaviour
{

    private static MonsterManager I = null;
    public static MonsterManager Instance => I;


    public GameObject TargetGameObject => targetGameObject;


    /// <summary>
    /// 객체가 만들어 질 때 호출되 초기화 합니다.
    /// </summary>
    public void Awake()
    {

        //싱글턴을 적용합니다.
        Debug.Assert(Instance == null);
        I = this;

    }


    /// <summary>
    /// 객체가 파괴 될 때 호출됩니다.
    /// </summary>
    public void OnDestroy()
    {
        //싱글턴을 해제합니다.
        I = null;
    }


    /// <summary>
    /// 객체가 활성화 될 때 호출되 초기화 합니다.
    /// </summary>
    public void Start()
    {
        InvokeRepeating("CreateMonster", 0, monsterSpawnData.monsterSpawnTime);
        InvokeRepeating("CreateBullet", 0, monsterSpawnData.bulletSpawnTime);
    }


    /// <summary>
    /// 몬스터를 생성합니다.
    /// </summary>
    public void CreateMonster()
    {

        if(!monsterSpawnOnOff)
        {
            return;
        }

        float radian = Random.Range(0, Mathf.PI * 2.0f);

        Vector2 position = new Vector2(Mathf.Cos(radian) * monsterSpawnData.monsterSpawnDistance, Mathf.Sin(radian) * monsterSpawnData.monsterSpawnDistance);

        int select          = Random.Range(0, monsterSpawnData.monsterPrefabArray.Length);
        var monster         = Instantiate(monsterSpawnData.monsterPrefabArray[select], position, Quaternion.identity);

    }

    /// <summary>
    /// 미사일을 생성합니다.
    /// </summary>
    public void CreateBullet()
    {

        if (!bulletSpawnOnOff)
        {
            return;
        }

        //생성될 위치를 계산하고 
        float   radian      = Random.Range(0, Mathf.PI * 2.0f);
        Vector3 position    = new Vector2(Mathf.Cos(radian) * monsterSpawnData.bulletSpawnDistance, Mathf.Sin(radian) * monsterSpawnData.bulletSpawnDistance);

        //생성합니다.
        int select                          = Random.Range(0, monsterSpawnData.bulletPrefabArray.Length);
        var bullet                          = Instantiate(monsterSpawnData.bulletPrefabArray[select], position, Quaternion.identity);
        var bulletScript                    = bullet.GetComponent<Bullet>();
        var bulletMovementDirection         = bullet.GetComponent<MovementBase>();
        bulletScript.TargetTag              = "Player";
        bulletMovementDirection.Direction   = Vector3.Normalize(TargetGameObject.transform.position - position);

    }

    [SerializeField] private GameObject         targetGameObject;

    [SerializeField] private MonsterSpawnData   monsterSpawnData;

    [SerializeField] private bool               monsterSpawnOnOff;
    [SerializeField] private bool               bulletSpawnOnOff;


}
