using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimationController : MonoBehaviour
{
    [SerializeField] Animator characterAnimator;
    [SerializeField] Animator skillAnimator;
    [SerializeField] Animator[] weaponAnimators;
    private int playerChoice;

    private enum AVATARS
    {
        KNIGHT,
        PUMPKIN,
        WIZARD
    }

    private void Awake()
    {
        playerChoice = PlayerPrefs.GetInt("PlayerAvater");
    }

    private void Start()
    {
        ChangeCharacter(playerChoice);
    }

    public void ChangeCharacter(int character)
    {
        switch ((AVATARS)character)
        {
            case AVATARS.KNIGHT:
                characterAnimator.SetInteger("avatar", 0);
                break;
            case AVATARS.PUMPKIN:
                characterAnimator.SetInteger("avatar", 1);
                break;
            case AVATARS.WIZARD:
                characterAnimator.SetInteger("avatar", 2);
                break;
        }
    }
}
