using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TestPlayer : MonoBehaviour
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
            Debug.Log($"{item.ItemName}을 얻었다.");
            Debug.Log($"체력이 {item.Heal}만큼 변화했다.");
            collision.GetComponent<Item>().ItemUsed();
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
