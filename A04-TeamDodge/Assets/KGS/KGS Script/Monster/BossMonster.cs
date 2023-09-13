using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static ShotMonster;

public partial class BossMonster : Monster
{
    public enum BossMonsterState
    {
        Move,
        Fire0,
        Fire1,
        Idle
    }

    protected override void Start()
    {

        base.Start();

        m_state = BossMonsterState.Idle;
        BeginState(m_state);

    }

    protected override void Update()
    {

        base.Update();

        var oldState = m_state;

        PlayState(m_state);

        //상태가 변경되었다면 준비 함수를 호출합니다.
        if(oldState != m_state)
        {
            EndState(oldState);
            BeginState(m_state);
        }

    }

    

    private BossMonsterState            m_state = BossMonsterState.Move;

}
