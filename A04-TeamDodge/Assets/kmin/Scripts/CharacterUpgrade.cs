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

            // �÷��̾ �������� ȹ���� ���, �������� �Լ��� �����Ŵ
            collision.GetComponent<Item>().OnPlayerPickUp();

            // ������ Ÿ�� ������� ������ ����
            Debug.Log($"{item.ItemName}�� �����.");

            switch (itemData.ItemType)
            {
                case ITEMTYPE.POTION:
                    // ����Ÿ�� �������� �������� ����
                    Debug.Log($"ü���� {item.Heal}��ŭ ȸ���Ǿ���.");

                    break;

                case ITEMTYPE.SCORE:
                    // ���ھ� Ÿ���� �������� �������� ����
                    Debug.Log($"������ {itemData.Score}��ŭ �����ߴ�.");

                    break;

                case ITEMTYPE.BULLET_SIZE_UP:

                    Debug.Log("�߻�ü�� ũ�Ⱑ �����ߴ�.");

                    break;

                case ITEMTYPE.BULLET_NUMBER_UP:
                    Debug.Log("�߻�ü�� ������ �����ߴ�.");

                    break;

                case ITEMTYPE.MOVE_SPEED_UP:
                    Debug.Log("�̵��ӵ��� �����ߴ�.");

                    break;

                case ITEMTYPE.SHOOTING_SPEED_UP:

                    Debug.Log("���ݼӵ��� �����ߴ�.");

                    break;

                case ITEMTYPE.WEAPON_NUMBER_UP:

                    Debug.Log("���������� ������ �����ߴ�.");

                    break;

                default:
                    break;
            }

        }
    }
}
