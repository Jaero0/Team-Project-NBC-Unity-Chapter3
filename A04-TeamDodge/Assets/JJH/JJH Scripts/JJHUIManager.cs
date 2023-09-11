using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.UI;

public class JJHUIManager : MonoBehaviour
{
    [SerializeField] TMP_Text leftTimeTxt;

    [SerializeField] AudioManager audioManager;
    AudioSource cursorManagerAudioSource;
    AudioSource uiManagerAudioSource;

    [SerializeField] GameObject menuBackgroundImg;
    [SerializeField] GameObject menuOpenBtn;
    [SerializeField] GameObject menuCloseBtn;

    [SerializeField] Animator hourGlassAnim;
    [SerializeField] Animator menuAnim;
    [SerializeField] GameObject hourGlassImg;

    [SerializeField] GameObject volumeControlImg;
    [SerializeField] GameObject volumeFillBar;
    [SerializeField] GameObject reduceVolBtn;
    [SerializeField] GameObject gainVolBtn;
    RectTransform volBarRectTran;

    [SerializeField] GameObject changeScreenImg;
    [SerializeField] Toggle fullScreenToggle;
    [SerializeField] TMP_Dropdown changeScreenDropdown;
    FullScreenMode fullScreenMode;
    private List<Resolution> resolutions = new List<Resolution>();
    private int resolutionNum;
    

    private float leftTime;
    private string leftTimeMinute;
    private string leftTimeSecond;

    private float volumeControlNum;
    private float cursorVolumeControlNum;


    void Awake()
    {
        uiManagerAudioSource = GetComponent<AudioSource>();
        cursorManagerAudioSource = GameObject.Find("CursorManager").GetComponent<AudioSource>();

        hourGlassAnim = hourGlassImg.GetComponent<Animator>();

        menuAnim = menuBackgroundImg.GetComponent<Animator>();

        uiManagerAudioSource.clip = audioManager.mainBgm;

        volBarRectTran = volumeFillBar.GetComponent<RectTransform>();

        InitScreenResolution();
    }

    void Start()
    {
        uiManagerAudioSource.Play();
        leftTime = 25f;
        volumeControlNum = uiManagerAudioSource.volume * 0.25f;
        cursorVolumeControlNum = cursorManagerAudioSource.volume * 0.25f;
        menuAnim.SetBool("isMenuOpened", true);
    }

    // Update is called once per frame
    void Update()
    {
        LeftTime();
    }



    // ----------------- Time Methods-------------------
    private void LeftTime()
    {
        hourGlassAnim.SetBool("isStopped", false);
        leftTime -= Time.deltaTime;
        leftTimeMinute = Math.Truncate(leftTime / 60d).ToString();
        leftTimeSecond = Math.Truncate(leftTime % 60d).ToString();
        
        if(int.Parse(leftTimeSecond) >= 10)
        {
            leftTimeTxt.text = $"보스 등장까지 : {leftTimeMinute} : {leftTimeSecond}...";
        }
        else
        {
            leftTimeTxt.text = $"보스 등장까지 : {leftTimeMinute} : 0{leftTimeSecond}...";
        }

        if (int.Parse(leftTimeMinute) == 0 && 10 <= int.Parse(leftTimeSecond)  && int.Parse(leftTimeSecond) < 30)
        {
            leftTimeTxt.color = Color.blue;
            leftTimeTxt.text = $"보스 등장까지 : {leftTimeMinute} : {leftTimeSecond}...";
        }
        else if (int.Parse(leftTimeMinute) == 0 && int.Parse(leftTimeSecond) < 10)
        {
            uiManagerAudioSource.pitch = 1.1f;
            leftTimeTxt.color = Color.magenta;
            leftTimeTxt.text = $"보스 등장까지 : {leftTimeMinute} : 0{leftTimeSecond} !";
        }

        if (leftTime <= 0)
        {
            EndTime();
        }
    }

    private void EndTime()
    {
        leftTime = 0f;
        hourGlassAnim.SetBool("isStopped", true);
        uiManagerAudioSource.pitch = 0.9f;
        leftTimeTxt.color = Color.red;
        leftTimeTxt.text = $"보스 등장!";
    }
    // -------------------------------------------------



    // ------------ MenuClickMethods -------------------
    public void OnClickInvokeMenuOpenBtn()
    {
        menuAnim.SetBool("isOpenning", true);
        menuOpenBtn.SetActive(false);
        menuCloseBtn.SetActive(true);
        Invoke("TimeScaleZeroMethod", 0.065f);
    }

    private void TimeScaleZeroMethod()
    {
        Time.timeScale = 0;
    }

    public void OnClickInvokeMenuCloseBtn()
    {
        Time.timeScale = 1;
        menuAnim.SetBool("isOpenning", false);
        menuOpenBtn.SetActive(true);
        menuCloseBtn.SetActive(false);
    }
    // -------------------------------------------------



    // ------------ VolumeControlMethods ----------------
    public void OnClickVolumeControlOpenBtn()
    {
        volumeControlImg.SetActive(true);
        menuCloseBtn.SetActive(false);
    }

    public void OnClickVolumeControlCloseBtn()
    {
        volumeControlImg.SetActive(false);
        menuCloseBtn.SetActive(true);
    }

    public void OnClickReduceVolBtn()
    {
        //94 min 90 max 560
        volBarRectTran.sizeDelta -= new Vector2(94, 0);
        uiManagerAudioSource.volume -= volumeControlNum;
        cursorManagerAudioSource.volume -= cursorVolumeControlNum;

        if (volBarRectTran.sizeDelta.x <= 1)
        {
            reduceVolBtn.GetComponent<Button>().interactable = false;
        }
        else if(volBarRectTran.sizeDelta.x > 1)
        {
            gainVolBtn.GetComponent<Button>().interactable = true;
        }
    }

    public void OnClickGainVolBtn()
    {
        //94 min 90 max 560
        volBarRectTran.sizeDelta += new Vector2(94, 0);
        uiManagerAudioSource.volume += volumeControlNum;
        cursorManagerAudioSource.volume += cursorVolumeControlNum;

        if (volBarRectTran.sizeDelta.x >= 559)
        {
            gainVolBtn.GetComponent<Button>().interactable = false;
        }
        else if(volBarRectTran.sizeDelta.x < 559)
        {
            reduceVolBtn.GetComponent<Button>().interactable = true;
        }
    }
    // --------------------------------------------------



    // -------------ChangeScreenOption-------------------
    public void OnClickChangeScreenOpenBtn()
    {
        changeScreenImg.SetActive(true);
        menuCloseBtn.SetActive(false);
    }

    public void OnClickChangeScreenCloseBtn()
    {
        changeScreenImg.SetActive(false);
        menuCloseBtn.SetActive(true);
    }

    private void InitScreenResolution() // make Screen Resolutions and add it into Dropdown
    {
        resolutions.AddRange(Screen.resolutions);
        changeScreenDropdown.options.Clear();

        int screenOptionNum = 0;
        foreach (Resolution item in resolutions)
        {
            TMP_Dropdown.OptionData option = new TMP_Dropdown.OptionData();

            option.text = item.width + " x " + item.height + " " + item.refreshRateRatio + "hz";
            changeScreenDropdown.options.Add(option);

            if (item.width == Screen.width && item.height == Screen.height)
            {
                changeScreenDropdown.value = screenOptionNum;
            }
            screenOptionNum++;
        }
        changeScreenDropdown.RefreshShownValue();

        fullScreenToggle.isOn = Screen.fullScreenMode.Equals(FullScreenMode.FullScreenWindow) ? true : false;
    }

    public void OnClickChangeScreenDropdown(int x) //get num of choosen Screen Resolution from Dropdown
    {
        resolutionNum = x;
    }

    public void OnClickFullScreenToggle(bool isFull) // check Screen is already fulled or not
    {
        fullScreenMode = isFull ? FullScreenMode.FullScreenWindow : FullScreenMode.Windowed;
    }

    public void OnClickAdmitScreenChangeBtn() // Click Admit Btn, set up Screen Resolution and Fulled Window
    {
        Screen.SetResolution(resolutions[resolutionNum].width, resolutions[resolutionNum].height, fullScreenMode);
        changeScreenImg.SetActive(false);
        menuCloseBtn.SetActive(true);
    }
    //-----------------------------------------------------
}
