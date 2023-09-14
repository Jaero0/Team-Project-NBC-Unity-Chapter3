using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterInputController : CharacterEventController
{
    private Camera m_Camera;
    public int TowerParts;

    private void Awake()
    {
        m_Camera = Camera.main;
        TowerParts = 5;
    }

    public void OnMove(InputValue value)
    {
        Vector2 direction = value.Get<Vector2>().normalized;
        CallMoveEvent(direction);
    }

    public void OnLook(InputValue value)
    {
        Vector2 mousePos = value.Get<Vector2>();
        mousePos = m_Camera.ScreenToWorldPoint(mousePos);
        Vector2 worldPos = transform.position; 
        Vector2 direction = (mousePos - worldPos).normalized;
        CallLookEvent(direction);
    }

    public void OnShoot(InputValue value)
    {
        bool isPressed = (value.Get<float>() > 0)? true : false;
        Debug.Log(value.Get<float>());
        CallShootEvent(value.isPressed);
        if(value.Get<float>()>=1.0f)
            CallSkill(value.isPressed);
        
    }

    public void OnBuildTower(InputValue value)
    {
        if (value.isPressed)
        {
            if (TowerParts >= 5)
            {
                Debug.Log($"Ÿ�� ��ǰ 5���� �Һ��Ͽ� Ÿ���� ��ȯ��. ���� ��ǰ : {TowerParts}");
                TowerParts -= 5;

                Debug.Log($"{gameObject.transform.position.x} , {gameObject.transform.position.y}");
                ItemSpawner.Instance.MakeTower(gameObject.transform.position, 3);
            }
            else
            {
                Debug.Log($"Ÿ�� ��ǰ�� 5�� �ʿ��մϴ�. ���� ��ǰ : {TowerParts}");
            }
        }
    }
    public void AddTowerParts()
    {
        TowerParts++;
        Debug.Log($"Ÿ�� ��ǰ�� ������ϴ�. ���� ��ǰ���� : {TowerParts}");
    }
}
