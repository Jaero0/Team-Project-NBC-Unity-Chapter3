using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimationController : MonoBehaviour
{
    [SerializeField] private Animator characterAnimator;
    [SerializeField] private Animator skillAnimator;
    [SerializeField] public Animator[] weaponAnimators;
    [SerializeField] private GameObject skill;
    [SerializeField] private GameObject[] weapons;
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
        Invoke("DeactivateSkill", 0.2f);
    }

    public void ChangeCharacter(int character)
    {
        switch ((AVATARS)character)
        {
            case AVATARS.KNIGHT:
                characterAnimator.SetInteger("avatar", 0);
                skillAnimator.SetInteger("avatar", 0);
                foreach (Animator weapon in weaponAnimators)
                {
                    weapon.SetInteger("avatar", 0);
                }
                break;
            case AVATARS.PUMPKIN:
                characterAnimator.SetInteger("avatar", 1);
                skillAnimator.SetInteger("avatar", 1);
                foreach (Animator weapon in weaponAnimators)
                {
                    weapon.SetInteger("avatar", 1);
                }
                break;
            case AVATARS.WIZARD:
                characterAnimator.SetInteger("avatar", 2);
                skillAnimator.SetInteger("avatar", 2);
                foreach (Animator weapon in weaponAnimators)
                {
                    weapon.SetInteger("avatar", 2);
                }
                break;
        }
    }

    private void DeactivateSkill()
    {
        skill.SetActive(false);
        for (int i = 1; i<weapons.Length; i++)
        {
            weapons[i].SetActive(false);
        }
    }
}
