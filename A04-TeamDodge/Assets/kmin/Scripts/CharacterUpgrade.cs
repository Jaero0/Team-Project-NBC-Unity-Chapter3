using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterUpgrade : MonoBehaviour
{
    private int moveUpgrade = 0;
    private int sizeUpgrade = 0;
    private int shootingUpgrade = 0;
    private int towerParts = 0;
    // Start is called before the first frame update
    void Start()
    {
        moveUpgrade = 0;
        sizeUpgrade = 0;
        shootingUpgrade = 0;
        towerParts = 0;
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

            // �÷��̾ �������� ȹ���� ���, �������� �Լ��� �����Ŵ
            collision.GetComponent<Item>().OnPlayerPickUp();

            // ������ Ÿ�� ������� ������ ����
            Debug.Log($"{item.ItemName}�� �����.");

            switch (itemData.ItemType)
            {
                case ITEMTYPE.POTION:
                    // ����Ÿ�� �������� �������� ����
                    Debug.Log($"ü���� {item.Heal}��ŭ ȸ���Ǿ���.");
                    GetComponent<CharacterStatus>().TakeDamage(-item.Heal);
                    break;

                case ITEMTYPE.SCORE:
                    // ���ھ� Ÿ���� �������� �������� ����
                    Debug.Log($"������ {itemData.Score}��ŭ �����ߴ�.");
                    break;

                case ITEMTYPE.BULLET_SIZE_UP:
                    if( sizeUpgrade < 10)
                    {
                        sizeUpgrade++;
                        Debug.Log("�߻�ü�� ũ�Ⱑ �����ߴ�.");
                    }
                    else
                    {
                        Debug.Log("�߻�ü�� ũ�Ⱑ �ִ�ġ�Դϴ�.");
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
                        Debug.Log("�̵��ӵ��� �����ߴ�.");
                    }
                    else
                    {
                        Debug.Log("�̵��ӵ��� �ִ�ġ�Դϴ�.");
                        break;
                    }
                    float speedFactor = (1f + moveUpgrade * 0.1f) / (0.9f + moveUpgrade * 0.1f);
                    GetComponent<CharacterMovement>().moveSpeed *= speedFactor;
                    break;

                case ITEMTYPE.SHOOTING_SPEED_UP:
                    if (shootingUpgrade < 10)
                    {
                        shootingUpgrade++;
                        Debug.Log("�߻� ���ð��� �����ߴ�.");
                    }
                    else
                    {
                        Debug.Log("����ӵ� �ִ�ġ�Դϴ�.");
                        break;
                    }
                    float fireFactor = (1f - shootingUpgrade * 0.05f) / (1.05f - shootingUpgrade * 0.05f);
                    GetComponent<CharacterAim>().shootInterval *= fireFactor;
                    break;

                case ITEMTYPE.WEAPON_NUMBER_UP:

                    Debug.Log("���������� ������ �����ߴ�.");

                    break;
                case ITEMTYPE.TOWER:
                    Debug.Log($"Ÿ����ǰ�� ������ϴ�.");
                    GetComponent<CharacterInputController>().AddTowerParts();
                    break;
                default:
                    break;
            }
        }
    }
}
