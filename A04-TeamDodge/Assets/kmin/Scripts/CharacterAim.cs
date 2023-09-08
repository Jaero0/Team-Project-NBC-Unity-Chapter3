using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAim : MonoBehaviour
{
    private CharacterEventController _controller;
    [SerializeField] private SpriteRenderer playerSprite;
    [SerializeField] private SpriteRenderer[] weaponSprite;
    [SerializeField] private Transform[] weaponPivot;
    [SerializeField] private float shootingSpeed;
    float angle = 0;
    Vector2 direction = Vector2.zero;

    private void Awake()
    {
        _controller = GetComponent<CharacterEventController>();
    }
    void Start()
    {
        _controller.OnLookEvent += Look;
        _controller.OnShootEvent += Shoot;
    }

    void Update()
    {
        
    }

    private void Look(Vector2 _direction)
    {
        direction = _direction;
        angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        for (int i = 0; i < weaponSprite.Length; i++)
        {
            weaponSprite[i].flipX = (Mathf.Abs(angle) > 90f) ? true : false;
            playerSprite.flipX = weaponSprite[i].flipX;
            weaponPivot[i].rotation = Quaternion.Euler(0, 0, angle);
        }
        
    }

    private void Shoot(bool isShooting)
    {
        //Debug.Log($"Shoot Here : {direction}");
        foreach (var weapon in weaponPivot)
        {
            weapon.Translate((Vector3)direction * shootingSpeed * Time.deltaTime, Space.World);
        }

        //foreach (var weapon in weaponPivot)
        //{
        //    weapon.position -= (Vector3)direction * shootingSpeed * Time.deltaTime;
        //}
    }

}
