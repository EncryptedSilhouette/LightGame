using System.Collections.Generic;
using UnityEngine;

public enum InventorySize
{
    //8x4
    PLAYER,
    //1x1
    SINGLE,
    //2x2
    MINI,
    //3x3
    SMALL,
    //4x4
    MEDIUM,
    //5x4
    LARGE,
    //6x4
    XLARGE
}

public class Inventory : MonoBehaviour
{
    [SerializeField]
    private InventorySize _size;
    [SerializeField]
    private List<Item> _items = new();

    public int Slots
    {
        get => _items.Capacity;
        private set
        {
            //Allows overflow in case of an error to prevent item deletion.
            _items.Capacity = value < _items.Capacity ? _items.Capacity : value;
        }
    }

    public InventorySize InventorySize
    {
        get => _size; 
        set
        {
            //Sets the slot count based on InventorySize
            _size = value;
            Slots = _size.GetInventorySlots();
        }
    }

    public Item this[int index] 
    {
        get
        {
            if (index > _items.Count - 1 || index < 0) return new();
            return _items[index];
        }
    } 

    public Item this[string id]
    {
        get
        {
            foreach (Item item in _items) if (item.ID == id) return item;
            return new();
        }
    }

    //For Serialization 
    private void Awake() => InventorySize = _size;

    public bool AddItem(Item item)
    {
        for (int i = 0; i < _items.Capacity; i++)
        {
            if (_items[i].ID == null)
            {
                _items[i] = item;
                return true;
            }
        }
        return false;
    }

    public void AddItem(Item item, int index) 
    {
        //if (index > _items.Count - 1) return;
    }

    public void RemoveItem(int index)
    {
        _items[index] = new();
    }

    public void RemoveItem(int index, out Item item)
    {
        item = _items[index];
        RemoveItem(index);
    }

    public void RemoveItem(string id) 
    {
        for (int i = 0; i < _items.Capacity; i++)
        {
            if (_items[i].ID == id)
            {
                RemoveItem(i);
                return;
            } 
        }
    }

    public void RemoveItem(string id, out Item item)
    {
        for (int i = 0; i < _items.Capacity; i++)
        {
            if (_items[i].ID == id)
            {
                RemoveItem(i, out item);
                return;
            }
        }
        item = new();
    }

    public void OpenUI()
    {

    }
}

public static class InventoryExtensions
{
    //GOD C# HAS SO MANY MORE FEATURES THAN JAVA BUT GOD FORBID ITS ENUMS HAVE A FRACTION OF JAVA'S ENUM CAPABILITIES. THEREFORE THIS SHIT MUST EXIST.
    public static Vector2 GetInventoryDimensions(this InventorySize size)
    {
        return size switch
        {
            InventorySize.PLAYER => new(8, 4),
            InventorySize.SINGLE => new(1, 1),
            InventorySize.MINI => new(2, 2),
            InventorySize.SMALL => new(3, 3),
            InventorySize.MEDIUM => new(4, 4),
            InventorySize.LARGE => new(5, 4),
            InventorySize.XLARGE => new(6, 4),
            _ => new(3,3) 
        };
    }

    public static int GetInventorySlots(this InventorySize size)
    {
        Vector2 dimensions = GetInventoryDimensions(size);
        return (int) (dimensions.x * dimensions.y);
    }
}
