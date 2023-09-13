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

    private void BeginShot0()
    {
    }

    private void BeginShot1()
    {
    }

    private void BeginIdle()
    {
        m_movement.Enable = false;
    }

    private void EndMove()
    {
    }

    private void EndShot0()
    {
    }

    private void EndShot1()
    {
    }

    private void EndIdle()
    {
        m_movement.Enable = true;
    }

    private void Move()
    {
    }

    private void Shot0()
    {
    }

    private void Shot1()
    {
    }

    private void Idle()
    {
    }

    private void BeginState(BossMonsterState state)
    {

        switch (state)
        {
        case BossMonsterState.Move:
            BeginMove();
            break;
        case BossMonsterState.Shot0:
            BeginShot0();
            break;
        case BossMonsterState.Shot1:
            BeginShot1();
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
        case BossMonsterState.Shot0:
            EndShot0();
            break;
        case BossMonsterState.Shot1:
            EndShot1();
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
        case BossMonsterState.Shot0:
            Shot0();
            break;
        case BossMonsterState.Shot1:
            Shot1();
            break;
        case BossMonsterState.Idle:
            Idle();
            break;
        }
    }

}
