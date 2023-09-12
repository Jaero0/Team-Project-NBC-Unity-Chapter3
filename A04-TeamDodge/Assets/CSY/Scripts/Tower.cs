using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Tower : MonoBehaviour
{
    // false�� �׳� �����ۻ���, true�� ��ġ�غ���� (�÷��̾ �ٴڿ� drop�� ����)
    public bool IsInteractable = false;
    public bool BuildOver = false;

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
            if(IsInteractable == true)
            {
                currentTime += Time.deltaTime;
                var percent = currentTime / BuildTime;
                bluegage.size = new Vector2(percent, 0.1f);
                if ( percent >= 1f)
                {
                    BuildOver = true;
                    WeaponTower.SetActive (true);
                    GageBar.SetActive (false);
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
}
