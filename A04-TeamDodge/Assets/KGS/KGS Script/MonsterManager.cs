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
    /// ��ü�� ����� �� �� ȣ��� �ʱ�ȭ �մϴ�.
    /// </summary>
    public void Awake()
    {

        //�̱����� �����մϴ�.
        Debug.Assert(Instance == null);
        I = this;

    }


    /// <summary>
    /// ��ü�� �ı� �� �� ȣ��˴ϴ�.
    /// </summary>
    public void OnDestroy()
    {
        //�̱����� �����մϴ�.
        I = null;
    }


    /// <summary>
    /// ��ü�� Ȱ��ȭ �� �� ȣ��� �ʱ�ȭ �մϴ�.
    /// </summary>
    public void Start()
    {
        InvokeRepeating("CreateMonster", 0, monsterSpawnData.monsterSpawnTime);
        InvokeRepeating("CreateBullet", 0, monsterSpawnData.bulletSpawnTime);
    }


    /// <summary>
    /// ���͸� �����մϴ�.
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
    /// �̻����� �����մϴ�.
    /// </summary>
    public void CreateBullet()
    {

        if (!bulletSpawnOnOff)
        {
            return;
        }

        //������ ��ġ�� ����ϰ� 
        float   radian      = Random.Range(0, Mathf.PI * 2.0f);
        Vector3 position    = new Vector2(Mathf.Cos(radian) * monsterSpawnData.bulletSpawnDistance, Mathf.Sin(radian) * monsterSpawnData.bulletSpawnDistance);

        //�����մϴ�.
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
