using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    public string TargetTag { set => m_targetTag = value; get => m_targetTag; }

    public float Damage { set => m_damage = value; get => m_damage; }


    public void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == TargetTag)
        {

            var bulletEvent = collision.gameObject.GetComponent<IBulletEvent>();

            if (bulletEvent != null)
            {
                bulletEvent.TakeDamage(m_damage);
                Destroy(gameObject);
            }

        }

    }


    [SerializeField] private string m_targetTag;
    [SerializeField] private float  m_damage;

}