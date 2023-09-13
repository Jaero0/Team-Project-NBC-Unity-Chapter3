using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestBullet : MonoBehaviour
{
    private Rigidbody2D rb;
    public float speed = 0.4f;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Vector2 direction = Quaternion.Euler(0, 0, transform.rotation.eulerAngles.z) * Vector2.up;
        rb.velocity = direction.normalized * speed;
    }
}