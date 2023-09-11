using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{

    // �׽�Ʈ�� ���� �ڸ�

    [SerializeField] private GameObject player;


    // �׽�Ʈ�� ���� �ڸ�


    [SerializeField] private ItemSpawnData itemSpawnData;
    private static ItemSpawner instance;
    public static ItemSpawner Instance
    {
        get
        {
            if (instance == null)
            {
                GameObject temp = new GameObject("ItemSpawner");
                instance = temp.AddComponent<ItemSpawner>();
                DontDestroyOnLoad(temp);
            }
            return instance;
        }
    }
    public Dictionary<ItemData, int> PrefabIndex = new();
    public ItemData[] Potions;
    public ItemData[] Upgrades;
    public ItemData[] Scores;
    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(gameObject);

        PrefabIndex.Clear();
        for ( int i=0; i < itemSpawnData.ItemPrefabs.Length; i++)
        {
            PrefabIndex.Add(itemSpawnData.ItemPrefabs[i].GetComponent<Item>().ItemData, i);
        }
    }
    public void Start()
    {
        for( int i=0;i<itemSpawnData.ItemPrefabs.Length;i++)
        {
            MakeItem(itemSpawnData.ItemPrefabs[i].GetComponent<Item>().ItemData, player.transform.position, 3);
        }
    }
    public void MakeDropItem(ItemData itemData, Vector3 monster)
    {
        Instantiate(itemSpawnData.ItemPrefabs[PrefabIndex[itemData]], monster, Quaternion.identity);
    }
    public void MakeItem(ItemData itemData, Vector3 character, int randomDistance)
    {
        float x = Random.Range(-1f,1f);
        float y = Random.Range(-1f,1f);
        Vector3 newVector = new Vector3(x,y,0f).normalized * randomDistance + new Vector3(character.x + x, character.y + y, 0);
        Instantiate(itemSpawnData.ItemPrefabs[PrefabIndex[itemData]],newVector,Quaternion.identity);
    }

    public void MakeRandomDropItem(Vector3 monster)
    {
        int random = Random.Range(0, 1000);
        if (random <= 50)
        {
            MakeDropItem(Potions[random%Potions.Length], monster);
        }
        else if( random <= 100 )
        {
            MakeDropItem(Upgrades[random%Upgrades.Length], monster);
        }
        else
        {
            MakeDropItem(Scores[random % Scores.Length], monster);
        }
    }
    public void MakeRandomItem(Vector3 character, int randomDistance) 
    {
        int random = Random.Range(0, 1000);
        if (random <= 50)
        {
            MakeItem(Potions[random % Potions.Length], character, randomDistance);
        }
        else if (random <= 100)
        {
            MakeItem(Upgrades[random % Upgrades.Length], character, randomDistance);
        }
        else
        {
            MakeItem(Scores[random % Scores.Length], character, randomDistance);
        }
    }
}

[CreateAssetMenu(fileName = "ItemSpawnData", menuName = "ScriptableObjects/ItemSpawnData", order = 3)]
public class ItemSpawnData : ScriptableObject
{
    public GameObject[] ItemPrefabs;
}