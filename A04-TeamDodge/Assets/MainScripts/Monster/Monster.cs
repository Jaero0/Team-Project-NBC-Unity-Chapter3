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
    public void TakeDamage(int damage)
    {

        m_status.hp -= damage;
        if(m_status.hp <= 0)
        {

            MonsterManager.Instance.CallMonsterDieEvent(m_identifier, transform.position);
            //m_animator.SetBool("Dead", true);
            Destroy(gameObject);

        }
        else
        {
            //m_animator.SetBool("Hit", true);
        }
    }





    protected virtual void Awake()
    {

        m_movement = GetComponent<MovementBase>();
        Debug.Assert(m_movement != null);

        

    }

    protected virtual void Start()
    {

        //테이블에서 데이터를 가져옵니다.
        m_status.hp = MonsterManager.Instance.MonsterTable[m_identifier].hp;

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


        //화면 밖으로 넘어갔으면 삭제됩니다.
        if (Mathf.Abs(transform.position.x) >= 200.0f ||
           Mathf.Abs(transform.position.y) >= 200.0f)
        {
            Destroy(gameObject);
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
