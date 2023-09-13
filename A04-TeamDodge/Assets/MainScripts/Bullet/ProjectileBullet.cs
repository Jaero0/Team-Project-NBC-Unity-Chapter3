using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileBullet : MonoBehaviour, IBulletEvent
{

    public void TakeDamage(int damage)
    {
        Destroy(gameObject);
    }

    private void Update()
    {

        if (Mathf.Abs(transform.position.x) >= 20.0f ||
            Mathf.Abs(transform.position.y) >= 20.0f)
        {
            Destroy(gameObject);
        }

    }

}