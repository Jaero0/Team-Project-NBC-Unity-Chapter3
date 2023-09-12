using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterUpgrade : MonoBehaviour
{
    private int towerParts = 0;
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

                    Debug.Log("�߻�ü�� ũ�Ⱑ �����ߴ�.");
                    var newScale = GetComponent<CharacterAim>().weaponOrigin.localScale * 1.1f;
                    GetComponent<CharacterAim>().weaponOrigin.localScale = newScale;

                    var newScale2 = GetComponent<CharacterSkill>().skillTransform.localScale * 1.1f;
                    GetComponent<CharacterSkill>().skillTransform.localScale = newScale;
                    break;

                case ITEMTYPE.BULLET_NUMBER_UP:
                    GetComponent<CharacterAim>().AddWeaponNumber();
                    break;

                case ITEMTYPE.MOVE_SPEED_UP:
                    Debug.Log("�̵��ӵ��� 10% �����ߴ�.");
                    GetComponent<CharacterMovement>().moveSpeed *= 1.1f;
                    break;

                case ITEMTYPE.SHOOTING_SPEED_UP:
                    Debug.Log("���ݼӵ��� �����ߴ�.");
                    GetComponent<CharacterAim>().shootInterval *= 0.9f;
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
