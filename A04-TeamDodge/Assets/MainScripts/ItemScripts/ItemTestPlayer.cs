using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ItemTestPlayer : MonoBehaviour
{
    [SerializeField]
    private string description;
    public ItemData towerData;
    private Vector2 direction = Vector2.zero;
    private float moveSpeed = 2f;

    private int towerParts = 0;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Item"))
        {
            Item item = collision.GetComponent<Item>();
            ItemData itemData = item.ItemData;

            // 플레이어가 아이템을 획득한 경우, 아이템의 함수를 실행시킴
            collision.GetComponent<Item>().OnPlayerPickUp();

            // 아이템 타입 상관없이 나오는 동작
            Debug.Log($"{item.ItemName}을 얻었다.");

            switch (itemData.ItemType)
            {
                case ITEMTYPE.POTION:
                    // 포션타입 아이템이 들어왔을때 동작
                    Debug.Log($"체력이 {item.Heal}만큼 회복되었다.");

                    break;

                case ITEMTYPE.SCORE:
                    // 스코어 타입의 아이템이 들어왔을때 동작
                    Debug.Log($"점수가 {itemData.Score}만큼 증가했다.");

                    break;

                case ITEMTYPE.BULLET_SIZE_UP:

                    Debug.Log("발사체의 크기가 증가했다.");

                    break;

                case ITEMTYPE.BULLET_NUMBER_UP:
                    Debug.Log("발사체의 갯수가 증가했다.");

                    break;

                case ITEMTYPE.MOVE_SPEED_UP:
                    Debug.Log("이동속도가 증가했다.");

                    break;

                case ITEMTYPE.SHOOTING_SPEED_UP:

                    Debug.Log("공격속도가 증가했다.");

                    break;

                case ITEMTYPE.WEAPON_NUMBER_UP:

                    Debug.Log("근접무기의 갯수가 증가했다.");

                    break;
                case ITEMTYPE.TOWER:
                    Debug.Log("타워를 얻었습니다.");
                    towerParts += 1;
                    break;
                default:
                    break;
            }
        }
    }

    private void FixedUpdate()
    {
        transform.Translate(direction * moveSpeed * Time.deltaTime);
    }
    public void OnUseItem(InputValue value)
    {
        if (value.isPressed)
        {

        }
    }
    public void OnBuildTower(InputValue value)
    {
        if (value.isPressed)
        {
            if (towerParts >= 5)
            {
                Debug.Log($"타워 부품 5개를 소비하여 타워를 소환함. 남은 부품 : {towerParts}");
                towerParts -= 5;
                
                ItemSpawner.Instance.MakeTower(gameObject.transform.position,3);
            }
            else
            {
                Debug.Log($"타워 부품이 5개 필요합니다. 현재 부품 : {towerParts}");
            }
        }
    }
    public void OnMove(InputValue value)
    {
        Vector2 newDirection = value.Get<Vector2>().normalized;
        direction = newDirection;
    }
}
