using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameManager gm;
    [SerializeField] GameObject gameOverImg;
    private CharacterEventController _controller;



    void Start()
    {
        CharacterEventController.instance.OnDeathEvent += TurnOnGameOver;
    }

    void TurnOnGameOver()
    {
        Time.timeScale = 0;
        gameOverImg.SetActive(true);
    }
}
