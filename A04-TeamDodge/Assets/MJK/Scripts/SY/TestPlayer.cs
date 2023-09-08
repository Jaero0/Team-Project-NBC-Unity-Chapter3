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
            Debug.Log($"{item.ItemName}을 얻었다.");
            Debug.Log($"체력이 {item.Heal}만큼 변화했다.");
            collision.GetComponent<Item>().ItemUsed();
        }
    }
}
