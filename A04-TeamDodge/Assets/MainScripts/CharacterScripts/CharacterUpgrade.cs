using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterUpgrade : MonoBehaviour
{
    private int moveUpgrade = 0;
    private int sizeUpgrade = 0;
    private int shootingUpgrade = 0;
    // Start is called before the first frame update
    void Start()
    {
        moveUpgrade = 0;
        sizeUpgrade = 0;
        shootingUpgrade = 0;
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
                    GetComponent<CharacterStatus>().TakeDamage(-item.Heal);
                    break;

                case ITEMTYPE.SCORE:
                    // 스코어 타입의 아이템이 들어왔을때 동작
                    Debug.Log($"점수가 {itemData.Score}만큼 증가했다.");
                    break;

                case ITEMTYPE.BULLET_SIZE_UP:
                    if( sizeUpgrade < 10)
                    {
                        sizeUpgrade++;
                        Debug.Log("발사체의 크기가 증가했다.");
                    }
                    else
                    {
                        Debug.Log("발사체의 크기가 최대치입니다.");
                        break;
                    }
                    float sizeFactor = (1f + sizeUpgrade * 0.1f) / (0.9f + sizeUpgrade * 0.1f);
                    var newScale = GetComponent<CharacterAim>().weaponOrigin.localScale * sizeFactor;
                    GetComponent<CharacterAim>().weaponOrigin.localScale = newScale;

                    var newScale2 = GetComponent<CharacterSkill>().skillTransform.localScale * sizeFactor;
                    GetComponent<CharacterSkill>().skillTransform.localScale = newScale2;
                    break;

                case ITEMTYPE.BULLET_NUMBER_UP:
                    GetComponent<CharacterAim>().AddWeaponNumber();
                    break;

                case ITEMTYPE.MOVE_SPEED_UP:
                    if (moveUpgrade < 10)
                    {
                        moveUpgrade++;
                        Debug.Log("이동속도가 증가했다.");
                    }
                    else
                    {
                        Debug.Log("이동속도가 최대치입니다.");
                        break;
                    }
                    float speedFactor = (1f + moveUpgrade * 0.1f) / (0.9f + moveUpgrade * 0.1f);
                    GetComponent<CharacterMovement>().moveSpeed *= speedFactor;
                    break;

                case ITEMTYPE.SHOOTING_SPEED_UP:
                    if (shootingUpgrade < 10)
                    {
                        shootingUpgrade++;
                        Debug.Log("발사 대기시간이 감소했다.");
                    }
                    else
                    {
                        Debug.Log("연사속도 최대치입니다.");
                        break;
                    }
                    float fireFactor = (1f - shootingUpgrade * 0.05f) / (1.05f - shootingUpgrade * 0.05f);
                    GetComponent<CharacterAim>().shootInterval *= fireFactor;
                    break;

                case ITEMTYPE.WEAPON_NUMBER_UP:

                    Debug.Log("근접무기의 갯수가 증가했다.");

                    break;
                case ITEMTYPE.TOWER:
                    Debug.Log($"타워부품을 얻었습니다.");
                    GetComponent<CharacterInputController>().AddTowerParts();
                    break;
                default:
                    break;
            }
        }
    }
}
