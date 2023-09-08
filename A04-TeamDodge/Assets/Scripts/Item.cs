using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum ITEMTYPE { FOOD, GEM, TOWER, POWERUP, SPEEDUP, WEAPON, ATTACKSPEEDUP}
public abstract class Item : MonoBehaviour
{
    public ITEMTYPE ITEMTYPE { get; private set; }
    private void Awake()
    {
        gameObject.tag = "Item";
    }
}
public class Item_Food : Item 
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
public class Item_Gem : Item
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
public class Item_Tower : Item { }
public class Item_PowerUp : Item { }
public class Item_SpeedUp : Item { }
public class Item_AttackSpeedUp : Item { }
public class Item_Weapon : Item { }