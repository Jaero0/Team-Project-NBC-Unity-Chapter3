using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    // false는 그냥 아이템상태, true는 설치준비상태 (플레이어가 바닥에 drop한 상태)
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
