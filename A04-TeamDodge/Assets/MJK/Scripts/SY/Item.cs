using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public enum ITEMTYPE { FOOD, SCOREITEM, TOWER, POWERUP, SPEEDUP, WEAPON, ATTACKSPEEDUP}
public class Item : MonoBehaviour
{
    [SerializeField] private ITEMTYPE itemType;
    public ITEMTYPE ItemType => itemType;

    // 나중에 Item을 상속받는 클래스가 생기면 이 부분을 상속받은 클래스로 옮겨도 좋을듯
    [SerializeField] private int heal;
    [SerializeField] private string itemName;
   
    public int Heal => heal;
    public string ItemName => itemName;


    private void Awake()
    {
        gameObject.tag = "Item";
    }

    public virtual void ItemUsed()
    {
        switch (ItemType)
        {
            case ITEMTYPE.FOOD:
                Destroy(gameObject);
                break;
            
            case ITEMTYPE.SCOREITEM:
                Destroy(gameObject);
                break;
            
            case ITEMTYPE.TOWER:
                // 타워는 플레이어가 일정시간이상 근처에 머무르면 완성되어 적들을 자동공격하도록 만들어볼까 예정
                break;
            
            case ITEMTYPE.POWERUP:
                Destroy(gameObject);
                break;
            
            case ITEMTYPE.SPEEDUP:
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
}
