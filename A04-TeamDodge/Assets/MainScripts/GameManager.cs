using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameManager gm;
    [SerializeField] GameObject gameOverImg;
    [SerializeField] GameObject gameWinImg;
    [SerializeField] AudioManager am;
    [SerializeField] UIManager um;
    AudioSource audioS;

    void Awake()
    {
        audioS = GetComponent<AudioSource>();
    }

    void Start()
    {
        audioS.clip = null;
        CharacterEventController.instance.OnDeathEvent += TurnOnGameOver;
        MonsterManager.Instance.AddMonsterDieEvent(DefeatBoss);
    }

    void TurnOnGameOver()
    {
        um.GetComponent<AudioSource>().Stop();
        Time.timeScale = 0;
        audioS.clip = am.gameOver;
        audioS.Play();
        gameOverImg.SetActive(true);
    }

    void DefeatBoss(int identifier, Vector3 position)
    {
        if (identifier == 3)
        {
            um.GetComponent<AudioSource>().Stop();
            Time.timeScale = 0;
            audioS.clip = am.gameWin;
            audioS.Play();
            audioS.Play();
            gameWinImg.SetActive(true);
        }
    }
}
