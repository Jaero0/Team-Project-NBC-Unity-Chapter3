using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{

    protected virtual void Awake()
    {
        m_movement = GetComponent<MovementBase>();
        Debug.Assert(m_movement != null);
    }

    protected virtual void Start()
    {

        m_movement.Direction  = (MonsterManager.Instance.TargetGameObject.transform.position - transform.position).normalized;

    }

    protected virtual void Update()
    {

        //이동 방향에 맞게 뒤집습니다.
        if(m_flipSpriteX)
        {
            m_spriteRenderer.flipX = m_movement.Direction.x < 0.0f;
        }

        if(m_flipSpriteY)
        {
            m_spriteRenderer.flipY = m_movement.Direction.y < 0.0f;
        }

    }
    

    [SerializeField] protected SpriteRenderer  m_spriteRenderer;
    [SerializeField] protected Animator        m_animator;
    [SerializeField] protected bool            m_flipSpriteX;
    [SerializeField] protected bool            m_flipSpriteY;

    protected MovementBase m_movement;

}
