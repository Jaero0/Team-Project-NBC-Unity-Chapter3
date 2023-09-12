using System.Collections;
using System.Collections.Generic;
using Unity.IO.LowLevel.Unsafe;
using UnityEngine;

public class MovementBase : MonoBehaviour
{
    
    public bool         Enable { set => m_enable = value; get => m_enable; }
    public float        Speed { set => m_speed = value; get => m_speed; }
    public Vector3      Direction{ set => m_direction = value; get => m_direction; }

    private void Update()
    {
        if (m_enable)
        {

            UpdateDirection();
            transform.position += Direction * Speed * Time.deltaTime;

        }
    }

    protected virtual void UpdateDirection()
    {
    }

    [SerializeField] private bool       m_enable = true;
    [SerializeField] private float      m_speed;
    [SerializeField] private Vector3    m_direction;

}
