using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ItemTestPlayer : MonoBehaviour
{
    [SerializeField]
    private string description;
    private Vector2 direction = Vector2.zero;
    private float moveSpeed = 2f;
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
    public void OnBuild(InputValue value)
    {
        if (value.isPressed)
        {

        }
    }
    public void OnMove(InputValue value)
    {
        Vector2 newDirection = value.Get<Vector2>().normalized;
        direction = newDirection;
    }
}
