using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractCollider : MonoBehaviour
{
    public GameObject TowerGameObject;
    public Tower tower;

    public void Start()
    {
        tower = TowerGameObject.GetComponent<Tower>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            tower.PlayerEntered = true;
            tower.GageBar.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            tower.PlayerEntered = false;
            tower.GageBar.SetActive(false);
        }
    }
}
