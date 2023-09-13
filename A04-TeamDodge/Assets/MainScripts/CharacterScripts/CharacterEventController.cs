using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterEventController : MonoBehaviour
{
    public event Action<Vector2> OnMoveEvent;
    public event Action<Vector2> OnLookEvent;
    public event Action OnDeathEvent;
    public event Action OnShootEvent;
    public float skillTime = 2.0f;
    public static CharacterEventController instance = null;

    [SerializeField] private GameObject skill;

    private void Awake()
    {
        instance = this;
    }
    public void CallMoveEvent(Vector2 direction)
    {
        OnMoveEvent?.Invoke(direction);
    }

    public void CallLookEvent(Vector2 direction) 
    {  
        OnLookEvent?.Invoke(direction);
    }

    public void CallShootEvent(bool isShooting)
    {
        OnShootEvent?.Invoke();
    }

    public void CallSkill(bool isShooting)
    {
        skill.SetActive(isShooting);
        Invoke("DeactivateSkill", skillTime);
    }

    public void CallDeathEvent()
    {
        Debug.Log("Died!");
        OnDeathEvent?.Invoke();
    }

    private void DeactivateSkill()
    {
        GameObject.Find("Skill")?.SetActive(false);
    }
}
