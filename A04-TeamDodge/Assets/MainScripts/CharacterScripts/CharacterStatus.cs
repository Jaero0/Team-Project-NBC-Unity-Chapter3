using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterStatus : CharacterEventController, IBulletEvent
{
    [SerializeField] private int hp;
    [SerializeField] private int maxHp;
    [SerializeField] private Image hpBar;

    private void Start()
    {
        hp = maxHp;
        Invoke("CallDeathEvent", 2f);
    }
    public void TakeDamage(int damage)
    {
        hp -= damage;
        if (hp > maxHp)
        {
            hp = maxHp;
        }
        if (hp <= 0)
        {
            hp = 0;
            CallDeathEvent();
        }
        hpBar.rectTransform.localScale = new Vector3((float)hp / maxHp, 1, 1);
    }

}
