using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterInputController : CharacterEventController
{
    private Camera m_Camera;
    public int TowerParts = 0;

    private void Awake()
    {
        m_Camera = Camera.main;
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
                Debug.Log($"타워 부품 5개를 소비하여 타워를 소환함. 남은 부품 : {TowerParts}");
                TowerParts -= 5;

                Debug.Log($"{gameObject.transform.position.x} , {gameObject.transform.position.y}");
                ItemSpawner.Instance.MakeTower(gameObject.transform.position, 3);
            }
            else
            {
                Debug.Log($"타워 부품이 5개 필요합니다. 현재 부품 : {TowerParts}");
            }
        }
    }
    public void AddTowerParts()
    {
        TowerParts++;
        Debug.Log($"타워 부품을 얻었습니다. 현재 부품갯수 : {TowerParts}");
    }
}
