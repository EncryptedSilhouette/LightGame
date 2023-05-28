using System;
using UnityEngine;

[Serializable]
public struct Item
{
    public int Amount;
    public ItemData ItemData;

    public int StackSize => ItemData.StackSize;
    public string ID => ItemData.ID;
    public Sprite ItemSprite => ItemData.ItemSprite;

    public Item(ItemData data, int amount)
    {
        ItemData = data;
        Amount = amount;
    }
}

[CreateAssetMenu(menuName = "Entities/Items")]
public class ItemData : ScriptableObject
{
    //Inspector values
    [SerializeField]
    private GameObject _entityObjectPrefab;
    [SerializeField]
    private Sprite _itemSprite;

    [SerializeField, Space(16)]
    private string _id;
    [SerializeField]
    private int _stackSize;

    public int StackSize => _stackSize;
    public string ID => _id;
    public Sprite ItemSprite => _itemSprite;
    public GameObject EntityObjectPrefab => _entityObjectPrefab;

    public Item CreateItem(int amount) => new Item(this, amount);
}
