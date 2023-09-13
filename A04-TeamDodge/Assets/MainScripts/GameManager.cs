using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameManager gm;
    [SerializeField] GameObject gameOverImg;
    [SerializeField] GameObject gameWinImg;

    void Start()
    {
        CharacterEventController.instance.OnDeathEvent += TurnOnGameOver;
        MonsterManager.Instance.AddMonsterDieEvent(DefeatBoss);
    }

    void TurnOnGameOver()
    {
        Time.timeScale = 0;
        gameOverImg.SetActive(true);
    }

    void DefeatBoss(int identifier, Vector3 position)
    {
        if (identifier == 3)
        {
            Time.timeScale = 0;
            gameWinImg.SetActive(true);
        }
    }
}
