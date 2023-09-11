using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class MagneticCollider : MonoBehaviour
{
    [SerializeField]
    public GameObject RootGameObject;
    public Rigidbody2D rigid;

    public bool isPlayerEntered = false;
    public Transform target;
    private void Start()
    {
        rigid = RootGameObject.GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (isPlayerEntered) 
        {
            MoveToPlayer(); 
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            target = other.GetComponent<Transform>();
            isPlayerEntered = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            target = null;
            isPlayerEntered = false;
        }
    }

    private void MoveToPlayer()
    {
        if(target != null) 
        {
            Vector2 newPosition = Vector2.Lerp(RootGameObject.transform.position, target.transform.position, 0.05f);
            rigid.MovePosition(newPosition);
        }
    }
}
