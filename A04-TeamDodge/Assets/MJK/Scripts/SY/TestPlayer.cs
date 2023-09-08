using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestPlayer : MonoBehaviour
{
    [SerializeField]
    private string description;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Item"))
        {
            Item item = collision.GetComponent<Item>();
            Debug.Log($"{item.ItemName}�� �����.");
            Debug.Log($"ü���� {item.Heal}��ŭ ��ȭ�ߴ�.");
            collision.GetComponent<Item>().ItemUsed();
        }
    }
}
