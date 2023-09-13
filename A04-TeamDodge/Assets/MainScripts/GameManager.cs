using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameManager gm;
    [SerializeField] GameObject player;
    [SerializeField] GameObject gameOverImg;
    private CharacterEventController _controller;

    bool asd = false;

    void Awake()
    {
        _controller = player.GetComponent<CharacterEventController>();
    }

    void Start()
    {
        _controller.OnDeathEvent += TurnOnGameOver;
    }

    void TurnOnGameOver()
    {
        Debug.Log("asd");
        gameOverImg.SetActive(true);
    }
}
