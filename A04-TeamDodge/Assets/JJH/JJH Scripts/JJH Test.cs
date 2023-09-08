using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JJHTest : MonoBehaviour
{
    Rigidbody2D rb;
    [SerializeField] private float speed;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
        rb.velocity = new Vector3(h, v, 0).normalized * speed * Time.deltaTime;
    }
}
