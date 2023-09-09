using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public enum ITEMTYPE { HEAL, SCORE, TOWER, WEAPON, ATTACKPOWERUP, MOVESPEEDUP, ATTACKSPEEDUP}
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


    public void ItemUsed()
    {
        switch (ItemData.ItemType)
        {
            case ITEMTYPE.HEAL:
                Destroy(gameObject);
                break;
            
            case ITEMTYPE.SCORE:
                Destroy(gameObject);
                break;
            
            case ITEMTYPE.TOWER:
                // Ÿ���� �÷��̾ �����ð��̻� ��ó�� �ӹ����� �ϼ��Ǿ� ������ �ڵ������ϵ��� ������ ����
                break;
            
            case ITEMTYPE.ATTACKPOWERUP:
                Destroy(gameObject);
                break;
            
            case ITEMTYPE.MOVESPEEDUP:
                Destroy(gameObject);
                break;

            case ITEMTYPE.ATTACKSPEEDUP:
                Destroy(gameObject);
                break;

            case ITEMTYPE.WEAPON:

                //���⸦ ���� ������ ����ٸ� ������ ����
                Destroy(gameObject);
                break;
            
            default:
            break;
        }
    }
    public void InsertItemData(ItemData newItemData) 
    { 
        itemData = newItemData;
    }
}
