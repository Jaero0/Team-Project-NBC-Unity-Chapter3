using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorManage : MonoBehaviour
{
    public Texture2D cursorIcon;
    [SerializeField] AudioManager audioManager;
    AudioSource audioSource;

    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = audioManager.click;
    }

    void Start()
    {
        
        Cursor.SetCursor(cursorIcon, Vector2.zero, CursorMode.Auto);
    }

    public void OnMouseOver()
    {
        Cursor.SetCursor(cursorIcon, new Vector2(cursorIcon.width / 3, 0), CursorMode.Auto);
    }

    public void OnMouseExit()
    {
        Cursor.SetCursor(cursorIcon, new Vector2(0, 0), CursorMode.Auto);
    }

    public void OnClickSound() 
    { 
        audioSource.Play();
    }
}
