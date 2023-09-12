using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAim : MonoBehaviour
{
    private CharacterEventController _controller;
    [SerializeField] private SpriteRenderer playerSprite;
    [SerializeField] private SpriteRenderer[] weaponSprite;
    [SerializeField] private Transform[] weaponPivot;
    [SerializeField] private Transform weaponOrigin;
    public float shootingSpeed;
    public float shootInterval;
    private float shootCool = 0;
    float angle = 0;
    Vector2 direction = Vector2.zero;
    Vector2 shootDirection = Vector2.zero;

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
        if(shootCool < shootInterval)
        {
            shootCool += Time.deltaTime;
        }
        weaponOrigin.Translate((Vector3)shootDirection * shootingSpeed * Time.deltaTime, Space.World);
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

    private void Shoot()
    {
        if (shootCool > shootInterval)
        {
            shootDirection = direction;
            Invoke("ResetPosition", shootInterval);
            shootCool = 0;
        }
    }

    private void ResetPosition()
    {
        weaponOrigin.position = transform.position;
        shootDirection = Vector2.zero;
    }

}
