using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAim : MonoBehaviour
{
    private CharacterEventController _controller;
    [SerializeField] private SpriteRenderer playerSprite;
    [SerializeField] private SpriteRenderer[] weaponSprite;
    [SerializeField] private Transform[] weaponPivot;
    [SerializeField] public Transform weaponOrigin;
    [SerializeField] public Transform weaponParent;
    public float shootingSpeed;
    public float shootInterval;
    private float shootCool = 0;
    private int weaponNumber = 1;
    private int weaponNumberMax = 4;
    private int playerChoice = 0;
    float angle = 0;
    Vector2 direction = Vector2.zero;
    Vector2 shootDirection = Vector2.zero;

    private void Awake()
    {
        _controller = GetComponent<CharacterEventController>();
        playerChoice = PlayerPrefs.GetInt("PlayerAvater");

    }
    void Start()
    {
        Debug.Log(playerChoice);
        _controller.OnLookEvent += Look;
        _controller.OnShootEvent += Shoot;
        weaponParent.DetachChildren();
        shootCool = shootInterval;
    }

    void Update()
    {
        if(shootCool >= shootInterval)
        {
            weaponOrigin.position = transform.position;
        }
        else if(shootCool < shootInterval)
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
            if (Mathf.Abs(weaponOrigin.position.x - transform.position.x)<0.5f&& Mathf.Abs(weaponOrigin.position.y - transform.position.y) < 0.5f)
                weaponPivot[i].rotation = Quaternion.Euler(0, 0, angle);
        }
        
    }

    private void Shoot()
    {
        if (shootCool >= shootInterval)
        {
            shootDirection = direction;
            Invoke("ResetPosition", shootInterval);
            foreach (var weapon in weaponPivot)
            {
                weapon.GetComponent<BoxCollider2D>().enabled = true;
            }
            shootCool = 0;
        }
    }

    private void ResetPosition()
    {
        weaponOrigin.position = transform.position;
        foreach(var weapon in weaponPivot)
        {
            weapon.GetComponent<BoxCollider2D>().enabled = false;
        }
        shootDirection = Vector2.zero;
    }

    public void AddWeaponNumber()
    {
        if (weaponNumber < 4)
        {
            weaponNumber++;
            SetWeaponToWeaponNumber(playerChoice);
            Debug.Log($"근접 무기 숫자가 늘었습니다.");
        }
        if (weaponNumber ==4)
        {
            Debug.Log($"이미 최대 무기 숫자 입니다.");
        }
    }

    public void SetWeaponToWeaponNumber(int playerChoice)
    {
        for (int i = 0; i < weaponNumberMax; i++)
        {
            weaponPivot[i].gameObject.SetActive(false);
        }
        for (int i = 0; i < weaponNumber; i++)
        {
            weaponPivot[i].gameObject.SetActive(true);
            weaponPivot[i].GetChild(0).GetComponent<Animator>().SetInteger("avatar", playerChoice);
        }
    }
}
