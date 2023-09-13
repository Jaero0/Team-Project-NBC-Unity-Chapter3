using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public enum ITEMTYPE { POTION, TOWER, SCORE, WEAPON_NUMBER_UP, BULLET_NUMBER_UP, BULLET_SIZE_UP, MOVE_SPEED_UP, SHOOTING_SPEED_UP}
public class Item : MonoBehaviour
{
    [SerializeField]
    private ItemData itemData;
    public ItemData ItemData => itemData;

    private void Awake()
    {
        gameObject.tag = "Item";
    }

    // ���� ������ �������� �ϱ����� ����κ� �����Ŀ� �����ʿ���
    public string ItemName => ItemData.ItemName;
    public int Heal => ItemData.Heal;
    public ITEMTYPE ItemType => ItemData.ItemType;

    public void OnPlayerPickUp()
    {
        switch (ItemData.ItemType)
        {
            case ITEMTYPE.POTION:
                
                Destroy(gameObject);
                break;
            
            case ITEMTYPE.SCORE:
                
                Destroy(gameObject);
                break;
            
            case ITEMTYPE.BULLET_SIZE_UP:
                
                Destroy(gameObject);
                break;

            case ITEMTYPE.BULLET_NUMBER_UP:
                
                Destroy(gameObject);
                break;

            case ITEMTYPE.MOVE_SPEED_UP:
                
                Destroy(gameObject);
                break;

            case ITEMTYPE.SHOOTING_SPEED_UP:
                
                Destroy(gameObject);
                break;

            case ITEMTYPE.WEAPON_NUMBER_UP:
                
                Destroy(gameObject);
                break;

            case ITEMTYPE.TOWER:
                
                Destroy(gameObject);
                break;

            default:
            break;
        }
    }
    //public void InsertItemData(ItemData newItemData) 
    //{ 
    //    itemData = newItemData;
    //}
    //public void SpinAroundCharacter()
    //{

    //}
}
