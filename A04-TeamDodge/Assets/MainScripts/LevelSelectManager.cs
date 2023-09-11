using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelectManager : MonoBehaviour
{
    public void OnClickLevelSelection_1()
    {
        SceneManager.LoadScene("Lv1Scene");
    }

    public void OnClickLevelSelection_2()
    {
        SceneManager.LoadScene("Lv2Scene");
    }

    public void OnClickLevelSelection_3()
    {
        SceneManager.LoadScene("Lv3Scene");
    }
}
