using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static ShotMonster;

public partial class BossMonster : Monster
{

    private void BeginMove()
    {
    }

    private void BeginFire0()
    {

        if (MonsterManager.Instance.TargetGameObject == null)
        {
            m_state = BossMonsterState.Idle;
        }

        m_movement.Enable = false;

        m_fireTime      = 0.0f;
        m_fireTotalTime = 0.0f;

        
        m_movement.Direction = Vector3.Normalize(MonsterManager.Instance.TargetGameObject.transform.position - transform.position);

    }

    private void BeginFire1()
    {

        if (MonsterManager.Instance.TargetGameObject == null)
        {
            m_state = BossMonsterState.Idle;
        }

        m_movement.Enable = false;

        m_fireTime      = 0.0f;
        m_fireTotalTime = 0.0f;

        
        m_movement.Direction = Vector3.Normalize(MonsterManager.Instance.TargetGameObject.transform.position - transform.position);

        m_fire1BulletCenterAngle                = 0.0f;
        m_fire1BulletCenter.transform.rotation  = Quaternion.identity;

    }

    private void BeginIdle()
    {
        m_movement.Enable = false;
        m_idleTimer = 0;
    }

    private void EndMove()
    {
    }

    private void EndFire0()
    {

        m_movement.Enable = true;

    }

    private void EndFire1()
    {
        m_movement.Enable = true;
    }

    private void EndIdle()
    {
        m_movement.Enable = true;
    }

    private void Move()
    {

        if(MonsterManager.Instance.TargetGameObject == null)
        {
            return;
        }

        Vector2 delta = MonsterManager.Instance.TargetGameObject.transform.position - transform.transform.position;
        if(delta.magnitude <= m_moveDistance)
        {
            if(UnityEngine.Random.Range(0, 2) == 0)
            {
                m_state = BossMonsterState.Fire1;
            }
            else
            {
                m_state = BossMonsterState.Fire0;
            }
        }
        else
        {
            m_movement.Direction = Vector3.Normalize(delta);
        }


    }

    private void Fire0()
    {

        m_fireTime         += Time.deltaTime;
        m_fireTotalTime    += Time.deltaTime;

        if(m_fireTime >= m_fire0Delay)
        {

            CreateFire0Bullet();
            m_fireTime -= m_fire0Delay;

        }

        if(m_fireTotalTime >= m_fire0TotalDuration)
        {
            m_state = BossMonsterState.Idle;
        }

    }

    private void Fire1()
    {

        m_fireTime                  += Time.deltaTime;
        m_fireTotalTime             += Time.deltaTime;

        if (m_fireTotalTime >= m_fire1BulletCenterAngleStartTime)
        {
            m_fire1BulletCenterAngle += m_fire1BulletCenterAngleSpeed * Time.deltaTime;
        }

        if (m_fireTime >= m_fire1Delay)
        {

            CreateFire1Bullet();
            m_fireTime -= m_fire1Delay;

        }

        if (m_fireTotalTime >= m_fire1TotalDuration)
        {
            m_state = BossMonsterState.Idle;
        }

        m_fire1BulletCenter.transform.rotation = Quaternion.Euler(new Vector3(0.0f, 0.0f, m_fire1BulletCenterAngle));

    }

    private void Idle()
    {

        m_idleTimer += Time.deltaTime;

        if(m_idleTimer >= m_idleDuration)
        {
            m_state = BossMonsterState.Move;
        }

    }

    private void BeginState(BossMonsterState state)
    {

        switch (state)
        {
        case BossMonsterState.Move:
            BeginMove();
            break;
        case BossMonsterState.Fire0:
            BeginFire0();
            break;
        case BossMonsterState.Fire1:
            BeginFire1();
            break;
        case BossMonsterState.Idle:
            BeginIdle();
            break;
        }

    }

    private void EndState(BossMonsterState state)
    {

        switch (state)
        {
        case BossMonsterState.Move:
            EndMove();
            break;
        case BossMonsterState.Fire0:
            EndFire0();
            break;
        case BossMonsterState.Fire1:
            EndFire1();
            break;
        case BossMonsterState.Idle:
            EndIdle();
            break;
        }

    }

    private void PlayState(BossMonsterState state)
    {
        switch (state)
        {
        case BossMonsterState.Move:
            Move();
            break;
        case BossMonsterState.Fire0:
            Fire0();
            break;
        case BossMonsterState.Fire1:
            Fire1();
            break;
        case BossMonsterState.Idle:
            Idle();
            break;
        }
    }


    private void CreateFire0Bullet()
    {

        if (MonsterManager.Instance.TargetGameObject == null)
        {
            return;
        }

        var bullet                  = Instantiate(m_fire0Prefab, transform.position, Quaternion.identity);
        var bulletScript            = bullet.GetComponent<Bullet>();
        var bulletMovement          = bullet.GetComponent<MovementBase>();
        bulletScript.TargetTag      = "Player";
        bulletMovement.Direction    = m_movement.Direction;

        float   s                   = Mathf.Sin(Mathf.PI * m_fire0BulletAngle);
        float   c                   = Mathf.Cos(Mathf.PI * m_fire0BulletAngle);
        Vector3 rotationVector      = m_movement.Direction.x * new Vector2(c, s) + m_movement.Direction.y * new Vector2(-s, c);
        bullet                      = Instantiate(m_fire0Prefab, transform.position, Quaternion.identity);
        bulletScript                = bullet.GetComponent<Bullet>();
        bulletMovement              = bullet.GetComponent<MovementBase>();
        bulletScript.TargetTag      = "Player";
        bulletMovement.Direction    = rotationVector;

        s                           = Mathf.Sin(-Mathf.PI * m_fire0BulletAngle);
        c                           = Mathf.Cos(-Mathf.PI * m_fire0BulletAngle);
        rotationVector              = m_movement.Direction.x * new Vector2(c, s) + m_movement.Direction.y * new Vector2(-s, c);
        bullet                      = Instantiate(m_fire0Prefab, transform.position, Quaternion.identity);
        bulletScript                = bullet.GetComponent<Bullet>();
        bulletMovement              = bullet.GetComponent<MovementBase>();
        bulletScript.TargetTag      = "Player";
        bulletMovement.Direction    = rotationVector;

    }

    private void CreateFire1Bullet()
    {
        
        if (MonsterManager.Instance.TargetGameObject == null)
        {
            return;
        }

        float   s                       = Mathf.Sin(Mathf.PI * 0.5f);
        float   c                       = Mathf.Cos(Mathf.PI * 0.5f);
        Vector3 direction               = m_movement.Direction;

        var bullet                      = Instantiate(m_fire1Prefab, transform.position, Quaternion.identity);
        var bulletScript                = bullet.GetComponent<Bullet>();
        var bulletMovement              = bullet.GetComponent<SinMovement>();
        bulletScript.TargetTag          = "Player";
        bulletMovement.Direction        = direction;
        bullet.transform.parent         = m_fire1BulletCenter.transform;

        direction                       = direction.x * new Vector2(c, s) + direction.y * new Vector2(-s, c);
        bullet                          = Instantiate(m_fire1Prefab, transform.position, Quaternion.identity);
        bulletScript                    = bullet.GetComponent<Bullet>();
        bulletMovement                  = bullet.GetComponent<SinMovement>();
        bulletScript.TargetTag          = "Player";
        bulletMovement.Direction        = direction;
        bullet.transform.parent         = m_fire1BulletCenter.transform;

        direction                       = direction.x * new Vector2(c, s) + direction.y * new Vector2(-s, c);
        bullet                          = Instantiate(m_fire1Prefab, transform.position, Quaternion.identity);
        bulletScript                    = bullet.GetComponent<Bullet>();
        bulletMovement                  = bullet.GetComponent<SinMovement>();
        bulletScript.TargetTag          = "Player";
        bulletMovement.Direction        = direction;
        bullet.transform.parent         = m_fire1BulletCenter.transform;

        direction                       = direction.x * new Vector2(c, s) + direction.y * new Vector2(-s, c);
        bullet                          = Instantiate(m_fire1Prefab, transform.position, Quaternion.identity);
        bulletScript                    = bullet.GetComponent<Bullet>();
        bulletMovement                  = bullet.GetComponent<SinMovement>();
        bulletScript.TargetTag          = "Player";
        bulletMovement.Direction        = direction;
        bullet.transform.parent         = m_fire1BulletCenter.transform;

    }



    //Move

    [SerializeField] public float m_moveDistance;




    //Fire


    [SerializeField] public float           m_fire0Delay;
    [SerializeField] public float           m_fire0TotalDuration;
    [SerializeField] public GameObject      m_fire0Prefab;
    [SerializeField] public float           m_fire0BulletAngle;

    [SerializeField] public float           m_fire1Delay;
    [SerializeField] public float           m_fire1TotalDuration;
    [SerializeField] public GameObject      m_fire1Prefab;

    [SerializeField] private GameObject     m_fire1BulletCenter;
    [SerializeField] private float          m_fire1BulletCenterAngleSpeed;
    [SerializeField] private float          m_fire1BulletCenterAngleStartTime;
    private float                           m_fire1BulletCenterAngle;

    private float                           m_fireTime;
    private float                           m_fireTotalTime;




    //Idle

    float m_idleTimer;


    [SerializeField] public float m_idleDuration;

}
