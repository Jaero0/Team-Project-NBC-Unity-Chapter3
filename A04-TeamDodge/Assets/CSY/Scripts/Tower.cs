using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    // false�� �׳� �����ۻ���, true�� ��ġ�غ���� (�÷��̾ �ٴڿ� drop�� ����)
    public bool IsInteractable = false;
    public bool BuildOver = false;

    public GameObject BulletPrefab;
    public Vector3[] ArrowTips;
    public Sprite[] Weapons;

    public SpriteRenderer bluegage;

    private void Update()
    {
        bluegage.size = new Vector2(1f,0.1f);
    }


    public void FireArrows() 
    { 
        
    }
}
