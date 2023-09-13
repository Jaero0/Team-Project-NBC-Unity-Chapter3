using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class StartMeunManager : MonoBehaviour
{
    SoundManager sound;
    public GameObject OPtionUI;

    private float musicVolume = 0.5f; // 기본 볼륨 값

    // 볼륨 값 저장
    public void SetMusicVolume(float volume)
    {
        musicVolume = volume;
    }

    // 볼륨 값 로드
    public float GetMusicVolume()
    {
        return musicVolume;
    }

    public void OnButtonClick() //StartBtn
    {
        SceneManager.LoadScene("LevelScene");

    }


    public void GameBackClick()//BackBtn
    {
        SceneManager.LoadScene("StartScene");
    }


    public void QuitGame() // 게임종료
    {
        Application.Quit();
        Debug.Log("gameQuit");
    }

    public void OpenOptions()
    {
        OPtionUI.SetActive(true); // 옵션 UI를 활성화
    }

    // 옵션 창을 닫을 때 호출되는 함수
    public void CloseOptions()
    {
        OPtionUI.SetActive(false);
    }
}
