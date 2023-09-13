using System.Collections;
using System.Collections.Generic;
using Unity.IO.LowLevel.Unsafe;
using UnityEngine;

public class SinMovement : MovementBase
{

    public Vector2 StartPosition { set => m_startPosition = value; get => m_startPosition; }

    
    protected override void Update()
    {

        if (Enable)
        {

            Vector2 axis        = Direction;
            Vector2 upVector    = new Vector2(-Direction.y, Direction.x);

            transform.localPosition = m_startPosition + axis * m_time + upVector * Mathf.Sin(m_time);

            m_time += Speed * Time.deltaTime;

        }

    }

    [SerializeField] private Vector2    m_startPosition;

    private float m_time;

}
