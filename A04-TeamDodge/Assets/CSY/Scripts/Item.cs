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


    // 이전 버전과 오류없게 하기위해 남긴부분 수정후에 제거필요함
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
                // 타워는 플레이어가 일정시간이상 근처에 머무르면 완성되어 적들을 자동공격하도록 만들어볼까 예정
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

                //무기를 여러 종류로 만든다면 구현할 예정
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
