using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public enum ITEMTYPE { FOOD, SCOREITEM, TOWER, POWERUP, SPEEDUP, WEAPON, ATTACKSPEEDUP}
public class Item : MonoBehaviour
{
    [SerializeField] private ITEMTYPE itemType;
    public ITEMTYPE ItemType => itemType;

    // ���߿� Item�� ��ӹ޴� Ŭ������ ����� �� �κ��� ��ӹ��� Ŭ������ �Űܵ� ������
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
                // Ÿ���� �÷��̾ �����ð��̻� ��ó�� �ӹ����� �ϼ��Ǿ� ������ �ڵ������ϵ��� ������ ����
                break;
            
            case ITEMTYPE.POWERUP:
                Destroy(gameObject);
                break;
            
            case ITEMTYPE.SPEEDUP:
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
}
