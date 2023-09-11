using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    private CharacterEventController _controller;
    private Vector2 direction = Vector2.zero;
    [SerializeField] private float moveSpeed;

    [SerializeField] Animator animator;
    private void Awake()
    {
        _controller = GetComponent<CharacterEventController>();
    }
    // Start is called before the first frame update
    void Start()
    {
        _controller.OnMoveEvent += Move;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(direction * moveSpeed * Time.deltaTime);
        if (direction == Vector2.zero)
        {
            animator.SetBool("isMoving", false);
        }
    }

    private void Move(Vector2 _direction)
    {
        direction = _direction;
        animator.SetBool("isMoving", true);
    }

}
