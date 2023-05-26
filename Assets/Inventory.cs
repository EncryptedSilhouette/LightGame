using UnityEngine;

public class Inventory : MonoBehaviour
{
    public bool pickupItems = true;

    private int _slots;
    private Item[] _items = new Item[10];

    public int MaxSlots 
    {
        get => _slots;
        set 
        {
            Item[] items = new Item[value];
            _slots = value;
            _items.CopyTo(items, 0);
            _items = items;
        }
    }

    public Item this[int index] => _items[index];
    public Item this[string id]
    {
        get
        {
            foreach (Item item in _items)
            {
                if (item.ID == id) return item;
            }
            return null;
        }
    } 
    
    public void AddItem(ItemEntity item)
    {
        for (int i = 0; i < _items.Length; i++)
        {
            if (_items[i] == null)
            {
                _items[i] = item;
            }
        }
    }
}
