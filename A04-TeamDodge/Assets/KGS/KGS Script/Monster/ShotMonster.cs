using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotMonster : Monster
{

    public const float DEFAULT_SHOT_DELAY       = 2.0f; 
    public const float DEFAULT_SHOT_DISTANCE    = 4.0f;
    public const float DEFAULT_IDLE_DURATION    = 2.0f;
    public enum ShotMonsterState
    {
        Move,
        Shot,
        Idle
    }

    protected override void Start()
    {

        base.Start();

    }

    protected override void Update()
    {

        base.Update();

        var oldState = m_state;

        switch (m_state)
        {
        case ShotMonsterState.Move:
            Move();
            break;
        case ShotMonsterState.Shot:
            Shot();
            break;
        case ShotMonsterState.Idle:
            Idle();
            break;
        }

        //미사일 발사 쿨타임을 계산합니다.
        m_shotTimer += Time.deltaTime;
        if (m_shotTimer >= m_shotDelay)
        {

            m_shotTimer -= m_shotDelay;

            m_enableShot = true;

        }

        //미사일 발사가 가능하면 발사합니다.
        if (m_enableShot)
        {

            //플레이어가 가까우면 쏩니다.
            Vector2 delta = MonsterManager.Instance.TargetGameObject.transform.position - transform.position;
            if (delta.magnitude <= m_shotDistance)
            {
                m_state         = ShotMonsterState.Shot;
                m_enableShot    = false;
            }

        }

        //상태가 변경되었다면 준비 함수를 호출합니다.
        if(oldState != m_state)
        {

            switch (oldState)
            {
            case ShotMonsterState.Move:
                EndMove();
                break;
            case ShotMonsterState.Shot:
                EndShot();
                break;
            case ShotMonsterState.Idle:
                EndIdle();
                break;
            }

            switch (m_state)
            {
            case ShotMonsterState.Move:
                BeginMove();
                break;
            case ShotMonsterState.Shot:
                BeginShot();
                break;
            case ShotMonsterState.Idle:
                BeginIdle();
                break;
            }
        }

    }

    private void BeginIdle()
    {
        m_idleTimer             = 0.0f;
        m_movement.Enable       = false;
        m_moveDirectionBackup   = m_movement.Direction;
    }

    private void BeginShot()
    {
    }

    private void BeginMove()
    {
    }

    private void EndIdle()
    {
        m_movement.Enable       = true;
        m_movement.Direction    = m_moveDirectionBackup;
    }

    private void EndShot()
    {
    }

    private void EndMove()
    {
    }

    private void Idle()
    {

        //시간이 끝났으면 이동 상태로 돌아갑니다.
        m_idleTimer += Time.deltaTime;
        if(m_idleTimer >= m_idleDuration)
        {
            m_state = ShotMonsterState.Move;
        }

        //플레이어를 쳐다봅니다.
        m_movement.Direction = Vector3.Normalize(MonsterManager.Instance.TargetGameObject.transform.position - transform.position);

    }

    private void Shot()
    {

        Vector2 delta = MonsterManager.Instance.TargetGameObject.transform.position - transform.position;

        GameObject  bullet          = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
        var         bulletMovement  = bullet.GetComponent<MovementBase>();
        bulletMovement.Direction    = Vector3.Normalize(delta);

        m_state = ShotMonsterState.Idle;

    }

    private void Move()
    {
    }

    private ShotMonsterState            m_state = ShotMonsterState.Move;


    private bool                        m_enableShot                = false;
    
    private float                       m_shotTimer                 = 0.0f;
    [SerializeField] private float      m_shotDelay                 = DEFAULT_SHOT_DELAY;
    [SerializeField] private float      m_shotDistance              = DEFAULT_SHOT_DISTANCE;

    private float                       m_idleTimer                 = 0.0f;
    [SerializeField] private float      m_idleDuration              = DEFAULT_IDLE_DURATION;
    private Vector3                     m_moveDirectionBackup;              //멈춰 있을 때 플레이어를 바라보고 다시 움직일 때 이동 방향을 복구해야 해서 기억하는 용도입니다.

    [SerializeField] private GameObject bulletPrefab;

}
