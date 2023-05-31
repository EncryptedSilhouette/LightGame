using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField]
    private int _slots;
    [SerializeField]
    private List<Item> _items = new();

    public int Slots
    {
        get => _slots; 
        set
        {
            _slots = value;
            _items.Capacity = value < _items.Capacity ? _items.Capacity : value;
        }
    }

    public Item? this[int index] 
    {
        get
        {
            if (index > _items.Count - 1 || index < 0) return null;
            return _items[index];
        }
    } 
    public Item? this[string id]
    {
        get
        {
            foreach (Item item in _items) if (item.ID == id) return item;
            return null;
        }
    }

    private void Awake()
    {
        Slots = _slots;
    }

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
        if (index > _items.Count - 1) return;
    }

    public void RemoveItem(int index)
    {
        _items[index] = new();
    }

    public void RemoveItem(int index, out Item item)
    {
        item = _items[index];
        _items[index] = new();
    }

    public void RemoveItem(string id) 
    {
        for (int i = 0; i < _items.Capacity; i++)
        {
            if (_items[i].ID == id) _items[i] = new();
            return;
        }
    }

    public void RemoveItem(string id, out Item item)
    {
        for (int i = 0; i < _items.Capacity; i++)
        {
            if (_items[i].ID == id)
            {
                item = _items[i];
                _items[i] = new();
                return;
            }
        }
        item = new();
    }
}
