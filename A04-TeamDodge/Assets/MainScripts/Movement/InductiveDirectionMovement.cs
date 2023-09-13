using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class InductiveDirectionMovement : MovementBase
{

    protected override void UpdateDirection()
    {

        if (MonsterManager.Instance.TargetGameObject != null)
        {

            Vector3 delta           = (MonsterManager.Instance.TargetGameObject.transform.position - transform.position);
            delta.z                 = 0.0f;                             //x, y��ǥ�� ����ϰ� z�� 0���� �Ӵϴ�.
            Vector3 deltaNormalize  = Vector3.Normalize(delta);

            //�Ÿ��� ����� ������ ���� ���̰� ����� ������ �̵� ������ ȸ���մϴ�.
            if (delta.magnitude <= m_rotationEnableDistance &&
                Vector3.Dot(deltaNormalize, Direction) < m_rotationEnableAngle)
            {

                //Ÿ���� ���ϴ� ������ ���� ���� ����� �ݽð� ��ġ�� ���� ��� ������ �ݽð� �������� ȸ���մϴ�. �ƴϸ� �ð� �������� ȸ���մϴ�.
                float angle;
                if (Vector3.Cross(deltaNormalize, Direction).normalized == Vector3.back)
                {
                    angle = m_rotationSpeed * Time.deltaTime;
                }
                else
                {
                    angle = -m_rotationSpeed * Time.deltaTime;
                }


                //ȸ���� x�� = (cos, sin) ȸ���� y�� = (-sin, cos)
                //newDirection = Direction.x * (cos, sin) + Direction.y * (-sin, cos)
                //newDirection = (Direction.x * cos - Direction.y * sin, (Direction.x * sin + Direction.y * cos)
                float c = Mathf.Cos(angle);
                float s = Mathf.Sin(angle);
                Direction = new Vector3(Direction.x * c - Direction.y * s, Direction.x * s + Direction.y * c, 0.0f);

            }

        }

        
    }

    [SerializeField] private float m_rotationSpeed;               //ȸ�� �ӵ�
    [SerializeField] private float m_rotationEnableAngle;         //ȸ���Ǵ� �ִ� ����
    [SerializeField] private float m_rotationEnableDistance;      //ȸ���Ǵ� �ִ� �Ÿ�

}
