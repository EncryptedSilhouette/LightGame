using UnityEngine;

public struct Item
{
    public int StackSize;
    public int Amount;
    public string ID;
    public Sprite ItemSprite;
}

[CreateAssetMenu(menuName = "Entities/Items")]
public class ItemData : ScriptableObject
{
    [SerializeField]
    private int _stackSize;
    [SerializeField]
    private string _id;
    [SerializeField]
    private Sprite _itemSprite;

    public int StackSize => _stackSize;
    public string ID => _id;
    public Sprite ItemSprite => _itemSprite;

    public Item CreateItem(int amount)
    {
        Item item = new Item();
        item.StackSize = _stackSize;
        item.Amount = amount;
        item.ID = ID;
        item.ItemSprite = _itemSprite;

        return item;
    }
}
