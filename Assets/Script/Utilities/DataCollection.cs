using UnityEngine;

[System.Serializable]
public class ItemDetails
{
    public int itemID;
    public string itemName;
    public string itemDescription;
    public ItemType itemType;
    //物品栏中图标
    public Sprite itemIcon;
    //在世界中放置的图标
    public Sprite itemOnWorldSprite;
    //物体使用半径
    public int itemUseRadius;
    public bool canPickedup;
    public bool canDropped;
    public bool canCarried;
    //价格
    public int itemPrice;
    [Range(0f, 1f)]
    //买卖价格之比
    public float sellPercentage;
}

[System.Serializable]
public struct InventoryItem
{
    public int itemID;
    public int itemAmount;
}