using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterUpgrade : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

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

                default:
                    break;
            }

        }
    }
}
