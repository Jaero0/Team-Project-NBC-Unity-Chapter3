using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{

    // 테스트를 위한 자리

    [SerializeField] private GameObject player;


    // 테스트를 위한 자리


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
            MakeItemRandom(itemSpawnData.ItemPrefabs[i].GetComponent<Item>().ItemData, player.transform.position, 3);
        }
    }
    public void MakeItem(ItemData itemData, Vector3 position)
    {
        Instantiate(itemSpawnData.ItemPrefabs[PrefabIndex[itemData]], position, Quaternion.identity);
    }
    public void MakeItemRandom(ItemData itemData, Vector3 character, int randomDistance)
    {
        float x = Random.Range(-1f,1f);
        float y = Random.Range(-1f,1f);
        Vector3 newVector = new Vector3(x,y,0f).normalized * randomDistance + new Vector3(character.x + x, character.y + y, 0);
        Instantiate(itemSpawnData.ItemPrefabs[PrefabIndex[itemData]],newVector,Quaternion.identity);
    }
}

[CreateAssetMenu(fileName = "ItemSpawnData", menuName = "ScriptableObjects/ItemSpawnData", order = 3)]
public class ItemSpawnData : ScriptableObject
{
    public GameObject[] ItemPrefabs;
}