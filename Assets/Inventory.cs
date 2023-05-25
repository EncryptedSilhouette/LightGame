using UnityEngine;

public class Inventory : MonoBehaviour
{
    public bool pickupItems = true;

    private int _slots;
    private ItemEntity[] _items = new ItemEntity[10];

    public int MaxSlots 
    {
        get => _slots;
        set 
        {
            ItemEntity[] items = new ItemEntity[value];
            _slots = value;
            _items.CopyTo(items, 0);
            _items = items;
        }
    }

    public ItemEntity this[int index] => _items[index];
    public ItemEntity this[string id]
    {
        get
        {
            foreach (ItemEntity item in _items)
            {
                if (item.ItemData.ID == id) return item;
            }
            return null;
        }
    } 

    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
