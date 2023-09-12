using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour, IBulletEvent
{

    public struct STATUS
    {
        public int hp;
    }

    public int identifier => m_identifier;


    //IBullerEvent implement


    /// <summary>
    /// IBulletEvent 구현
    /// </summary>
    /// <param name="damage"></param>
    public void TakeDamage(float damage)
    {
        m_status.hp -= (int)damage;
        if(m_status.hp <= 0)
        {
            Destroy(gameObject);
        }
    }





    protected virtual void Awake()
    {

        m_movement = GetComponent<MovementBase>();
        Debug.Assert(m_movement != null);

        //테이블에서 데이터를 가져옵니다.
        var data = MonsterTable.Instance.Find(m_identifier);
        m_status.hp = data.hp;

    }

    protected virtual void Start()
    {

        m_movement.Direction  = Vector3.Normalize(MonsterManager.Instance.TargetGameObject.transform.position - transform.position);

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

    protected STATUS                            m_status; 

    [SerializeField] private   int              m_identifier;
    [SerializeField] protected SpriteRenderer   m_spriteRenderer;
    [SerializeField] protected Animator         m_animator;
    [SerializeField] protected bool             m_flipSpriteX;
    [SerializeField] protected bool             m_flipSpriteY;

    protected MovementBase m_movement;

}
