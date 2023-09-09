using UnityEditor;
using UnityEngine;

[CreateAssetMenu(fileName = "ItemData", menuName = "ScriptableObjects/ItemData", order = 2)]
public class ItemData : ScriptableObject
{
    public ITEMTYPE ItemType = ITEMTYPE.HEAL;
    public string ItemName = "이름없음";
    [TextArea(1,5)]
    public string ItemDescription = "설명을 넣어주세요";
    public int Heal = 0;
    public int Score = 0;
}
[CustomEditor(typeof(ItemData))]
public class ItemDataEditor : Editor
{
    SerializedProperty itemNameProp;
    SerializedProperty itemDescriptionProp;
    SerializedProperty itemTypeProp;
    SerializedProperty healProp;
    SerializedProperty scoreProp;

    void OnEnable()
    {
        itemNameProp = serializedObject.FindProperty("ItemName");
        itemDescriptionProp = serializedObject.FindProperty("ItemDescription");
        itemTypeProp = serializedObject.FindProperty("ItemType");
        healProp = serializedObject.FindProperty("Heal");
        scoreProp = serializedObject.FindProperty("Score");
    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();

        ItemData itemData = (ItemData)target;

        EditorGUILayout.PropertyField(itemNameProp);
        EditorGUILayout.PropertyField(itemDescriptionProp);
        EditorGUILayout.PropertyField(itemTypeProp);

        switch (itemData.ItemType)
        {
            case ITEMTYPE.HEAL:
                EditorGUILayout.PropertyField(healProp);
                break;

            case ITEMTYPE.SCORE:
                EditorGUILayout.PropertyField(scoreProp);
                break;

            default:
                break;
        }

        serializedObject.ApplyModifiedProperties();
    }
}