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
            delta.z                 = 0.0f;                             //x, y좌표만 사용하고 z는 0으로 둡니다.
            Vector3 deltaNormalize  = Vector3.Normalize(delta);

            //거리가 충분히 가깝고 각도 차이가 충분히 가까우면 이동 방향을 회전합니다.
            if (delta.magnitude <= m_rotationEnableDistance &&
                Vector3.Dot(deltaNormalize, Direction) < m_rotationEnableAngle)
            {

                //타겟을 향하는 방향이 현재 진행 방향과 반시계 위치에 있을 경우 방향을 반시계 방향으로 회전합니다. 아니면 시계 방향으로 회전합니다.
                float angle;
                if (Vector3.Cross(deltaNormalize, Direction).normalized == Vector3.back)
                {
                    angle = m_rotationSpeed * Time.deltaTime;
                }
                else
                {
                    angle = -m_rotationSpeed * Time.deltaTime;
                }


                //회전된 x축 = (cos, sin) 회전된 y축 = (-sin, cos)
                //newDirection = Direction.x * (cos, sin) + Direction.y * (-sin, cos)
                //newDirection = (Direction.x * cos - Direction.y * sin, (Direction.x * sin + Direction.y * cos)
                float c = Mathf.Cos(angle);
                float s = Mathf.Sin(angle);
                Direction = new Vector3(Direction.x * c - Direction.y * s, Direction.x * s + Direction.y * c, 0.0f);

            }

        }

        
    }

    [SerializeField] private float m_rotationSpeed;               //회전 속도
    [SerializeField] private float m_rotationEnableAngle;         //회전되는 최대 각도
    [SerializeField] private float m_rotationEnableDistance;      //회전되는 최대 거리

}
