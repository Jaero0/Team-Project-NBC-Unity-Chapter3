using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public interface IBulletEvent
{

    /// <summary>
    /// �������� ������ ȣ��˴ϴ�.
    /// </summary>
    /// <param name="damage">���� ������</param>
    void TakeDamage(float damage);

}
