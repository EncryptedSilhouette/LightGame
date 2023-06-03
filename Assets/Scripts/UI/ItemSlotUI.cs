using UnityEngine;

public class ItemSlotUI : MonoBehaviour
{
    private int _index;
    private Item _item;
    private Sprite _icon;
    private InventoryUI _inventoryUI;

    public void Init(InventoryUI inventoryUI, int index, Item item)
    {
        _index = index;
        _item = item;
        _icon = item.ItemSprite;
    }
}
