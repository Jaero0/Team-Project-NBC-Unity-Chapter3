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
    /// IBulletEvent ����
    /// </summary>
    /// <param name="damage"></param>
    public void TakeDamage(float damage)
    {
        m_status.hp -= (int)damage;
        if(m_status.hp <= 0)
        {
            MonsterManager.Instance.CallMonsterDieEvent(m_identifier, transform.position);
            Destroy(gameObject);
        }
    }





    protected virtual void Awake()
    {

        m_movement = GetComponent<MovementBase>();
        Debug.Assert(m_movement != null);

        //���̺��� �����͸� �����ɴϴ�.
        m_status.hp = MonsterManager.Instance.MonsterTable[m_identifier].hp;

    }

    protected virtual void Start()
    {

        m_movement.Direction  = Vector3.Normalize(MonsterManager.Instance.TargetGameObject.transform.position - transform.position);

    }

    protected virtual void Update()
    {

        //�̵� ���⿡ �°� �������ϴ�.
        if(m_flipSpriteX)
        {
            m_spriteRenderer.flipX = m_movement.Direction.x < 0.0f;
        }

        if(m_flipSpriteY)
        {
            m_spriteRenderer.flipY = m_movement.Direction.y < 0.0f;
        }


        //ȭ�� ������ �Ѿ���� �����˴ϴ�.
        if (Mathf.Abs(transform.position.x) >= 20.0f ||
           Mathf.Abs(transform.position.y) >= 20.0f)
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
