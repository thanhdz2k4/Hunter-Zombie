using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType
{
    Equipment,
    Boots
}
[CreateAssetMenu(fileName = "Assets/Data/ItemS0", menuName = "ItemSO/Item")]
public class ItemSO : ScriptableObject
{
    public bool isNull;
    public string name;
    public ItemType type;
    public Rarity_Tiers rarity;
    public Texture2D image;
    public GameObject Model;
    public string quantity;
    public int value;
    public string id_button_use;
    [TextArea(0, 220)] public string description;
}
