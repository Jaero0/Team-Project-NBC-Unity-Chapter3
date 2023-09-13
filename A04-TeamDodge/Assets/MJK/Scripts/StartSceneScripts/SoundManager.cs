using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SoundManager : MonoBehaviour
{
    public AudioSource audioSource;
    public static SoundManager instance;
    public AudioClip[] bglist;
    // Start is called before the first frame update



    private void Awake()
    {
        if (instance == null)
        {
            audioSource = GetComponent<AudioSource>();
            instance = this;
            DontDestroyOnLoad(instance);
            SceneManager.sceneLoaded += OnSceneLoaded;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void OnSceneLoaded(Scene arg0, LoadSceneMode arg1)
    {
        for (int i = 0; i < bglist.Length; i++)
        {
            if (arg0.name == bglist[i].name)
                BgSoundPlay(bglist[i]);

        }
    }

    public void BgSoundPlay(AudioClip clip)
    {
        audioSource.clip = clip;
        audioSource.loop = true;
        audioSource.volume = 0.2f;
        audioSource.Play();
    }

    public void SetMusicVolume(float volume)
    {
        PlayerPrefs.SetFloat("MusicVolume", volume);
        PlayerPrefs.Save(); // 변경 사항 저장
        Debug.Log("저장");
    }

    // 볼륨 값 로드
    public float GetMusicVolume()
    {
        return PlayerPrefs.GetFloat("MusicVolume", 0.5f); // 기본값 설정 (설정이 없는 경우)
    }


}