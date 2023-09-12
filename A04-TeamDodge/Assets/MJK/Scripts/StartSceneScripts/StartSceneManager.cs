using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class StartMeunManager : MonoBehaviour
{
    public GameObject OPtionUI;
    private bool isOptionOpen = false;


    public void OnButtonClick() //StartBtn
    {
        SceneManager.LoadScene(1);
    }


    public void GameBackClick()//BackBtn
    {
        Invoke("gameBackBtn", 0.1f);
    }
    public void gameBackBtn()
    {
        SceneManager.LoadScene(0);
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
