using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public interface IBulletEvent
{

    /// <summary>
    /// 데이지를 받으면 호출됩니다.
    /// </summary>
    /// <param name="damage">받은 데미지</param>
    void TakeDamage(int damage);

}
