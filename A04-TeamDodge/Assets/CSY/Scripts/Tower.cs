using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Tower : MonoBehaviour
{
    // false는 그냥 아이템상태, true는 설치준비상태 (플레이어가 바닥에 drop한 상태)
    public bool IsInteractable = false;
    public bool PlayerEntered = false;
    public bool BuildOver = false;

    public GameObject MagneticCollider;
    public GameObject InteractCollider;
    public GameObject WeaponTower;
    public GameObject GageBar;
    public GameObject BulletPrefab;
    public Transform[] ArrowTips;
    // public Sprite[] Weapons;
    public float BuildTime = 5f;
    private float currentTime = 0f;
    public SpriteRenderer bluegage;


    private float fireDelayTime = 1f;
    private float lastFireTime = 0f;


    private void Start()
    {
        WeaponTower.SetActive(false);
        GageBar.SetActive(false);
    }
    private void Update()
    {
        if (BuildOver == false)
        {
            if (IsInteractable == true)
            {
                if (PlayerEntered == true)
                {
                    currentTime += Time.deltaTime;
                    var percent = currentTime / BuildTime;
                    bluegage.size = new Vector2(percent, 0.1f);
                    if (percent >= 1f)
                    {
                        BuildOver = true;
                        WeaponTower.SetActive(true);
                        GageBar.SetActive(false);
                        IsInteractable = false;
                        gameObject.tag = "Tower";
                    }
                }
            }
        }
        if (BuildOver == true)
        {
            lastFireTime += Time.deltaTime;
            WeaponTower.transform.Rotate(new Vector3(0f, 0f, 100f * Time.deltaTime));

            if (lastFireTime >= fireDelayTime) 
            {
                FireArrows();
                lastFireTime = 0f;
            }
         
        }
    }


    public void FireArrows() 
    {
        for (int i = 0; i < ArrowTips.Length; i++)
        {
            var temp = Instantiate(BulletPrefab, ArrowTips[i].position, ArrowTips[i].rotation);
            Destroy(temp, 5f);
        }
    }

    public void SetDroppedStatus()
    {
        MagneticCollider.SetActive(false);
        InteractCollider.SetActive(true);
        IsInteractable = true;
    }
}
