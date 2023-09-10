using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public enum ITEMTYPE { POTION, SCORE, TOWER, WEAPON_NUMBER_UP, BULLET_NUMBER_UP, BULLET_SIZE_UP, MOVE_SPEED_UP, SHOOTING_SPEED_UP}
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
                ItemSpawner.Instance.MakeItem(ItemData,gameObject.transform.position,3);
                Destroy(gameObject);
                break;
            
            case ITEMTYPE.SCORE:
                ItemSpawner.Instance.MakeItem(ItemData, gameObject.transform.position, 3);
                Destroy(gameObject);
                break;
            
            case ITEMTYPE.TOWER:
                // Ÿ���� �÷��̾ �����ð��̻� ��ó�� �ӹ����� �ϼ��Ǿ� ������ �ڵ������ϵ��� ������ ����
                ItemSpawner.Instance.MakeItem(ItemData, gameObject.transform.position, 3);
                Destroy(gameObject);
                break;
            
            case ITEMTYPE.BULLET_SIZE_UP:
                ItemSpawner.Instance.MakeItem(ItemData, gameObject.transform.position, 3);
                Destroy(gameObject);
                break;

            case ITEMTYPE.BULLET_NUMBER_UP:
                ItemSpawner.Instance.MakeItem(ItemData, gameObject.transform.position, 3);
                Destroy(gameObject);
                break;

            case ITEMTYPE.MOVE_SPEED_UP:
                ItemSpawner.Instance.MakeItem(ItemData, gameObject.transform.position, 3);
                Destroy(gameObject);
                break;

            case ITEMTYPE.SHOOTING_SPEED_UP:
                ItemSpawner.Instance.MakeItem(ItemData, gameObject.transform.position, 3);
                Destroy(gameObject);
                break;

            case ITEMTYPE.WEAPON_NUMBER_UP:
                ItemSpawner.Instance.MakeItem(ItemData, gameObject.transform.position, 3);
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
