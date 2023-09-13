using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSelection : MonoBehaviour
{
    public GameObject[] characters;
    public int selectedCharacter = 0;



    public void NextCharacter()
    {
        characters[selectedCharacter].SetActive(false);
        selectedCharacter = (selectedCharacter + 1) % characters.Length;
        characters[selectedCharacter].SetActive(true);
    }

    public void PreviousCharacter()
    {
        characters[selectedCharacter].SetActive(false);
        selectedCharacter--;
        if (selectedCharacter < 0)
        {
            selectedCharacter += characters.Length;
        }
        characters[selectedCharacter].SetActive(true);
    }


    public void StartGame()
    {
        PlayerPrefs.SetInt("selectedCharacter", selectedCharacter);
        Debug.Log("캐릭터 선택");
    }

    public void Save0()
    {
        if(selectedCharacter == 0) {
            PlayerPrefs.SetInt("PlayerAvater", 0);
            Debug.Log("Save0");
        }
    }
    public void Save1()
    {
        if (selectedCharacter == 1)
        {
            PlayerPrefs.SetInt("PlayerAvater", 1);
            Debug.Log("Save1");
        }
    }
    public void Save2()
    {
        if (selectedCharacter == 2)
        {
            PlayerPrefs.SetInt("PlayerAvater", 2);
            Debug.Log("Save2");
        }
    }
}
